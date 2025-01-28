using Microsoft.AspNetCore.Identity;
using OficialSliwa.dbContext;

namespace OficialSliwa.dbContext.AppUser
{
    public class User : IdentityUser<int>
    {
        public string? Imie { get; set; }
        public string? Nazwisko { get; set; }
        public string? Password { get; set; }
        public UserRola Rola { get; set; }
        public DateTime DataRejestracji { get; set; } = DateTime.Now.ToUniversalTime();

        public int OpuszczoneZajecia { get; set; } = 0;
    }
}