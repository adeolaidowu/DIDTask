using DIDBackend.Data;
using DIDBackend.Models;
using DIDBackend.Repositories.Interface;

namespace DIDBackend.Repositories.Implementation
{
    public class AccountRepository : IAccountRepository
    {
        public Account GetById(string accountId)
            => DataStore.Accounts.SingleOrDefault(x => x.AccountId == accountId);       
    }
}
