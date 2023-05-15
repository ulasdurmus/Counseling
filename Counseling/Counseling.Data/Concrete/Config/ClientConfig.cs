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
    public class ClientConfig : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Url).IsRequired().HasMaxLength(500);
            builder.HasOne(x => x.User).WithOne(x => x.Client).HasForeignKey<Client>(x => x.UserId).OnDelete(DeleteBehavior.Cascade);
            //builder.HasData(
            //    new Client { Id = 1, UserId = "5c4080ce-3cee-4051-8660-4b7f208681ce", IsApproved = true, Url = "1" },
            //    new Client { Id = 2, UserId = "d9034f11-8877-4c14-ae85-442d2449b547", IsApproved = false, Url = "2" },
            //    new Client { Id = 3, UserId = "0f80dbad-d5f4-4f82-a780-165aa66b7d07", IsApproved = true, Url = "3" }
            //    );
        }
    }
}
