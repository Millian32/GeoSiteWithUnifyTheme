using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BrunsHeadering.Models
{
    public class PicViewModel
    {
        public List<PicModel> ListFileNames = new List<PicModel>();
        public string Directory { get; set; }
    }
}