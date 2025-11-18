namespace glubhub.Models
{
    public class Time
    {
        public DateTime Date { get; set; }
        public Season Season { get; set; }
        public DateTime Time1 { get; set; }

        public int TimeId { get; set; }

        public Time()
        {
        }

        public Time(DateTime date, Season season, DateTime time, int timeId)
        {
            Date = date;
            Season = season;
            Time1 = time;
            TimeId = timeId;
        }
    }
}
