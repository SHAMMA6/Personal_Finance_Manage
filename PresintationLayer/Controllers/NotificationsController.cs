using ApplicationLayer.IServices;
using DomainLayer.Entitys;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace PresintationLayer.Controllers
{
    //[Authorize]

    [ApiController]
    [Route("api/[controller]")]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _notificationService;
        private readonly UserManager<AppUser> _userManager;

        public NotificationController(INotificationService notificationService, UserManager<AppUser> userManager)
        {
            _notificationService = notificationService;
            _userManager = userManager;
        }

        [HttpPost("setBudgetAlert")]
        public async Task<IActionResult> SetBudgetAlert([FromBody] decimal budgetLimit)
        {
            var userId = _userManager.GetUserId(User);
            var result = await _notificationService.SetBudgetAlertsAsync(userId, budgetLimit);
            if (!result)
            {
                return BadRequest("Failed to set budget alert.");
            }
            return Ok("Budget alert set successfully.");
        }

        [HttpPost("setGoalReminder")]
        public async Task<IActionResult> SetGoalReminder([FromBody] string goalName)
        {
            var userId = _userManager.GetUserId(User);
            var result = await _notificationService.SetGoalRemindersAsync(userId, goalName);
            if (!result)
            {
                return BadRequest("Failed to set goal reminder.");
            }
            return Ok("Goal reminder set successfully.");
        }

        [HttpPost("sendTransactionNotification")]
        public async Task<IActionResult> SendTransactionNotification([FromBody] string transactionDetails)
        {
            var userId = _userManager.GetUserId(User);
            var result = await _notificationService.SendTransactionNotificationAsync(userId, transactionDetails);
            if (!result)
            {
                return BadRequest("Failed to send transaction notification.");
            }
            return Ok("Transaction notification sent successfully.");
        }
    }
}
