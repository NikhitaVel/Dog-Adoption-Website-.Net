using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Models;

namespace Project.Pages.Donations
{
    public class IndexModel : PageModel
    {
        private readonly Project.Data.ApplicationDbContext _context;

        public IndexModel(Project.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Donation> Donation { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Donation != null)
            {
                Donation = await _context.Donation
                .Include(d => d.Center)
                .Include(d => d.User).ToListAsync();
            }
        }
    }
}
