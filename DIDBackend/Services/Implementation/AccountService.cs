using DIDBackend.DTOs;
using DIDBackend.Models;
using DIDBackend.Services.Interface;
using DIDBackend.UOW;

namespace DIDBackend.Services.Implementation
{
    public class AccountService : IAccountService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<AccountService> _logger;

        public AccountService(IUnitOfWork unitOfWork, ILogger<AccountService> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }



        public Response<EndOfDayBalance> GetAccountEODBalance(DateTime? date, string accountId)
        {
            var response = new Response<EndOfDayBalance>();
            if (!date.HasValue)
            {
                response.IsSuccess = true;
                response.Message = "A valid date must be entered";
                return response;
            }
            var customerAccount = _unitOfWork.AccountRepository.GetById(accountId);

            if (customerAccount == null)
            {
                response.Message = "Account Id does not exist";
                return response;
            }
            var lastTxnDate = customerAccount?.Transactions[0].BookingDate;

            var endDate = date == lastTxnDate ? date?.AddDays(-1) : date;

            var dailyTransactions = customerAccount?.Transactions.Where(y => y.BookingDate <= endDate)
                .GroupBy(x => Convert.ToDateTime(x.BookingDate.ToShortDateString())).OrderBy(x => x.Key).ToList();


            var eodBalance = GetEndOfDayBalance(dailyTransactions, customerAccount);

            response.IsSuccess = true;
            response.Data = eodBalance;
            return response;

        }


        private EndOfDayBalance GetEndOfDayBalance(List<IGrouping<DateTime, Transaction>> dailyTransactions, Account customerAccount)
        {

            double totalCredit = 0.00;
            double totalDebit = 0.00;
            double closingBalance = 0.00;
            var currentbalance = customerAccount.Balances.Current.Amount;
            var endOfDayBalance = new EndOfDayBalance();
            DateTime day = new DateTime();
            foreach (var transactions in dailyTransactions)
            {
                var credit = transactions.Where(x => x.CreditDebitIndicator == "Credit").Sum(x => x.Amount);
                var debit = transactions.Where(x => x.CreditDebitIndicator == "Debit").Sum(x => x.Amount);
                closingBalance = currentbalance + (credit - debit);
                totalCredit += credit;
                totalDebit += debit;
                day = transactions.Key;
                currentbalance = closingBalance;

            }
            var balance = new EndOfDayBalance()
            {
                Balance = closingBalance,
                Day = day,
                TotalCredits = totalCredit,
                TotalDebits = totalDebit
            };
            return balance;

        }



    }
}
