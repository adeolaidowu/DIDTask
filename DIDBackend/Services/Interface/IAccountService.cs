using DIDBackend.DTOs;
using DIDBackend.Models;

namespace DIDBackend.Services.Interface
{
    public interface IAccountService
    {
        Response<EndOfDayBalance> GetAccountEODBalance(DateTime? date, string accountId);
    }
}
