using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project.Data;
using Project.Models;

namespace Project.Pages.Donations
{
    public class CreateModel : PageModel
    {
        private readonly Project.Data.ApplicationDbContext _context;

        public CreateModel(Project.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CenterId"] = new SelectList(_context.AdoptionCenter, "AdoptionCenterId", "AdoptionCenterId");
        ViewData["UserId"] = new SelectList(_context.User, "UserId", "UserId");
            return Page();
        }

        [BindProperty]
        public Donation Donation { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Donation == null || Donation == null)
            {
                return Page();
            }

            _context.Donation.Add(Donation);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Thankyou");
        }
    }
}
