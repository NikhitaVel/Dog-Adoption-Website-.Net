using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Models;

namespace Project.Pages.AdoptionCenters
{
    public class DeleteModel : PageModel
    {
        private readonly Project.Data.ApplicationDbContext _context;

        public DeleteModel(Project.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public AdoptionCenter AdoptionCenter { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.AdoptionCenter == null)
            {
                return NotFound();
            }

            var adoptioncenter = await _context.AdoptionCenter.FirstOrDefaultAsync(m => m.AdoptionCenterId == id);

            if (adoptioncenter == null)
            {
                return NotFound();
            }
            else 
            {
                AdoptionCenter = adoptioncenter;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.AdoptionCenter == null)
            {
                return NotFound();
            }
            var adoptioncenter = await _context.AdoptionCenter.FindAsync(id);

            if (adoptioncenter != null)
            {
                AdoptionCenter = adoptioncenter;
                _context.AdoptionCenter.Remove(AdoptionCenter);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
