using DIDBackend.Repositories.Implementation;
using DIDBackend.Repositories.Interface;

namespace DIDBackend.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        public IAccountRepository AccountRepository => new AccountRepository();

        public ICustomerRepository CustomerRepository => new CustomerRepository();
    }
}
