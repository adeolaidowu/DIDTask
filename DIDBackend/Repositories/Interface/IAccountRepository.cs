using DIDBackend.Models;

namespace DIDBackend.Repositories.Interface
{
    public interface IAccountRepository
    {
        Account GetById(string accountId);
        //Task<EndOfDayBalance> GetAccountEODBalance(Customer customerDetails, DateTime date, string accountId);
    }
}
