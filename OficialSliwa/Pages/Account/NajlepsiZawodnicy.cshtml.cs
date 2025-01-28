using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OficialSliwa.dbContext;
using OficialSliwa.dbContext.ApplicationDbContext;
using OficialSliwa.dbContext.AppUser;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OficialSliwa.Pages.Statistics
{
    public class WinrateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public WinrateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<NajlepsiZawodnicy> NajlepsiZawodnicy { get; set; }

        public async Task OnGetAsync()
        {
            NajlepsiZawodnicy = await _context.NajlepsiZawodnicy
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
