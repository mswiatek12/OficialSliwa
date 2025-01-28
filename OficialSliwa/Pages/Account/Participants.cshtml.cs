using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using OficialSliwa.dbContext.ApplicationDbContext;
using OficialSliwa.dbContext;

namespace OficialSliwa.Pages.Account
{
    public class ParticipantsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public ParticipantsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Zawodnicy> Participants { get; set; }

        public async Task OnGetAsync()
        {
            Participants = await _context.Zawodnicy
                .FromSqlRaw("SELECT * FROM zawodnicy")
                .ToListAsync();
        }
    }
}
