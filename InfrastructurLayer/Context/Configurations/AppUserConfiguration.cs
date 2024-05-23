using DomainLayer.Entitys;
using InfrastructurLayer.Context.Configurations.IConfiguration;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructurLayer.Context.Configurations
{
    public class AppUserConfiguration : IEntityConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder
                .HasMany(u => u.Transactions)
                .WithOne(t => t.User)
                .HasForeignKey(t => t.UserId);

            builder
                .HasMany(u => u.Budgets)
                .WithOne(b => b.User)
                .HasForeignKey(b => b.UserId);

            builder
                .HasMany(u => u.FinancialGoals)
                .WithOne(fg => fg.User)
                .HasForeignKey(fg => fg.UserId);

            builder
                .HasMany(u => u.BankAccounts)
                .WithOne(ba => ba.User)
                .HasForeignKey(ba => ba.UserId);

            builder
                .HasMany(u => u.Backups)
                .WithOne(b => b.User)
                .HasForeignKey(b => b.UserId);
        }
    }
}
