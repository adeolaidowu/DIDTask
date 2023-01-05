namespace DIDBackend.Models
{
    public class EndOfDayBalance
    {
        public DateTime Day { get; set; }
        public double Balance { get; set; }
        public double TotalCredits { get; set; }
        public double TotalDebits { get; set; }
    }
}