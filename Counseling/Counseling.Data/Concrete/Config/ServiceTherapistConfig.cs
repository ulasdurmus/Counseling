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
    public class ServiceTherapistConfig : IEntityTypeConfiguration<ServiceTherapist>
    {
        public void Configure(EntityTypeBuilder<ServiceTherapist> builder)
        {
            builder.HasKey(st => new { st.ServiceId, st.Therapist });
            builder.HasData(
                new ServiceTherapist { ServiceId=1,TherapistId=2 },
                new ServiceTherapist { ServiceId=2,TherapistId=1 },
                new ServiceTherapist { ServiceId=3,TherapistId=3 }
                );
        }
    }
}
