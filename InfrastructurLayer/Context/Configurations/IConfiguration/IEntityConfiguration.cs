using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructurLayer.Context.Configurations.IConfiguration
{
    public interface IEntityConfiguration<TEntity> where TEntity : class
    {
        void Configure(EntityTypeBuilder<TEntity> builder);
    }
}
