using ApplicationLayer.DTOs.FinancialGoalDTO;
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
    public class FinancialGoalsController : ControllerBase
    {
        private readonly IFinancialGoalService _goalService;
        private readonly UserManager<AppUser> _userManager;

        public FinancialGoalsController(IFinancialGoalService goalService, UserManager<AppUser> userManager)
        {
            _goalService = goalService;
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> CreateGoal([FromBody] CreateFinancialGoalDTO goalDTO)
        {
            var userId = _userManager.GetUserId(User);
            var goal = await _goalService.CreateFinancialGoalAsync(goalDTO, userId);
            return CreatedAtAction(nameof(GetGoalById), new { id = goal.Id }, goal);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGoal(int id, [FromBody] UpdateFinancialGoalDTO goalDTO)
        {
            var userId = _userManager.GetUserId(User);
            goalDTO.Id = id;
            var updatedGoal = await _goalService.UpdateFinancialGoalAsync(goalDTO, userId);
            if (updatedGoal == null)
            {
                return NotFound();
            }
            return Ok(updatedGoal);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGoal(int id)
        {
            var userId = _userManager.GetUserId(User);
            var result = await _goalService.DeleteFinancialGoalAsync(id, userId);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetGoalById(int id)
        {
            var userId = _userManager.GetUserId(User);
            var goal = await _goalService.GetFinancialGoalByIdAsync(id, userId);
            if (goal == null)
            {
                return NotFound();
            }
            return Ok(goal);
        }

        [HttpGet]
        public async Task<IActionResult> GetUserGoals()
        {
            var userId = _userManager.GetUserId(User);
            var goals = await _goalService.GetUserFinancialGoalsAsync(userId);
            return Ok(goals);
        }
    }
}
