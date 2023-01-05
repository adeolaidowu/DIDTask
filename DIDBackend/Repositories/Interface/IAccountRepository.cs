using DIDBackend.Models;

namespace DIDBackend.Repositories.Interface
{
    public interface IAccountRepository
    {
        Task<Account> GetAccountById(Customer customerDetails, string accountId);
        Task<EndOfDayBalance> GetAccountEODBalance(Customer customerDetails, DateTime date, string accountId);
    }
}
