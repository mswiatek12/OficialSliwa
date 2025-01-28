using Microsoft.AspNetCore.Mvc;

namespace OficialSliwa.dbContext
{
    public class NajlepsiZawodnicy
    {
        public int UserId { get; set; }
        public string? Imie { get; set; }
        public string? Nazwisko { get; set; }
        public int Wygrane { get; set; }
        public int Walki { get; set; }

        public float WygraneProcent { get; set; }
    }
}
