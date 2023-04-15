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

            //builder.HasData(
            //    new Therapist 
            //    { 
            //        Id=1, 
            //        Description="Therapist Açıklama 1", 
            //        UserId= "86babe7e-9dea-4cf2-9faf-4439b64d13ba", 
            //        IsApproved=true,
            //        IsOnline=false,
            //        Url="therapist1",
            //        TitleId=1
                    
            //    },
            //    new Therapist 
            //    { 
            //        Id=2, 
            //        Description="Therapist Açıklama 2", 
            //        UserId= "35891788-47d3-4645-87f0-fda34734bab3", 
            //        IsApproved=true,
            //        IsOnline=false,
            //        Url="therapist2",
            //        TitleId = 1
            //    },
            //    new Therapist 
            //    { 
            //        Id=3, 
            //        Description="Therapist Açıklama 3", 
            //        UserId= "211e2b50-d08d-4dc7-9944-de813060f3df", 
            //        IsApproved=true,
            //        IsOnline=false,
            //        Url="therapist3",
            //        TitleId = 1
            //    });
        }
    }
}
