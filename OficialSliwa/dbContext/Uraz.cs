using OficialSliwa.dbContext.AppUser;
using OficialSliwa.dbContext;

namespace OficialSliwa.dbContext
{
    public class Uraz
    {
        public int UrazId { get; set; }
        public int UserId { get; set; }
        public DateTime UrazData { get; set; }
        public string? Opis { get; set; }
        public bool Status { get; set; }
    }
}
