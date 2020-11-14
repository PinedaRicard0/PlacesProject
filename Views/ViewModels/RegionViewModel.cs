using System;
using System.ComponentModel.DataAnnotations;

namespace Views.ViewModels
{
    public class RegionViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "*Código")]
        public int Code { get; set; }

        [Required(ErrorMessage = "Campo obligatorio")]
        [Display(Name = "*Nombre")]
        [MaxLength(100)]
        public string Name { get; set; }

        public int Municipalities { get; set; }
    }
}