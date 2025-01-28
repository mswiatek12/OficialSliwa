using OficialSliwa.dbContext.AppUser;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class StatystykiUzytkownika
{
    public int UserId { get; set; }
    public string? Imie { get; set; }
    public string? Nazwisko { get; set; }
    public int Walki { get; set; }
    public int Wygrane { get; set; }
    public int Przegrane { get; set; }
    public string? Osiągnięcia { get; set; }
}
