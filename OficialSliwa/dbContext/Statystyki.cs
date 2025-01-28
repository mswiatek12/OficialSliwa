using OficialSliwa.dbContext.AppUser;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Statystyki
{
    [Key]
    public int StatystykiId { get; set; }


    public int UserId { get; set; }
    public int Walki { get; set; } = 0;
    public int Wygrane { get; set; } = 0;
    public int Przegrane { get; set; } = 0;
    public string? Osiagniecia { get; set; }
}
