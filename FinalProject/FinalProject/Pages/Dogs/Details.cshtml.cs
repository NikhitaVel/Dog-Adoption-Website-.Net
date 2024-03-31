using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Models;

namespace Project.Pages.Dogs
{
    public class DetailsModel : PageModel
    {
        private readonly Project.Data.ApplicationDbContext _context;

        public DetailsModel(Project.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public Dog Dog { get; set; } = default!;
      public AdoptionCenter Center { get; set; } = default!;


        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Dog == null)
            {
                return NotFound();
            }

            var dog = await _context.Dog.FirstOrDefaultAsync(m => m.DogId == id);
            if (dog == null)
            {
                return NotFound();
            }
            else 
            {
                Dog = dog;
                Center = await _context.AdoptionCenter.FirstOrDefaultAsync(m => m.AdoptionCenterId == Dog.CenterNameId);
            }
            return Page();
        }
    }
}
