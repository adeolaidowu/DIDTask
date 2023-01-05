using DIDBackend.Models;
using DIDBackend.Repositories.Interface;
using System.Text.Json;

namespace DIDBackend.Repositories.Implementation
{
    public class CustomerRepository : ICustomerRepository
    {
        public async Task<Customer> GetCustomerAccountInfo()
        {
            try
            {
                string customerDetailsText = File.ReadAllText(@"./Data/apollo-carter.json");
                var customerDetails = JsonSerializer.Deserialize<Customer>(customerDetailsText, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                
                return customerDetails;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
