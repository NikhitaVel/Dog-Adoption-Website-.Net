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
    public class IndexModel : PageModel
    {
        private readonly Project.Data.ApplicationDbContext _context;

        public IndexModel(Project.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Dog> Dog { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Dog != null)
            {
                Dog = await _context.Dog
                .Include(d => d.CenterName).ToListAsync();
            }
        }
    }
}
