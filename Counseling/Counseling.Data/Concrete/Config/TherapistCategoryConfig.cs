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
    public class TherapistCategoryConfig : IEntityTypeConfiguration<TherapistCategory>
    {
        public void Configure(EntityTypeBuilder<TherapistCategory> builder)
        {
            builder.HasKey(tc=> new {tc.TherapistId, tc.CategoryId});
            builder.HasOne(x=> x.Therapist).WithMany(x=> x.TherapistCategories).HasForeignKey(x=>x.TherapistId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x=> x.Category).WithMany(x=> x.TherapistCategories).HasForeignKey(x=> x.CategoryId).OnDelete(DeleteBehavior.Cascade);
            builder.HasData(
                new TherapistCategory { TherapistId = 1, CategoryId=1},
                new TherapistCategory { TherapistId = 1, CategoryId=2},
                new TherapistCategory { TherapistId = 1, CategoryId=3},
                new TherapistCategory { TherapistId = 1, CategoryId=4},
                new TherapistCategory { TherapistId = 2, CategoryId=1},
                new TherapistCategory { TherapistId = 2, CategoryId=5},
                new TherapistCategory { TherapistId = 2, CategoryId=7},
                new TherapistCategory { TherapistId = 3, CategoryId=1},
                new TherapistCategory { TherapistId = 3, CategoryId=8}
                );
        }
    }
}
