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

namespace Project.Pages.Adoptions
{
    public class EditModel : PageModel
    {
        private readonly Project.Data.ApplicationDbContext _context;

        public EditModel(Project.Data.ApplicationDbContext context)
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

            var adoption =  await _context.Adoption.FirstOrDefaultAsync(m => m.AdoptionId == id);
            if (adoption == null)
            {
                return NotFound();
            }
            Adoption = adoption;
           ViewData["CenterId"] = new SelectList(_context.AdoptionCenter, "AdoptionCenterId", "AdoptionCenterId");
           ViewData["DogId"] = new SelectList(_context.Dog, "DogId", "DogId");
           ViewData["UserId"] = new SelectList(_context.User, "UserId", "UserId");
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

            _context.Attach(Adoption).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdoptionExists(Adoption.AdoptionId))
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

        private bool AdoptionExists(int id)
        {
          return (_context.Adoption?.Any(e => e.AdoptionId == id)).GetValueOrDefault();
        }
    }
}
