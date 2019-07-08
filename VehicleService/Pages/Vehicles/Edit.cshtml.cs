using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VehicleService.Data;
using VehicleService.Models;

namespace VehicleService.Pages.Vehicles
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        [TempData]
        public string Message { get; set; }

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public VehicleMake VehicleMake { get; set; }

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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _db.Attach(VehicleMake).State = EntityState.Modified;

            await _db.SaveChangesAsync();
            Message = "Vehicle updated successfully.";
            return RedirectToPage("./Index", new { userId = VehicleMake.UserId });
        }
    }
}
