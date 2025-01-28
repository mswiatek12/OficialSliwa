using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OficialSliwa.dbContext;
using OficialSliwa.dbContext.ApplicationDbContext;
using OficialSliwa.dbContext;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OficialSliwa.Pages.Account
{
    public class WieleUrazowModelPage : PageModel
    {
        private readonly ApplicationDbContext _context;

        public WieleUrazowModelPage(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<WieleUrazow> UsersWithMultipleInjuries { get; set; }

        public async Task OnGetAsync()
        {
            UsersWithMultipleInjuries = await _context.WieleUrazow.AsNoTracking().ToListAsync();
        }
    }
}
