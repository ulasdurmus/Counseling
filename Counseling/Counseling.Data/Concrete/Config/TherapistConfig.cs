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
            builder.Property(x => x.Description).IsRequired().HasMaxLength(500);

            builder.HasData(
                new Therapist { Id=1, Description="Therapist Açıklama 1", UserId="Therapist1", IsApproved=true,IsOnline=false,Url="therapist1"},
                new Therapist { Id=2, Description="Therapist Açıklama 2", UserId= "Therapist2", IsApproved=true,IsOnline=false,Url="therapist2"},
                new Therapist { Id=3, Description="Therapist Açıklama 3", UserId= "Therapist3", IsApproved=true,IsOnline=false,Url="therapist3"}
                );
        }
    }
}
