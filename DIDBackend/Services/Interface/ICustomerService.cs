using DIDBackend.Models;

namespace DIDBackend.Services.Interface
{
    public interface ICustomerService
    {
        Task<Customer> GetCustomerAccountInfo();
    }
}
