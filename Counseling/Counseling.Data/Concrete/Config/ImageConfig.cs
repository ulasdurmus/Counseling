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
    public class ImageConfig : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Url).IsRequired().HasMaxLength(500);
            builder.HasData(
                new Image { Id=1,IsApproved=true,Url= "messages-3(16).jpg" },
                new Image { Id=2,IsApproved=true,Url= "messages-3(3).jpg" },
                new Image { Id=3,IsApproved=true,Url= "messages-3(16).jpg" }
                );
        }
    }
}
