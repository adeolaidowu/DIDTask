using DIDBackend.Models;

namespace DIDBackend.Data
{
    public static class DataStore
    {
        public static string ProviderName { get; set; }
        public static string CountryCode { get; set; }

        public static List<Account> Accounts { get; set; } = new List<Account>();

    }
}
