using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OficialSliwa.dbContext.ApplicationDbContext;
using OficialSliwa.dbContext.AppUser;
using System;
using System.Threading.Tasks;

namespace OficialSliwa.Pages.Account
{
    public class UserStatisticsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public UserStatisticsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public User User { get; set; }

        [BindProperty]
        public StatystykiUzytkownika UserStatistics { get; set; }

        public async Task<IActionResult> OnGetAsync(int userId)
        {
            User = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);

            if (User == null)
            {
                return NotFound("User not found");
            }

            UserStatistics = await _context.StatystykiUzytkownika.FirstOrDefaultAsync(s => s.UserId == userId);

            if (UserStatistics == null)
            {
                UserStatistics = new StatystykiUzytkownika
                {
                    UserId = userId,
                    Walki = 0,
                    Wygrane = 0,
                    Przegrane = 0,
                    Osi¹gniêcia = "Brak"
                };
            }

            return Page();
        }
    }
}
