namespace DIDBackend.Models
{
    public class Customer
    {
        public string ProviderName { get; set; }
        public string CountryCode { get; set; }
        public List<Account> Accounts { get; set; }
    }
}
