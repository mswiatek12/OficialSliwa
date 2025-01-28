using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OficialSliwa.dbContext.ApplicationDbContext;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OficialSliwa.Pages
{
    public class ClassesModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public ClassesModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Sesja> Sesje { get; set; }
        public Dictionary<DayOfWeek, List<Sesja>> Schedule { get; set; }

        public async Task OnGetAsync()
        {
            Sesje = await _context.Sesja.ToListAsync();

            Schedule = Sesje
                .GroupBy(s => s.SesjaData.DayOfWeek)
                .ToDictionary(
                    g => g.Key,
                    g => g.OrderBy(s => s.StartGodzina).ToList()
                );
        }
    }
}
