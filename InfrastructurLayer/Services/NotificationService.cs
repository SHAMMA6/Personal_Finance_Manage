using ApplicationLayer.IServices;
using DomainLayer.Entitys;
using InfrastructurLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructurLayer.Services
{
    public class NotificationService : INotificationService
    {
        private readonly AppDbContext _context;
        private readonly IEmailService _emailService; // Assuming an email service is used for notifications

        public NotificationService(AppDbContext context, IEmailService emailService)
        {
            _context = context;
            _emailService = emailService;
        }

        public async Task<bool> SetBudgetAlertsAsync(string userId, decimal budgetLimit)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null)
            {
                return false;
            }

            var budgetAlert = new BudgetAlert
            {
                UserId = userId,
                BudgetLimit = budgetLimit,
                IsActive = true
            };

            _context.BudgetAlerts.Add(budgetAlert);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> SetGoalRemindersAsync(string userId, string goalName)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null)
            {
                return false;
            }

            var goalReminder = new GoalReminder
            {
                UserId = userId,
                GoalName = goalName,
                IsActive = true
            };

            _context.GoalReminders.Add(goalReminder);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> SendTransactionNotificationAsync(string userId, string transactionDetails)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null)
            {
                return false;
            }

            var message = $"Dear {user.UserName},\n\nA new transaction has been recorded:\n{transactionDetails}\n\nThank you,\nYour Finance App";
            await _emailService.SendEmailAsync(user.Email, "New Transaction Notification", message);

            return true;
        }
    }
}
