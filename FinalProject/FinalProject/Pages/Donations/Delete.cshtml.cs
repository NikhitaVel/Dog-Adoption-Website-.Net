using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Models;

namespace Project.Pages.Donations
{
    public class DeleteModel : PageModel
    {
        private readonly Project.Data.ApplicationDbContext _context;

        public DeleteModel(Project.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Donation Donation { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Donation == null)
            {
                return NotFound();
            }

            var donation = await _context.Donation.FirstOrDefaultAsync(m => m.DonationId == id);

            if (donation == null)
            {
                return NotFound();
            }
            else 
            {
                Donation = donation;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Donation == null)
            {
                return NotFound();
            }
            var donation = await _context.Donation.FindAsync(id);

            if (donation != null)
            {
                Donation = donation;
                _context.Donation.Remove(Donation);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
