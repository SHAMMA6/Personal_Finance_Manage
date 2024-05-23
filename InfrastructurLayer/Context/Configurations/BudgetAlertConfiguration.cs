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
    public class BudgetAlertConfiguration : IEntityConfiguration<BudgetAlert>
    {
        public void Configure(EntityTypeBuilder<BudgetAlert> builder)
        {
            builder
            .HasOne(ba => ba.User)
            .WithMany(u => u.BudgetAlerts)
            .HasForeignKey(ba => ba.UserId);
        }
    }
}
