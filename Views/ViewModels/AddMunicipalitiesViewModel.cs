using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Views.ViewModels
{
    public class AddMunicipalitiesViewModel
    {
        public string Region { get; set; }
        public string RegionId { get; set; }
        public List<MunicipalitySelectionViewModel> Municipalities { get; set; }
    }
}