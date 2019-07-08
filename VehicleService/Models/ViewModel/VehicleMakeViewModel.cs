using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleService.Models.ViewModel
{
    public class VehicleMakeViewModel
    {
        public ApplicationUser UserObj { get; set; }
        public IEnumerable<VehicleMake> VehicleMakes { get; set; }
    }
}
