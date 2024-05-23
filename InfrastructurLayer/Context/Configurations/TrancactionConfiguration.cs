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
    public class TransactionConfiguration : IEntityConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder
                 .HasOne(t => t.User)
                 .WithMany(u => u.Transactions)
                 .HasForeignKey(t => t.UserId);

            builder
                .HasOne(t => t.User)
                .WithMany(u => u.Transactions)
                .HasForeignKey(t => t.UserId);

            builder
                .HasOne(t => t.User)
                .WithMany(u => u.Transactions)
                .HasForeignKey(t => t.UserId);
        }
    }
}
