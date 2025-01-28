using OficialSliwa.dbContext.AppUser;
using OficialSliwa.dbContext;
namespace OficialSliwa.dbContext
{
    public class Czlonkostwo
    {
        public int CzlonkostwoId { get; set; }
        public int UserId { get; set; }
        public DateTime StartData { get; set; }
        public DateTime KoniecData { get; set; }
    }
}