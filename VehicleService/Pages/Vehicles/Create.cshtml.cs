using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VehicleService.Data;
using VehicleService.Models;
using VehicleService.Models.ViewModel;
using VehicleService.Utility;

namespace VehicleService.Pages.Vehicles
{
    
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        [BindProperty]
        public VehicleMake VehicleMakes{ get; set; }

        [TempData]
        public string Message { get; set; }

        public CreateModel(ApplicationDbContext db)
        { 
            _db = db;
        }

        public IActionResult OnGet(string userId=null)
        {
         VehicleMakes = new VehicleMake();

        if (userId == null)
        {
            var claimsId = (ClaimsIdentity)User.Identity;
            var claim = claimsId.FindFirst(ClaimTypes.NameIdentifier);
            userId = claim.Value;
        }
        VehicleMakes.UserId = userId;
        return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _db.VehicleMake.Add(VehicleMakes);
            await _db.SaveChangesAsync();
            Message = "Vehicle added succesfully!";
            return RedirectToPage("Index", new { userId = VehicleMakes.UserId });
        }

    }
}
