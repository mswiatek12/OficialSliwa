using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OficialSliwa.dbContext.ApplicationDbContext;
using OficialSliwa.dbContext.AppUser;
using System;
using OficialSliwa.dbContext;
using Microsoft.EntityFrameworkCore;

namespace OficialSliwa.Pages.Account
{
    public class InjuryRegisterModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public InjuryRegisterModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty(SupportsGet = true)]
        public int UserId { get; set; }

        public User User { get; set; }
        public List<Uraz> Injuries { get; set; }

        [BindProperty]
        public string Description { get; set; }
        [BindProperty]
        public bool Status { get; set; }
        [BindProperty]
        public DateTime InjuryDate { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            User = await _context.Users.FindAsync(UserId);
            if (User == null)
            {
                return NotFound();
            }

            Injuries = _context.Urazy
                .Where(i => i.UserId == UserId)
                .OrderByDescending(i => i.UrazData)
                .ToList();

            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            var injury = new Uraz
            {
                UserId = UserId,
                Opis = Description,
                Status = Status,
                UrazData = InjuryDate.ToUniversalTime()
            };

            _context.Urazy.Add(injury);
            await _context.SaveChangesAsync();

            return RedirectToPage(new { UserId = UserId });
        }
    }
}
