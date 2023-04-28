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
    public class TherapistConfig : IEntityTypeConfiguration<Therapist>
    {
        public void Configure(EntityTypeBuilder<Therapist> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x=> x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Description).HasMaxLength(500);

            
        }
    }
}
