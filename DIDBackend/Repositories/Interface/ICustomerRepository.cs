using DIDBackend.Models;

namespace DIDBackend.Repositories.Interface
{
    public interface ICustomerRepository
    {
        Task<Customer> GetCustomerAccountInfo();
    }
}
