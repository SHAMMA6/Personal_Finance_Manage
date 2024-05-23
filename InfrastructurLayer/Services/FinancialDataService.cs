using ApplicationLayer.DTOs.FinancialDataDTO;
using ApplicationLayer.IServices;
using InfrastructurLayer.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructurLayer.Services
{
    public class FinancialDataService : IFinancialDataService
    {
        private readonly AppDbContext _context;

        public FinancialDataService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<FinancialDataDTO> GetUserFinancialDataAsync(string userId)
        {
            var transactions = await _context.Transactions
                .Where(t => t.UserId == userId)
                .ToListAsync();

            var totalIncome = transactions.Where(t => t.Type == "Income").Sum(t => t.Amount);
            var totalExpense = transactions.Where(t => t.Type == "Expense").Sum(t => t.Amount);

            return new FinancialDataDTO
            {
                TotalIncome = totalIncome,
                TotalExpense = totalExpense,
                Balance = totalIncome - totalExpense,
                Transactions = transactions.Select(t => new TransactionDataDTO
                {
                    Id = t.Id,
                    Type = t.Type,
                    Amount = t.Amount,
                    Category = t.Category,
                    Date = t.Date
                }).ToList()
            };
        }
    }
}
