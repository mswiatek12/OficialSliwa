using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using OficialSliwa.dbContext.AppUser;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace OficialSliwa.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly UserManager<User> _userManager;

        public RegisterModel(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
            [Required(ErrorMessage = "Imiê jest wymagane")]
            [Display(Name = "Imiê")]
            public string? FirstName { get; set; }

            [Required(ErrorMessage = "Nazwisko jest wymagane")]
            [Display(Name = "Nazwisko")]
            public string? LastName { get; set; }

            [Required(ErrorMessage = "Email jest wymagany")]
            [EmailAddress(ErrorMessage = "Nieprawid³owy format email")]
            [Display(Name = "Email")]
            public string? Email { get; set; }

            [Required(ErrorMessage = "Has³o jest wymagane")]
            [StringLength(100, ErrorMessage = "Has³o musi mieæ przynajmniej {2} i maksymalnie {1} znaków.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Has³o")]
            public string? Password { get; set; }

            [Required(ErrorMessage = "PotwierdŸ has³o")]
            [Compare("Password", ErrorMessage = "Has³a siê nie zgadzaj¹.")]
            [DataType(DataType.Password)]
            [Display(Name = "PotwierdŸ has³o")]
            public string? ConfirmPassword { get; set; }
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            if (string.IsNullOrWhiteSpace(Input.Password))
            {
                ModelState.AddModelError("Input.Password", "Has³o jest wymagane.");
                return Page();
            }

            var user = new User
            {
                Imie = Input.FirstName,
                Nazwisko = Input.LastName,
                Email = Input.Email,
                UserName = Input.Email,
                Password = Input.Password,
                Rola = OficialSliwa.dbContext.UserRola.Zawodnik
            };

            var result = await _userManager.CreateAsync(user, Input.Password);

            if (result.Succeeded)
            {
                return RedirectToPage("/Index");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return Page();
        }
    }
}
