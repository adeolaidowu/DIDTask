using DIDBackend.Models;
using DIDBackend.Repositories.Interface;
using DIDBackend.Services.Interface;
using DIDBackend.UOW;
using System.Runtime.InteropServices;
using System.Text.Json;

namespace DIDBackend.Services.Implementation
{
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AccountService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<EndOfDayBalance> GetAccountEODBalance(Customer customerInfo, DateTime date, string accountId)
        {
            var eodBalance = await _unitOfWork.AccountRepository.GetAccountEODBalance(customerInfo, date, accountId);
            return eodBalance;
        }






        public async Task<Account> GetAccountById(Customer customerDetails, string accountId)
        {
            var account = await _unitOfWork.AccountRepository.GetAccountById(customerDetails, accountId);
            return account;
        }
    }
}
