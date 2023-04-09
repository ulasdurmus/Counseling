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

            builder.HasData(
                new Client { Id=1, UserId="Client1",IsApproved=true, Url="1"},
                new Client { Id=2, UserId="Client2",IsApproved=false, Url="2"},
                new Client { Id=3, UserId="Client3",IsApproved=true, Url="3"}
                );
        }
    }
}
