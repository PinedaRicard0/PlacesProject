using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Views.ViewModels
{
    public class RegionViewModel
    {
        public Guid Id { get; set; }
        [Required]
        [Display(Name = "Código")]
        public int Code { get; set; }
        [Required]
        [Display(Name = "Nombre")]
        public string Name { get; set; }
    }
}