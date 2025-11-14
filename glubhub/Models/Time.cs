namespace glubhub.Models
{
    public class Time
    {
        public DateTime Date { get; set; }
        public string Season { get; set; }
        public DateTime Time1 { get; set; }
        public Time(DateTime date, string season, DateTime time)
        {
            Date = date;
            Season = season;
            Time1 = time;
        }
    }
}
