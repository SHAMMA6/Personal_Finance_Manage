using DomainLayer.Entitys;
using InfrastructurLayer.Context.Configurations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructurLayer.Context
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext( DbContextOptions<AppDbContext> options ) : base( options ) 
        {
            
        }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Budget> Budgets { get; set; }
        public DbSet<FinancialGoal> FinancialGoals { get; set; }
        public DbSet<FinancialReport> FinancialReports { get; set; }
        public DbSet<BankAccount> BankAccounts { get; set; }
        public DbSet<Backup> Backups { get; set; }
        public DbSet<BudgetAlert> BudgetAlerts { get; set; }
        public DbSet<GoalReminder> GoalReminders { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Configure relationships
            builder.ApplyConfigurationsFromAssembly(typeof(AppUserConfiguration).Assembly);
            builder.ApplyConfigurationsFromAssembly(typeof(BudgetConfiguration).Assembly);
            builder.ApplyConfigurationsFromAssembly(typeof(FinancialGoalsConfiguration).Assembly);
            builder.ApplyConfigurationsFromAssembly(typeof(TransactionConfiguration).Assembly);
            builder.ApplyConfigurationsFromAssembly(typeof(BudgetAlert).Assembly);
            builder.ApplyConfigurationsFromAssembly(typeof(GoalReminder).Assembly);


            // New Options
          



            // Make Restrict By Default
            foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

        }

    }
}

