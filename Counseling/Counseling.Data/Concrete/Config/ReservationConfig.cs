using Counseling.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Counseling.Data.Concrete.Config
{
    public class ReservationConfig : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Price).IsRequired();
            builder.Property(x=> x.ReservationDate).IsRequired();
            builder.Property(x=> x.ServiceId).IsRequired();
            builder.Property(x => x.ClientId).IsRequired();
            builder.Property(x => x.TherapistId).IsRequired();
            builder.HasData(
                new Reservation { Id=1, ClientId=1, ServiceId=1,TherapistId=1, IsConfirmed=true,Price=500, IsPaid=true},
                new Reservation { Id=2, ClientId=2, ServiceId=2,TherapistId=2, IsConfirmed=true,Price=500, IsPaid=false},
                new Reservation { Id=3, ClientId=3, ServiceId=3,TherapistId=3, IsConfirmed=true,Price=500, IsPaid=true}
                );
        }
    }
}
