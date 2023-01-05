namespace DIDBackend.Models
{
    public class Transaction
    {
        public string TransactionId { get; set; }
        public string Description { get; set; }
        public double Amount { get; set; }
        public string CreditDebitIndicator { get; set; }
        public string Status { get; set; }
        public TransactionCode TransactionCode { get; set; }
        public object ProprietaryTransactionCode { get; set; }
        public DateTime BookingDate { get; set; }
        public MerchantDetails MerchantDetails { get; set; }
        public EnrichedData EnrichedData { get; set; }
    }

    
}
