using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Models;

namespace Project.Pages.Adoptions
{
    public class DeleteModel : PageModel
    {
        private readonly Project.Data.ApplicationDbContext _context;

        public DeleteModel(Project.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Adoption Adoption { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Adoption == null)
            {
                return NotFound();
            }

            var adoption = await _context.Adoption.FirstOrDefaultAsync(m => m.AdoptionId == id);

            if (adoption == null)
            {
                return NotFound();
            }
            else 
            {
                Adoption = adoption;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Adoption == null)
            {
                return NotFound();
            }
            var adoption = await _context.Adoption.FindAsync(id);

            if (adoption != null)
            {
                Adoption = adoption;
                _context.Adoption.Remove(Adoption);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
