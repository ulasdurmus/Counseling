using Counseling.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Counseling.Data.Concrete.Config
{
    public class ReservationHourConfig : IEntityTypeConfiguration<ReservationHour>
    {
        public void Configure(EntityTypeBuilder<ReservationHour> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x=> x.Value).IsRequired();
            builder.Property(x=> x.Hour).IsRequired();
            builder.HasData(
                new ReservationHour { Id = 1, Value = "08:00:00", Hour = "08:00 - 09:00" },
                new ReservationHour { Id = 2, Value = "09:00:00", Hour = "09:00 - 10:00" },
                new ReservationHour { Id = 3, Value = "10:00:00", Hour = "10:00 - 11:00" },
                new ReservationHour { Id = 4, Value = "11:00:00", Hour = "11:00 - 12:00" },
                new ReservationHour { Id = 5, Value = "12:00:00", Hour = "12:00 - 13:00" },
                new ReservationHour { Id = 6, Value = "13:00:00", Hour = "13:00 - 14:00" },
                new ReservationHour { Id = 7, Value = "14:00:00", Hour = "14:00 - 15:00" },
                new ReservationHour { Id = 8, Value = "15:00:00", Hour = "15:00 - 16:00" },
                new ReservationHour { Id = 9, Value = "16:00:00", Hour = "16:00 - 17:00" },
                new ReservationHour { Id = 10, Value = "17:00:00", Hour = "17:00 - 18:00" },
                new ReservationHour { Id = 11, Value = "18:00:00", Hour = "18:00 - 19:00" },
                new ReservationHour { Id = 12, Value = "19:00:00", Hour = "19:00 - 20:00" }
                );
        }
    }
}
