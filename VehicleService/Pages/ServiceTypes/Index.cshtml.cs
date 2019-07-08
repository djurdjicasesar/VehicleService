using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using VehicleService.Data;
using VehicleService.Models;
using VehicleService.Utility;

namespace VehicleService.Pages.ServiceTypes
{
   
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public IList<ServiceType> ServiceType { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            ServiceType = await _db.ServiceType.ToListAsync();
            return Page();
        }
    }
}