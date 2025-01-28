using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using OficialSliwa.dbContext.ApplicationDbContext;
using OficialSliwa.dbContext.AppUser;
using System.Threading.Tasks;

namespace OficialSliwa.Pages.Account
{
    public class UserStatisticsEditModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public UserStatisticsEditModel(ApplicationDbContext context)
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
                return NotFound();
            }

            UserStatistics = await _context.StatystykiUzytkownika.FirstOrDefaultAsync(s => s.UserId == userId);

            if (UserStatistics == null)
            {
                // Initialize UserStatistics if it doesn't exist
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Console.WriteLine($"Walki: {UserStatistics.Walki}, Wygrane: {UserStatistics.Wygrane}, Przegrane: {UserStatistics.Przegrane}, Osi¹gniêcia: {UserStatistics.Osi¹gniêcia}");

            if (string.IsNullOrEmpty(UserStatistics.Osi¹gniêcia))
            {
                UserStatistics.Osi¹gniêcia = "Brak";
            }

            var sqlUpdateQuery = @"
            UPDATE statystyki
            SET walki = @TotalMatches, 
                wygrane = @Wins, 
                przegrane = @Losses, 
                osi¹gniêcia = @Achievements
            WHERE user_id = @UserId";

            var achievementsParameter = new NpgsqlParameter("@Achievements", NpgsqlTypes.NpgsqlDbType.Text)
            {
                Value = UserStatistics.Osi¹gniêcia ?? (object)DBNull.Value // Handle null values explicitly
            };

            var updateResult = await _context.Database.ExecuteSqlRawAsync(
                sqlUpdateQuery,
                new NpgsqlParameter("@TotalMatches", UserStatistics.Walki),
                new NpgsqlParameter("@Wins", UserStatistics.Wygrane),
                new NpgsqlParameter("@Losses", UserStatistics.Przegrane),
                achievementsParameter, // Use the properly handled parameter
                new NpgsqlParameter("@UserId", UserStatistics.UserId)
            );

            // If no records were updated, insert a new one
            if (updateResult == 0)
            {
                var sqlInsertQuery = @"
                INSERT INTO statystyki (user_id, walki, wygrane, przegrane, osi¹gniêcia)
                VALUES (@UserId, @TotalMatches, @Wins, @Losses, @Achievements)";

                await _context.Database.ExecuteSqlRawAsync(
                    sqlInsertQuery,
                    new NpgsqlParameter("@UserId", UserStatistics.UserId),
                    new NpgsqlParameter("@TotalMatches", UserStatistics.Walki),
                    new NpgsqlParameter("@Wins", UserStatistics.Wygrane),
                    new NpgsqlParameter("@Losses", UserStatistics.Przegrane),
                    new NpgsqlParameter("@Achievements", UserStatistics.Osi¹gniêcia)
                );
            }

            return RedirectToPage("/Account/UserStatistics", new { UserId = UserStatistics.UserId });
        }

    }
}
