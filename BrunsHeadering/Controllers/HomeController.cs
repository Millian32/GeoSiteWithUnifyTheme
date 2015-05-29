using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using BrunsHeadering.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;

namespace BrunsHeadering.Controllers
{
    public class HomeController : Controller
    {
        [OutputCache(Duration = 43200)]
        public ViewResult Index()
        {
            return View();
        }

        [OutputCache(Duration = 43200)]
        public ViewResult Contact()
        {
            return View();
        }

        [OutputCache(Duration = 43200)]
        public ViewResult FlushPurge()
        {
            return View();
        }

        [OutputCache(Duration = 43200)]
        public ViewResult WhatWeDo()
        {
            return View();
        }

        [OutputCache(Duration = 43200)]
        public ViewResult WhatIsGeothermal()
        {
            return View();
        }

        #region List Of Jobs

        [OutputCache(Duration = 43200)]
        public ViewResult ListOfJobs_Edu()
        {
            return View();
        }

        [OutputCache(Duration = 43200)]
        public ViewResult ListOfJobs_Gov()
        {
            return View();
        }

        [OutputCache(Duration = 43200)]
        public ViewResult ListOfJobs_Heal()
        {
            return View();
        }

        [OutputCache(Duration = 43200)]
        public ViewResult ListOfJobs_Comm()
        {
            return View();
        }

        [OutputCache(Duration = 43200)]
        public ViewResult ListOfJobs_House()
        {
            return View();
        }

        [OutputCache(Duration = 43200)]
        public ViewResult ListOfJobs_Bus()
        {
            return View();
        }

        #endregion

        #region Pictures

        [OutputCache(Duration = 43200, VaryByParam= "*")]
        public PicViewModel GetPics(string dir)
        {
            if (string.IsNullOrEmpty(dir))
            {
                return new PicViewModel { Directory = string.Empty };
            }

            var picViewModel = new PicViewModel { Directory = dir };
            var files = Directory.EnumerateFiles(Server.MapPath(dir)).Select(fn => dir + Path.GetFileName(fn)).ToList();

            foreach (string IT in files)
            {
                var picModel = new PicModel();
                picModel.PicFileName = IT;
                if (!picModel.PicFileName.Contains("Thumbs.db"))
                {
                    picViewModel.ListFileNames.Add(picModel);
                }               
            }

            return picViewModel;
        }

        [OutputCache(Duration = 43200, VaryByParam = "*")]
        public ViewResult PicsListView(string menuSelected) 
        {
            if (string.IsNullOrEmpty(menuSelected))
            {
                return View("PicsListView", new PicViewModel { Directory = string.Empty });
            }

            var dir = string.Empty;
            switch (menuSelected)
            {
                case "CampRipley":
                    dir = "/Images/Pictures/Camp Ripley/Camp Ripley Military Base/";
                    break;
                case "IowaPrison":
                    dir = "/Images/Pictures/Iowa State Maximum Security Prison/";
                    break;
                case "LincolnSchool":
                    dir = "/Images/Pictures/LPS Lincoln Public School District Office/";
                    break;
                case "Cornhuskers":
                    dir = "/Images/Pictures/UNL Nebraska Cornhuskers Housing Project/";
                    break;
            }

            var picViewModel = GetPics(dir);
            picViewModel.Directory = dir;

            return View("PicsListView", picViewModel);
        }

        [OutputCache(Duration = 43200, VaryByParam = "*")]
        public ActionResult Pics_Read([DataSourceRequest] DataSourceRequest request, string dir)
        {
            var picViewModel = GetPics(dir);
            picViewModel.Directory = dir;

            return Json(picViewModel.ListFileNames.ToDataSourceResult(request));
        }

        #endregion

    }
}
