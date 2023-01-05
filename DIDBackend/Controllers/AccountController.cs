
using DIDBackend.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace DIDBackend.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet("{accountId}/balance")]
        public async Task<IActionResult> GetBalance(string accountId, [FromQuery] DateTime? date)
        {
            
            var result = _accountService.GetAccountEODBalance(date, accountId);
            if (result == null) return NoContent();
            return Ok(result);
        }
    }
}