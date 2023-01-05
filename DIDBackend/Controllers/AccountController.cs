
using DIDBackend.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace DIDBackend.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly ICustomerService _customerService;

        public AccountController(IAccountService accountService, ICustomerService customerService)
        {
            _accountService = accountService;
            _customerService = customerService;
        }

        [HttpGet("{accountId}/balance")]
        public async Task<IActionResult> GetBalanceByDate(string accountId, [FromQuery] DateTime date)
        {
            
            var customerAccountDetails = await _customerService.GetCustomerAccountInfo(); 
            var result = _accountService.GetAccountEODBalance(customerAccountDetails, date, accountId);
            if (result == null) return NoContent();
            return Ok(result);
        }
    }
}