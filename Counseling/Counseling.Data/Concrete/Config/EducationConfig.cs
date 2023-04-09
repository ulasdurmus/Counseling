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
                new Education { Id=1,DepartmentId=1,UniversityId=1, StartedDate=new DateTime(2010,9,1),EndedDate=new DateTime(2014,6,1)},
                new Education { Id=1,DepartmentId=2,UniversityId=2, StartedDate=new DateTime(2005,9,1),EndedDate=new DateTime(209,6,1)},
                new Education { Id=1,DepartmentId=1,UniversityId=3, StartedDate=new DateTime(2013,9,1),EndedDate=new DateTime(2018,6,1)}
                );
        }
    }
}
