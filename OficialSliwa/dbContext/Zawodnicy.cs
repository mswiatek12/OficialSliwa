using OficialSliwa.dbContext.AppUser;
using OficialSliwa.dbContext;

namespace OficialSliwa.dbContext
{
    public class Zawodnicy
    {
        public int UserId { get; set; }
        public string? Imie { get; set; }
        public string? Nazwisko { get; set; }
        public string? Email { get; set; }
    }
}
