using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OficialSliwa.dbContext.ApplicationDbContext;
using OficialSliwa.dbContext.AppUser;
using System.Linq;
using System.Threading.Tasks;
using OficialSliwa.dbContext;
using OficialSliwa.dbContext.ApplicationDbContext;
using OficialSliwa.dbContext.AppUser;

namespace OficialSliwa.Pages.Account
{
    public class UserMembershipModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public UserMembershipModel(ApplicationDbContext context)
        {
            _context = context;
        }
        public int UserId { get; set; }

        public User? User { get; set; }
        public Czlonkostwo? UserMembership { get; set; }

        public bool HasActiveMembership => UserMembership != null && UserMembership.KoniecData > DateTime.Now;

        [BindProperty]
        public string? MembershipType { get; set; }

        [BindProperty]
        public DateTime StartDate { get; set; } = DateTime.Now;

        [BindProperty]
        public DateTime EndDate { get; set; }

        public async Task<IActionResult> OnGetAsync(int userId)
        {
            UserId = userId;

            User = await _context.Users.FindAsync(UserId);
            if (User == null)
            {
                return NotFound();
            }

            UserMembership = _context.Czlonkostwa
                .Where(m => m.UserId == UserId)
                .OrderByDescending(m => m.StartData)
                .FirstOrDefault();

            return Page();
        }

        public async Task<IActionResult> OnPostAddMembershipAsync()
        {
            if (UserMembership != null && UserMembership.KoniecData > DateTime.Now)
            {
                ModelState.AddModelError("", "User already has an active membership.");
                return Page();
            }

            var newMembership = new Czlonkostwo
            {
                UserId = UserId,
                StartData = StartDate,
                KoniecData = EndDate
            };

            _context.Czlonkostwa.Add(newMembership);
            await _context.SaveChangesAsync();

            return RedirectToPage(new { UserId = UserId });
        }
    }
}
