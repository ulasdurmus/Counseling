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
    public class EducationConfig : IEntityTypeConfiguration<Education>
    {
        public void Configure(EntityTypeBuilder<Education> builder)
        {
            builder.HasKey(x=> x.Id);
            builder.Property(x=> x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.StartedDate).IsRequired();
            builder.Property(x => x.EndedDate).IsRequired();
            builder.Property(x => x.UniversityId).IsRequired();
            builder.Property(x => x.DepartmentId).IsRequired();
            builder.HasData(
                new Education { Id=1,DepartmentId=1,UniversityId=1, StartedDate=new DateTime(2010,09,01),EndedDate=new DateTime(2014,6,01)},
                new Education { Id=2,DepartmentId=2,UniversityId=2, StartedDate=new DateTime(2005,09,01),EndedDate=new DateTime(209,06,01)},
                new Education { Id=3,DepartmentId=1,UniversityId=3, StartedDate=new DateTime(2013,09,01),EndedDate=new DateTime(2018,06,01)}
                );
        }
    }
}
