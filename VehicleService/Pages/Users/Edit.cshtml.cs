﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using VehicleService.Data;
using VehicleService.Models;
using VehicleService.Models.ViewModel;
using VehicleService.Utility;

namespace VehicleService.Pages.Users
{
    [Authorize(Roles = SD.Admin)]
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public ApplicationUser ApplicationUser { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id.Trim().Length == 0)
            {
                return NotFound();
            }

            ApplicationUser = await _db.ApplicationUser.FirstOrDefaultAsync(m => m.Id == id);

            if (ApplicationUser == null)
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
            else
            {
                var userInDb = await _db.ApplicationUser.SingleOrDefaultAsync(u => u.Id == ApplicationUser.Id);
                if (userInDb == null)
                {
                    return NotFound();
                }
                else
                {
                    userInDb.Name = ApplicationUser.Name;
                    userInDb.PhoneNumber = ApplicationUser.PhoneNumber;
                    userInDb.City = ApplicationUser.City;
                    userInDb.PostalCode = ApplicationUser.PostalCode;

                    await _db.SaveChangesAsync();
                    return RedirectToPage("Index");
                }
            }
        }
    }
}