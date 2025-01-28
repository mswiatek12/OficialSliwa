using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OficialSliwa.dbContext;
using System.Collections.Generic;
using System.Threading.Tasks;
using OficialSliwa.dbContext.ApplicationDbContext;

namespace OficialSliwa.Pages.Account
{
    public class NajaktywniejsiZawodnicyModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public NajaktywniejsiZawodnicyModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<NajaktywniejsiZawodnicy> NajaktywniejsiZawodnicy { get; set; }

        public async Task OnGetAsync()
        {
            NajaktywniejsiZawodnicy = await _context.NajaktywniejsiZawodnicy
                .FromSqlRaw("SELECT * FROM najaktywniejsi_zawodnicy")
                .ToListAsync();
        }
    }
}
