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
    public class ClientThrapistConfig : IEntityTypeConfiguration<ClientTherapist>
    {
        public void Configure(EntityTypeBuilder<ClientTherapist> builder)
        {
            builder.HasKey(ct => new { ct.ClientId, ct.TherapistId,ct.ReservationId });
            builder.HasOne(x => x.Therapist).WithMany(x => x.ClientTherapists).HasForeignKey(x => x.TherapistId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.Client).WithMany(x => x.ClientTherapists).HasForeignKey(x => x.ClientId).OnDelete(DeleteBehavior.Cascade);
            builder.HasData(
                new ClientTherapist { ClientId=1,TherapistId=3, ReservationId =1},
                new ClientTherapist { ClientId=1,TherapistId=2, ReservationId =2},
                new ClientTherapist { ClientId=1,TherapistId=1, ReservationId =3}
                );

        }
    }
}
