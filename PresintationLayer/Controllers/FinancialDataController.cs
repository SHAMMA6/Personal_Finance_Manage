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
    public class FinancialDataController : ControllerBase
    {
        private readonly IFinancialDataService _financialDataService;
        private readonly UserManager<AppUser> _userManager;

        public FinancialDataController(IFinancialDataService financialDataService, UserManager<AppUser> userManager)
        {
            _financialDataService = financialDataService;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetUserFinancialData()
        {
            var userId = _userManager.GetUserId(User);
            var financialData = await _financialDataService.GetUserFinancialDataAsync(userId);
            return Ok(financialData);
        }
    }
}
