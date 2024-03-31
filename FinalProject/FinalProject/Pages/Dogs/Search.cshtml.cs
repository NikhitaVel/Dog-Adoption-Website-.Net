using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Models;

namespace Project.Pages.Dogs
{
    public class SearchModel : PageModel
    {
        private readonly Project.Data.ApplicationDbContext _context;
          
        public SearchModel(Project.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Dog> Dog { get;set; } = default!;
        public bool SearchCompleted { get; set;  }
        public string Query { get; set; }

        public async Task OnGetAsync(string query)
        {
            Query = query;

            if (!string.IsNullOrWhiteSpace(Query))
            {
                SearchCompleted = true;
                Dog = await _context.Dog.Where(x => (x.Breed.StartsWith(query)) ||
                (x.Age.Value.ToString() == query) ||
                            (x.Gender.StartsWith(query))).ToListAsync();
            }
            else
            {
                SearchCompleted = false;
                Dog = await _context.Dog.ToListAsync();
            }
        }
    }
}
