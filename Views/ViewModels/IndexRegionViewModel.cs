using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Views.ViewModels
{
    public class IndexRegionViewModel
    {
        public List<RegionViewModel> ListRegions { get; set; }
        public RegionViewModel Region { get; set; }
        public bool IsError { get; set; }
    }
}