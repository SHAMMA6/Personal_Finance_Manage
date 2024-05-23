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
    public class FinancialGoalsConfiguration : IEntityConfiguration<FinancialGoal>
    {
        public void Configure(EntityTypeBuilder<FinancialGoal> builder)
        {
            builder
                .HasOne(fg => fg.User)
                .WithMany(u => u.FinancialGoals)
                .HasForeignKey(fg => fg.UserId);


            builder
                .HasOne(fg => fg.User)
                .WithMany(u => u.FinancialGoals)
                .HasForeignKey(fg => fg.UserId);
        }
    }
}
