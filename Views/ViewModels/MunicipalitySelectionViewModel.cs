using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Views.ViewModels
{
    public class MunicipalitySelectionViewModel
    {
        public bool IsSelected { get; set; }
        public string Name { get; set; }
        public Guid Id { get; set; }
    }
}