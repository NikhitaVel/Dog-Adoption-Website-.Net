using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Project.Data;
using Project.Models;

namespace Project.Pages
{
    public class StatsModel : PageModel
    {
        private readonly Project.Data.ApplicationDbContext _context;

        public StatsModel(Project.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Donation> Donation { get; set; } = default!;
        public IList<Adoption> Adoption { get; set; } = default!;
        public IList<User> User { get; set; } = default!;


        public int TotalNumDonations { get; set; }
        public decimal? TotalAmount { get; set; }
        public int TotalAdoptions { get; set; }
        public int TotalUsers { get; set; }

        public async Task OnGetAsync()
        {
            if (_context.Donation != null && _context.Adoption != null && _context.User != null)
            {
                Donation = await _context.Donation
                .Include(d => d.Center)
                .Include(d => d.User).ToListAsync();

                Adoption = await _context.Adoption.Include(d => d.Center)
                .Include(d => d.User).ToListAsync();

                User = await _context.User.ToListAsync();

                TotalNumDonations = await _context.Donation.CountAsync();
                TotalAmount = await _context.Donation.SumAsync(x => x.Amount);
                TotalAdoptions = await _context.Adoption.CountAsync();
                TotalUsers = await _context.User.CountAsync();
            }
        }
    }
}
