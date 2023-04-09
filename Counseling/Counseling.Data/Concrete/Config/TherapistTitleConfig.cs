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
    public class TherapistTitleConfig : IEntityTypeConfiguration<TherapistTitle>
    {
        public void Configure(EntityTypeBuilder<TherapistTitle> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x=> x.Name).IsRequired().HasMaxLength(50);
            builder.HasData(
                new TherapistTitle { Id = 1, Name = "Uzman Psikolog" },
                new TherapistTitle { Id = 2, Name = "Klinik Psikolog" },
                new TherapistTitle { Id = 3, Name = "Sağlık Psikoloğu" },
                new TherapistTitle { Id = 4, Name = "İş ve Örgüt Psikoloğu" },
                new TherapistTitle { Id = 5, Name = "Ruh Sağlığı ve Rehabilitasyon Psikoloğu" },
                new TherapistTitle { Id = 6, Name = "Uzman Psikolojik Danışman" },
                new TherapistTitle { Id = 7, Name = "Okul Psikolojik Danışmanı" },
                new TherapistTitle { Id = 8, Name = "Kariyer Psikolojik Danışmanı" },
                new TherapistTitle { Id = 9, Name = "Bağımlılık Danışmanı" },
                new TherapistTitle { Id = 10, Name = "Sosyal Hizmet Uzmanı" }
                );
        }
    }
}
