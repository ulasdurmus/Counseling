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
    public class ClientServiceConfig : IEntityTypeConfiguration<ClientService>
    {
        public void Configure(EntityTypeBuilder<ClientService> builder)
        {
            builder.HasKey(ba => new { ba.ClientId, ba.ServiceId });
            builder.HasData(
                new ClientService { ClientId = 1, ServiceId = 1 },
                new ClientService { ClientId = 1, ServiceId = 2 },
                new ClientService { ClientId = 1, ServiceId = 3 },

                new ClientService { ClientId = 2, ServiceId = 2 },
                new ClientService { ClientId = 2, ServiceId = 3 },

                new ClientService { ClientId = 3, ServiceId = 1 },
                new ClientService { ClientId = 3, ServiceId = 2 },
                new ClientService { ClientId = 3, ServiceId = 3 }
                );
        }
    }
}
