using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Entitys
{
    public class AppUser : IdentityUser
    {
        public string Name { get; set; }
        public string BankAccountDetails { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
        public virtual ICollection<Budget> Budgets { get; set; }
        public virtual ICollection<FinancialGoal> FinancialGoals { get; set; }
        public virtual ICollection<BankAccount> BankAccounts { get; set; }
        public virtual ICollection<Backup> Backups { get; set; }
        public virtual ICollection<BudgetAlert> BudgetAlerts { get; set; }
        public virtual ICollection<GoalReminder> GoalReminders { get; set; }


    }
}
