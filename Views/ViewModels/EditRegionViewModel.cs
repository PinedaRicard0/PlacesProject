using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Views.ViewModels
{
    public class EditRegionViewModel
    {
        public string OriginalName { get; set; }
        public RegionViewModel Region { get; set; }
        public List<MunicipalityViewModel> Municipalities { get; set; }
    }
}