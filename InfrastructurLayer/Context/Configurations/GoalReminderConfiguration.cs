using DomainLayer.Entitys;
using InfrastructurLayer.Context.Configurations.IConfiguration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructurLayer.Context.Configurations
{
    public class GoalReminderConfiguration : IEntityConfiguration<GoalReminder>
    {
        public void Configure(EntityTypeBuilder<GoalReminder> builder)
        {
            builder
               .HasOne(gr => gr.User)
               .WithMany(u => u.GoalReminders)
               .HasForeignKey(gr => gr.UserId);
        }
    }
}
