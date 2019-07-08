using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using VehicleService.Data;
using VehicleService.Models;

namespace VehicleService.Pages.Vehicles
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public DeleteModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public VehicleMake VehicleMake { get; set; }

        [TempData]
        public string Message { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            VehicleMake = await _db.VehicleMake
                .Include(v => v.ApplicationUser).FirstOrDefaultAsync(m => m.Id == id);

            if (VehicleMake == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            VehicleMake = await _db.VehicleMake.FindAsync(id);

            if (VehicleMake != null)
            {
                _db.VehicleMake.Remove(VehicleMake);
                await _db.SaveChangesAsync();
                Message = "Vehicle deleted successfully.";
            }

            return RedirectToPage("./Index");
        }
    }
}
