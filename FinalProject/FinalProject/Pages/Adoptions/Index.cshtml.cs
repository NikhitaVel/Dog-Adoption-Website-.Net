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
    public class IndexModel : PageModel
    {
        private readonly Project.Data.ApplicationDbContext _context;

        public IndexModel(Project.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Adoption> Adoption { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Adoption != null)
            {
                Adoption = await _context.Adoption
                .Include(a => a.Center)
                .Include(a => a.Dog)
                .Include(a => a.User).ToListAsync();
            }
        }
    }
}
