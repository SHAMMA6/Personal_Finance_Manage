using ApplicationLayer.DTOs.FinancialGoalDTO;
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
    public class FinancialGoalService : IFinancialGoalService
    {
        private readonly AppDbContext _context;

        public FinancialGoalService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<FinancialGoalDTO> CreateFinancialGoalAsync(CreateFinancialGoalDTO goalDTO, string userId)
        {
            var goal = new FinancialGoal
            {
                GoalName = goalDTO.GoalName,
                TargetAmount = goalDTO.TargetAmount,
                TargetDate = goalDTO.TargetDate,
                CurrentAmount = 0, // Initially, the current amount is 0
                UserId = userId
            };

            _context.FinancialGoals.Add(goal);
            await _context.SaveChangesAsync();

            return new FinancialGoalDTO
            {
                Id = goal.Id,
                GoalName = goal.GoalName,
                TargetAmount = goal.TargetAmount,
                CurrentAmount = goal.CurrentAmount,
                TargetDate = goal.TargetDate
            };
        }

        public async Task<FinancialGoalDTO> UpdateFinancialGoalAsync(UpdateFinancialGoalDTO goalDTO, string userId)
        {
            var goal = await _context.FinancialGoals
                .FirstOrDefaultAsync(g => g.Id == goalDTO.Id && g.UserId == userId);

            if (goal == null)
            {
                return null;
            }

            goal.GoalName = goalDTO.GoalName;
            goal.TargetAmount = goalDTO.TargetAmount;
            goal.CurrentAmount = goalDTO.CurrentAmount;
            goal.TargetDate = goalDTO.TargetDate;

            _context.FinancialGoals.Update(goal);
            await _context.SaveChangesAsync();

            return new FinancialGoalDTO
            {
                Id = goal.Id,
                GoalName = goal.GoalName,
                TargetAmount = goal.TargetAmount,
                CurrentAmount = goal.CurrentAmount,
                TargetDate = goal.TargetDate
            };
        }

        public async Task<bool> DeleteFinancialGoalAsync(int id, string userId)
        {
            var goal = await _context.FinancialGoals
                .FirstOrDefaultAsync(g => g.Id == id && g.UserId == userId);

            if (goal == null)
            {
                return false;
            }

            _context.FinancialGoals.Remove(goal);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<FinancialGoalDTO> GetFinancialGoalByIdAsync(int id, string userId)
        {
            var goal = await _context.FinancialGoals
                .FirstOrDefaultAsync(g => g.Id == id && g.UserId == userId);

            if (goal == null)
            {
                return null;
            }

            return new FinancialGoalDTO
            {
                Id = goal.Id,
                GoalName = goal.GoalName,
                TargetAmount = goal.TargetAmount,
                CurrentAmount = goal.CurrentAmount,
                TargetDate = goal.TargetDate
            };
        }

        public async Task<IEnumerable<FinancialGoalDTO>> GetUserFinancialGoalsAsync(string userId)
        {
            return await _context.FinancialGoals
                .Where(g => g.UserId == userId)
                .Select(g => new FinancialGoalDTO
                {
                    Id = g.Id,
                    GoalName = g.GoalName,
                    TargetAmount = g.TargetAmount,
                    CurrentAmount = g.CurrentAmount,
                    TargetDate = g.TargetDate
                })
                .ToListAsync();
        }
    }
}
