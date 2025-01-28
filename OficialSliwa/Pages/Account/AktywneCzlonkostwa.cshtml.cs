using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OficialSliwa.dbContext;
using OficialSliwa.dbContext.ApplicationDbContext;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OficialSliwa.Pages.Account
{
    public class AktywneCzlonkostwaModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public AktywneCzlonkostwaModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<AktywneCzlonkostwaViewModel> AktywneCzlonkostwa { get; set; }

        public async Task OnGetAsync()
        {
            AktywneCzlonkostwa = await _context.AktywneCzlonkostwa
                .FromSqlRaw("SELECT * FROM aktywne_czlonkostwa")
                .ToListAsync();
        }
    }
}
