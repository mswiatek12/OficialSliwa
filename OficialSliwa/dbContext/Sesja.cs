public class Sesja
{
    public int SesjaId { get; set; }
    public string? SesjaNazwa { get; set; }
    public DateTime SesjaData { get; set; }
    public int StartGodzina { get; set; }
    public DayOfWeek DayOfWeek => SesjaData.DayOfWeek;
}
