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
    public class CreateModel : PageModel
    {
        private readonly Project.Data.ApplicationDbContext _context;
         
        public CreateModel(Project.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Dog> Dog { get; set; } = default!;
        public IList<AdoptionCenter> Center { get; set; } = default!;

        // public IActionResult OnGet(int? dogId)
        // {
           // if (dogId == null)
            // {
             //   return NotFound();
            // }

            // var dog = _context.Dog.Find(dogId);

            // ViewData["DogId"] = dog.DogId;

            // //ViewBag.AdoptionCenter = dog.AdoptionCenter.Name; // Assuming AdoptionCenter is a navigation property in the Dog entity

            // return Page();
        //}

        public IActionResult OnGet()
        {
        ViewData["CenterId"] = new SelectList(_context.AdoptionCenter, "AdoptionCenterId", "AdoptionCenterId");
        ViewData["DogId"] = new SelectList(_context.Dog, "DogId", "DogId");
        ViewData["UserId"] = new SelectList(_context.User, "UserId", "UserId");
        return Page();
        }

        [BindProperty]
        public Adoption Adoption { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Adoption == null || Adoption == null)
            {
                return Page();
            }

            _context.Adoption.Add(Adoption);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
