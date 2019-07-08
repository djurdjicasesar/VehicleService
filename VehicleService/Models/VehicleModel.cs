using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleService.Models
{
    public class VehicleModel
    {
        [Key]
        public int Id { get; set; }

        public int MakeId { get; set; }

        [Required]
        public string Name { get; set; }
        public string Abrv { get; set; }

        [ForeignKey("MakeId")]
        public virtual VehicleMake VehicleMake { get; set; }
    }
}
