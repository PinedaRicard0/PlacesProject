using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models
{
    public class RegionMunicipalities
    {
        [Key, Column(Order = 1)]
        [ForeignKey("Region")]
        public Guid RegionId { get; set; }
        public virtual Region Region { get; set; }


        [Key, Column(Order = 2)]
        [ForeignKey("Municipality")]
        public Guid MunicipalityId { get; set; }
        public virtual Municipality Municipality { get; set; }
    }
}
