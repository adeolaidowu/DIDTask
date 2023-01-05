using DIDBackend.Models;

namespace DIDBackend.Services.Interface
{
    public interface IAccountService
    {
        Task<EndOfDayBalance> GetAccountEODBalance(Customer customerInfo, DateTime date, string accountId);
        Task<Account> GetAccountById(Customer customerDetails, string accountId);
    }
}
