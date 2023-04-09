using Counseling.Entity.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Counseling.Data.Concrete.Config
{
    public class ServiceCategoryConfig : IEntityTypeConfiguration<ServiceCategory>
    {
        public void Configure(EntityTypeBuilder<ServiceCategory> builder)
        {
            builder.HasKey(sc => new { sc.ServiceId, sc.CategoryId });
            builder.HasData(
                new ServiceCategory { ServiceId = 1, CategoryId = 1 },
                new ServiceCategory { ServiceId = 1, CategoryId = 2 },
                new ServiceCategory { ServiceId = 2, CategoryId = 4 },
                new ServiceCategory { ServiceId = 3, CategoryId = 3 },
                new ServiceCategory { ServiceId = 3, CategoryId = 5 }
                );
        }
    }
}
