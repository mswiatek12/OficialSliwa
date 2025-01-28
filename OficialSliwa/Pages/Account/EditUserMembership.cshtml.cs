using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OficialSliwa.dbContext.ApplicationDbContext;
using System;
using System.Threading.Tasks;

namespace OficialSliwa.Pages.Account
{
    public class EditUserMembershipModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditUserMembershipModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public int CzlonkostwoId { get; set; }

        [BindProperty]
        public DateTime StartData { get; set; }

        [BindProperty]
        public DateTime KoniecData { get; set; }

        public async Task<IActionResult> OnGetAsync(int membershipId)
        {
            // Retrieve the membership record to edit
            var membership = await _context.Czlonkostwa.FirstOrDefaultAsync(m => m.CzlonkostwoId == membershipId);

            if (membership == null)
            {
                return NotFound(); // Return NotFound if the membership doesn't exist
            }

            // Assign membership data to model properties
            CzlonkostwoId = membership.CzlonkostwoId;
            StartData = DateTime.SpecifyKind(membership.StartData, DateTimeKind.Utc);
            KoniecData = DateTime.SpecifyKind(membership.KoniecData, DateTimeKind.Utc);

            return Page();
        }

        public async Task<IActionResult> OnPostEditMembershipAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page(); // If the form is invalid, return the page again to show validation errors
            }

            // Ensure that both dates are in UTC format
            StartData = DateTime.SpecifyKind(StartData, DateTimeKind.Utc);
            KoniecData = DateTime.SpecifyKind(KoniecData, DateTimeKind.Utc);

            // Update the membership data
            var membership = await _context.Czlonkostwa.FirstOrDefaultAsync(m => m.CzlonkostwoId == CzlonkostwoId);
            if (membership == null)
            {
                ModelState.AddModelError("", "Membership not found.");
                return Page();
            }

            // Update the membership fields
            membership.StartData = StartData;
            membership.KoniecData = KoniecData;

            // Save changes to the database
            _context.Czlonkostwa.Update(membership);
            await _context.SaveChangesAsync();

            // Redirect to the UserMembership page with the updated UserId
            return RedirectToPage("/Account/UserMembership", new { UserId = membership.UserId });
        }
    }
}
