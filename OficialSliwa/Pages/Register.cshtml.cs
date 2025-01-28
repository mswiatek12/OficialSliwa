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
            [Required(ErrorMessage = "Imi� jest wymagane")]
            [Display(Name = "Imi�")]
            public string? FirstName { get; set; }

            [Required(ErrorMessage = "Nazwisko jest wymagane")]
            [Display(Name = "Nazwisko")]
            public string? LastName { get; set; }

            [Required(ErrorMessage = "Email jest wymagany")]
            [EmailAddress(ErrorMessage = "Nieprawid�owy format email")]
            [Display(Name = "Email")]
            public string? Email { get; set; }

            [Required(ErrorMessage = "Has�o jest wymagane")]
            [StringLength(100, ErrorMessage = "Has�o musi mie� przynajmniej {2} i maksymalnie {1} znak�w.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Has�o")]
            public string? Password { get; set; }

            [Required(ErrorMessage = "Potwierd� has�o")]
            [Compare("Password", ErrorMessage = "Has�a si� nie zgadzaj�.")]
            [DataType(DataType.Password)]
            [Display(Name = "Potwierd� has�o")]
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
                ModelState.AddModelError("Input.Password", "Has�o jest wymagane.");
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
