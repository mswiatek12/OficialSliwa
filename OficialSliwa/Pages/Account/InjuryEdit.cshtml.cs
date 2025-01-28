using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using OficialSliwa.dbContext.ApplicationDbContext;
using OficialSliwa.dbContext.AppUser;
using System;
using System.Threading.Tasks;

namespace OficialSliwa.Pages.Account
{
    public class InjuryEditModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public InjuryEditModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public int InjuryId { get; set; }

        [BindProperty]
        public string Description { get; set; }

        [BindProperty]
        public bool Status { get; set; }

        [BindProperty]
        public DateTime InjuryDate { get; set; }

        public async Task<IActionResult> OnGetAsync(int injuryId)
        {
            InjuryId = injuryId;

            var injuryQuery = "SELECT uraz_id, user_id, opis, status, uraz_data FROM urazy WHERE uraz_id = @InjuryId LIMIT 1";

            var injury = await _context.Urazy.FromSqlRaw(injuryQuery, new NpgsqlParameter("@InjuryId", InjuryId)).FirstOrDefaultAsync();

            if (injury == null)
            {
                return NotFound();
            }

            Description = injury.Opis;
            Status = injury.Status;
            InjuryDate = injury.UrazData;

            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Console.WriteLine($"Status value received: {Status}");

            string updateQuery = @"
            UPDATE urazy
                SET opis = @Description, status = @Status, uraz_data = @InjuryDate
                WHERE uraz_id = @InjuryId;
            ";

            var parameters = new[]
            {
                new NpgsqlParameter("@Description", NpgsqlTypes.NpgsqlDbType.Text) { Value = Description },
                new NpgsqlParameter("@Status", NpgsqlTypes.NpgsqlDbType.Boolean) { Value = Status },
                new NpgsqlParameter("@InjuryDate", NpgsqlTypes.NpgsqlDbType.Timestamp) { Value = InjuryDate },
                new NpgsqlParameter("@InjuryId", NpgsqlTypes.NpgsqlDbType.Integer) { Value = InjuryId }
            };

            var result = await _context.Database.ExecuteSqlRawAsync(updateQuery, parameters);

            if (result == 0)
            {
                return NotFound();
            }

            var updatedInjury = await _context.Urazy
                .Where(i => i.UrazId == InjuryId)
                .FirstOrDefaultAsync();

            if (updatedInjury == null)
            {
                return NotFound();
            }

            return RedirectToPage("/Account/InjuryRegister", new { UserId = updatedInjury.UserId });
        }

    }
}
