using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OficialSliwa.dbContext;
using OficialSliwa.dbContext.ApplicationDbContext;

namespace OficialSliwa.Pages.Account
{
    public class AktywneUrazy : PageModel
    {
        private readonly ApplicationDbContext _context;

        public AktywneUrazy(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<AktywneUrazyViewModel> AktywneUrazy2 { get; set; }

        public async Task OnGetAsync()
        {
            AktywneUrazy2 = await _context.AktywneUrazy.ToListAsync();
        }
    }
}
