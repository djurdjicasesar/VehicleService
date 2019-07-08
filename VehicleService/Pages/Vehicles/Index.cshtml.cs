using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using VehicleService.Data;
using VehicleService.Models.ViewModel;

namespace VehicleService.Pages.Vehicles
{
    
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        [BindProperty]
        public VehicleMakeViewModel VehicleMakeVM { get; set; }

        [TempData]
        public string Message { get; set; }

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<IActionResult> OnGet(string userId = null)
        {
            if(userId == null)
            {
                var claimsId = (ClaimsIdentity)User.Identity;
                var claim = claimsId.FindFirst(ClaimTypes.NameIdentifier);
                userId = claim.Value;
            }

            VehicleMakeVM = new VehicleMakeViewModel()
            {
                VehicleMakes = await _db.VehicleMake.Where(v => v.UserId == userId).ToListAsync(),
                UserObj = await _db.ApplicationUser.FirstOrDefaultAsync(u=>u.Id==userId)
            };

            return Page();
        }
    }
}