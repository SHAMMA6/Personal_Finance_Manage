using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.IServices
{
    public interface INotificationService
    {
        Task<bool> SetBudgetAlertsAsync(string userId, decimal budgetLimit);
        Task<bool> SetGoalRemindersAsync(string userId, string goalName);
        Task<bool> SendTransactionNotificationAsync(string userId, string transactionDetails);
    }
}
