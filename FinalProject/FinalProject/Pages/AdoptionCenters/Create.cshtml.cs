using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project.Data;
using Project.Models;

namespace Project.Pages.AdoptionCenters
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
            return Page();
        }

        [BindProperty]
        public AdoptionCenter AdoptionCenter { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.AdoptionCenter == null || AdoptionCenter == null)
            {
                return Page();
            }

            _context.AdoptionCenter.Add(AdoptionCenter);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
