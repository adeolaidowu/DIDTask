namespace DIDBackend.Models
{
    public class Current
    {
        public double Amount { get; set; }
        public string CreditDebitIndicator { get; set; }
        public List<object> CreditLines { get; set; }
    }
}
