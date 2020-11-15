using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Views.ViewModels
{
    public class SaveEditRegionViewModel
    {
        [Required(ErrorMessage = "Campo obligatorio")]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Campo obligatorio")]
        public int Code { get; set; }
        public string OriginalName { get; set; }
    }
}