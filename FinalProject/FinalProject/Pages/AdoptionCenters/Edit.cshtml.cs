using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Models;

namespace Project.Pages.AdoptionCenters
{
    public class EditModel : PageModel
    {
        private readonly Project.Data.ApplicationDbContext _context;

        public EditModel(Project.Data.ApplicationDbContext context)
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

            var adoptioncenter =  await _context.AdoptionCenter.FirstOrDefaultAsync(m => m.AdoptionCenterId == id);
            if (adoptioncenter == null)
            {
                return NotFound();
            }
            AdoptionCenter = adoptioncenter;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(AdoptionCenter).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdoptionCenterExists(AdoptionCenter.AdoptionCenterId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool AdoptionCenterExists(int id)
        {
          return (_context.AdoptionCenter?.Any(e => e.AdoptionCenterId == id)).GetValueOrDefault();
        }
    }
}
