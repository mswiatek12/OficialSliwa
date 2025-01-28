using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OficialSliwa.dbContext.ApplicationDbContext;
using OficialSliwa.dbContext.AppUser;
using System;
using System.Linq;

namespace OficialSliwa.Pages
{
    public class UserAttendanceModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public UserAttendanceModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Sesja> Sesje { get; set; }
        public int UserId { get; set; }

        // Lista sesji, na które u¿ytkownik jest zapisany
        public List<Sesja> ZapisaneSesje { get; set; }

        public async Task<IActionResult> OnGetAsync(int userId)
        {
            UserId = userId;

            // Pobieranie dostêpnych sesji
            Sesje = await _context.Sesja.ToListAsync();

            // Pobieranie zapisanych sesji dla u¿ytkownika przez ³¹czenie tabel ObecnoscSesji i Sesja
            ZapisaneSesje = await _context.ObecnoscSesji
                .Where(os => os.UserId == userId)
                .Join(_context.Sesja,
                    os => os.SesjaId,
                    sesja => sesja.SesjaId,
                    (os, sesja) => sesja) // £¹czymy dane z tabeli Sesja
                .ToListAsync();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int sesjaId, int userId)
        {
            var obecnoscSesji = new ObecnoscSesji
            {
                SesjaId = sesjaId,
                UserId = userId
            };

            _context.ObecnoscSesji.Add(obecnoscSesji);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Account/UserAttendance", new { UserId = userId });
        }
    }

}