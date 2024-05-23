using ApplicationLayer.DTOs.BudgetDTO;
using ApplicationLayer.IServices;
using DomainLayer.Entitys;
using InfrastructurLayer.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructurLayer.Services
{
    public class BudgetService : IBudgetService
    {
        private readonly AppDbContext _context;

        public BudgetService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<BudgetDTO> CreateBudgetAsync(CreateBudgetDTO budgetDTO, string userId)
        {
            var budget = new Budget
            {
                Category = budgetDTO.Category,
                Limit = budgetDTO.Limit,
                StartDate = budgetDTO.StartDate,
                EndDate = budgetDTO.EndDate,
                UserId = userId
            };

            _context.Budgets.Add(budget);
            await _context.SaveChangesAsync();

            return new BudgetDTO
            {
                Id = budget.Id,
                Category = budget.Category,
                Limit = budget.Limit,
                StartDate = budget.StartDate,
                EndDate = budget.EndDate
            };
        }

        public async Task<BudgetDTO> UpdateBudgetAsync(UpdateBudgetDTO budgetDTO, string userId)
        {
            var budget = await _context.Budgets
                .FirstOrDefaultAsync(b => b.Id == budgetDTO.Id && b.UserId == userId);

            if (budget == null)
            {
                return null;
            }

            budget.Category = budgetDTO.Category;
            budget.Limit = budgetDTO.Limit;
            budget.StartDate = budgetDTO.StartDate;
            budget.EndDate = budgetDTO.EndDate;

            _context.Budgets.Update(budget);
            await _context.SaveChangesAsync();

            return new BudgetDTO
            {
                Id = budget.Id,
                Category = budget.Category,
                Limit = budget.Limit,
                StartDate = budget.StartDate,
                EndDate = budget.EndDate
            };
        }

        public async Task<bool> DeleteBudgetAsync(int id, string userId)
        {
            var budget = await _context.Budgets
                .FirstOrDefaultAsync(b => b.Id == id && b.UserId == userId);

            if (budget == null)
            {
                return false;
            }

            _context.Budgets.Remove(budget);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<BudgetDTO> GetBudgetByIdAsync(int id, string userId)
        {
            var budget = await _context.Budgets
                .FirstOrDefaultAsync(b => b.Id == id && b.UserId == userId);

            if (budget == null)
            {
                return null;
            }

            return new BudgetDTO
            {
                Id = budget.Id,
                Category = budget.Category,
                Limit = budget.Limit,
                StartDate = budget.StartDate,
                EndDate = budget.EndDate
            };
        }

        public async Task<IEnumerable<BudgetDTO>> GetUserBudgetsAsync(string userId)
        {
            return await _context.Budgets
                .Where(b => b.UserId == userId)
                .Select(b => new BudgetDTO
                {
                    Id = b.Id,
                    Category = b.Category,
                    Limit = b.Limit,
                    StartDate = b.StartDate,
                    EndDate = b.EndDate
                })
                .ToListAsync();
        }
    }
}
