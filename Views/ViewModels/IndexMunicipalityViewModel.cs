using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Views.ViewModels
{
    public class IndexMunicipalityViewModel
    {
        public List<MunicipalityViewModel> ListMunicipalities { get; set; }
        public MunicipalityViewModel Municipality { get; set; }
        public bool IsError { get; set; }
        public bool IsEditing { get; set; }
    }
}