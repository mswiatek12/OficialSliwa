namespace OficialSliwa.dbContext
{
    public class AktywneUrazyViewModel
    {
        public int UrazId { get; set; }
        public int UserId { get; set; }
        public string? Imie { get; set; }
        public string? Nazwisko { get; set; }

        public DateTime UrazData { get; set; }
        public string? Opis { get; set; }  
    }
}
