using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Views.ViewModels
{
    public class RegionViewModel
    {
        public String Id { get; set; }
        [Display(Name = "Código")]
        public int Code { get; set; }

        [Display(Name = "Nombre")]
        public string Name { get; set; }
    }
}