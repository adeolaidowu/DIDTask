using DIDBackend.Models;
using DIDBackend.Repositories.Interface;

namespace DIDBackend.Repositories.Implementation
{
    public class AccountRepository : IAccountRepository
    {
        
        public async Task<Account> GetAccountById(Customer customerDetails, string accountId)
        {
            var account = customerDetails.Accounts?.SingleOrDefault(x => x.AccountId == accountId);

            await Task.CompletedTask; 

            return account;
        }

        public async Task<EndOfDayBalance> GetAccountEODBalance(Customer customerDetails, DateTime date, string accountId)
        {
            try
            {
                var customerAccount = await GetAccountById(customerDetails, accountId);
                var lastTxnDate = customerAccount?.Transactions[0].BookingDate;

                var endDate = date == lastTxnDate ? date.AddDays(-1) : date;

                var dailyTransactions = customerAccount?.Transactions.Where(y => y.BookingDate <= endDate)
                    .GroupBy(x => Convert.ToDateTime(x.BookingDate.ToShortDateString())).OrderBy(x => x.Key).ToList();

                var currentbalance = customerDetails.Accounts[0].Balances.Current.Amount;

                var eodBalance = GetEndOfDayBalance(dailyTransactions, currentbalance);

                return eodBalance;
            }
            catch (Exception)
            {

                throw;
            }
        }

        private double RoundToTwoDP(double value)
        {
            return Math.Round(value, 2, MidpointRounding.AwayFromZero);
        }

        private EndOfDayBalance GetEndOfDayBalance(List<IGrouping<DateTime, Transaction>> dailyTransactions, double currentBalance)
        {
            try
            {
                double totalCredit = 0.00;
                double totalDebit = 0.00;
                double closingBalance = 0.00;
                var endOfDayBalance = new EndOfDayBalance();

                DateTime day = new DateTime();
                foreach (var transactions in dailyTransactions)
                {
                    var credit = transactions.Where(x => x.CreditDebitIndicator == "Credit").Sum(x => x.Amount);
                    var debit = transactions.Where(x => x.CreditDebitIndicator == "Debit").Sum(x => x.Amount);
                    closingBalance = currentBalance + credit - debit;
                    totalCredit += credit;
                    totalDebit += debit;
                    day = transactions.Key;
                    currentBalance = closingBalance;

                }
                var balance = new EndOfDayBalance()
                {
                    Balance = RoundToTwoDP(closingBalance),
                    Day = day,
                    TotalCredits = RoundToTwoDP(totalCredit),
                    TotalDebits = RoundToTwoDP(totalDebit)
                };
                return balance;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
