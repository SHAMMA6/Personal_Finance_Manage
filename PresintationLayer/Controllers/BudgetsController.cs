using ApplicationLayer.DTOs.BudgetDTO;
using ApplicationLayer.IServices;
using DomainLayer.Entitys;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace PresintationLayer.Controllers
{
   // [Authorize]

    [Route("api/[controller]")]
    [ApiController]
    public class BudgetsController : ControllerBase
    {
        private readonly IBudgetService _budgetService;
        private readonly UserManager<AppUser> _userManager;

        public BudgetsController(IBudgetService budgetService, UserManager<AppUser> userManager)
        {
            _budgetService = budgetService;
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> CreateBudget([FromBody] CreateBudgetDTO budgetDTO)
        {
            var userId = _userManager.GetUserId(User);
            var budget = await _budgetService.CreateBudgetAsync(budgetDTO, userId);
            return CreatedAtAction(nameof(GetBudgetById), new { id = budget.Id }, budget);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBudget(int id, [FromBody] UpdateBudgetDTO budgetDTO)
        {
            var userId = _userManager.GetUserId(User);
            budgetDTO.Id = id;
            var updatedBudget = await _budgetService.UpdateBudgetAsync(budgetDTO, userId);
            if (updatedBudget == null)
            {
                return NotFound();
            }
            return Ok(updatedBudget);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBudget(int id)
        {
            var userId = _userManager.GetUserId(User);
            var result = await _budgetService.DeleteBudgetAsync(id, userId);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBudgetById(int id)
        {
            var userId = _userManager.GetUserId(User);
            var budget = await _budgetService.GetBudgetByIdAsync(id, userId);
            if (budget == null)
            {
                return NotFound();
            }
            return Ok(budget);
        }

        [HttpGet]
        public async Task<IActionResult> GetUserBudgets()
        {
            var userId = _userManager.GetUserId(User);
            var budgets = await _budgetService.GetUserBudgetsAsync(userId);
            return Ok(budgets);
        }
    }
}
