using ApplicationLayer.IServices;
using DomainLayer.Entitys;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace PresintationLayer.Controllers
{
    //[Authorize]

    [Route("api/[controller]")]
    [ApiController]
    public class BankController : ControllerBase
    {
        private readonly IBankService _bankService;
        private readonly UserManager<AppUser> _userManager;

        public BankController(IBankService bankService, UserManager<AppUser> userManager)
        {
            _bankService = bankService;
            _userManager = userManager;
        }

        [HttpPost("connect")]
        public async Task<IActionResult> ConnectBankAccount([FromBody] string bankAccountDetails)
        {
            var userId = _userManager.GetUserId(User);
            var result = await _bankService.ConnectBankAccountAsync(userId, bankAccountDetails);
            if (!result)
            {
                return BadRequest("Failed to connect bank account.");
            }
            return Ok("Bank account connected successfully.");
        }

        [HttpPost("import")]
        public async Task<IActionResult> ImportBankTransactions()
        {
            var userId = _userManager.GetUserId(User);
            var result = await _bankService.ImportBankTransactionsAsync(userId);
            if (!result)
            {
                return BadRequest("Failed to import bank transactions.");
            }
            return Ok("Bank transactions imported successfully.");
        }
    }
}
