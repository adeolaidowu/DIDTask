using DIDBackend.Models;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace DIDBackend.Data
{
    public class Seeder
    {
        private static readonly string _jsonFile = "Data/apollo-carter.json";
        public static void SeedData()
        {
            var baseDir = Directory.GetCurrentDirectory();
            var path = FilePath(baseDir, _jsonFile);
            var readData = File.ReadAllText(path);

            var store = JsonConvert.DeserializeObject<Customer>(readData);
            SetDataStore(store);
        }
        static void SetDataStore(Customer? customer)
        {
            if(customer == null) return;

            DataStore.ProviderName = customer.ProviderName;
            DataStore.CountryCode = customer.CountryCode;
            DataStore.Accounts = customer.Accounts;
        }
        static string FilePath(string folderName, string fileName) 
            => Path.Combine(folderName, fileName);

    }
}
