namespace DIDBackend.Models
{
    public class Available
    {
        public double Amount { get; set; }
        public string CreditDebitIndicator { get; set; }
        public List<object> CreditLines { get; set; }
    }
}
