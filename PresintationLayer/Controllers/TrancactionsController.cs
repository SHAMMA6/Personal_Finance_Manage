using ApplicationLayer.DTOs.TransactionDTOs;
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
    public class TrancactionsController : ControllerBase
    {
        private readonly ITransactionService _transactionService;
        private readonly UserManager<AppUser> _userManager;

        public TrancactionsController(ITransactionService transactionService, UserManager<AppUser> userManager)
        {
            _transactionService = transactionService;
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> AddTransaction([FromBody] CreateTransactionDTO transactionDTO)
        {
            var userId = _userManager.GetUserId(User);
            var transaction = await _transactionService.AddTransactionAsync(transactionDTO, userId);
            return CreatedAtAction(nameof(GetTransactionById), new { id = transaction.Id }, transaction);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTransaction(int id, [FromBody] UpdateTransactionDTO transactionDTO)
        {
            var userId = _userManager.GetUserId(User);
            transactionDTO.Id = id;
            var updatedTransaction = await _transactionService.UpdateTransactionAsync(transactionDTO, userId);
            if (updatedTransaction == null)
            {
                return NotFound();
            }
            return Ok(updatedTransaction);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTransaction(int id)
        {
            var userId = _userManager.GetUserId(User);
            var result = await _transactionService.DeleteTransactionAsync(id, userId);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTransactionById(int id)
        {
            var userId = _userManager.GetUserId(User);
            var transaction = await _transactionService.GetTransactionByIdAsync(id, userId);
            if (transaction == null)
            {
                return NotFound();
            }
            return Ok(transaction);
        }

        [HttpGet]
        public async Task<IActionResult> GetUserTransactions()
        {
            var userId = _userManager.GetUserId(User);
            var transactions = await _transactionService.GetUserTransactionsAsync(userId);
            return Ok(transactions);
        }
    }
}
