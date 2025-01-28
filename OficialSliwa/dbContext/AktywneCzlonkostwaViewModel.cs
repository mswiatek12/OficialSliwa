namespace OficialSliwa.dbContext
{
    public class AktywneCzlonkostwaViewModel
    {
        public int CzlonkostwoId { get; set; }
        public int UserId { get; set; }
        public string? Imie { get; set; }
        public DateTime StartData { get; set; }
        public DateTime KoniecData { get; set; }
    }
}