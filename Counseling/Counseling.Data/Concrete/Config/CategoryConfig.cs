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
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Url).IsRequired().HasMaxLength(500);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(500);

            builder.HasData(
                new Category
                {
                    Id = 1,
                    Name = "Bireysel Danışmanlık",
                    Description = "Bireylerin duygusal, zihinsel ve davranışsal sorunlarını değerlendirmek ve bireysel olarak danışmanlık sağlamak.",
                    Url = "bireysel-danismanlik",
                    IsDeleted = false,
                    IsApproved = true,
                    ImageUrl= "bireyseldanismanlık.jpg"
                },
                new Category
                {
                    Id = 2,
                    Name = "Çift ve Aile Danışmanlığı",
                    Description = "Çiftler ve aileler arasındaki ilişki sorunlarını değerlendirmek ve terapi yöntemleri kullanarak çiftler ve ailelerle danışmanlık sağlamak.",
                    Url = "cift-ve-aile-danismanligi",
                    IsDeleted = false,
                    IsApproved = true,
                    ImageUrl = "cift-aile-danismanligi.jpg"
                },
                new Category
                {
                    Id = 3,
                    Name = "Ergen Danışmanlığı",
                    Description = "Ergenlerin duygusal, sosyal ve davranışsal gelişimini desteklemek, ergenlerle danışmanlık yapmak ve onlara rehberlik etmek.",
                    Url = "ergen-danismanligi",
                    IsDeleted = false,
                    IsApproved = true,
                    ImageUrl= "ergen-danismanligi.jpeg"
                },
                new Category
                {
                    Id = 4,
                    Name = "Bağımlılık Danışmanlığı",
                    Description = "Madde bağımlılığı veya diğer bağımlılıklarla mücadele eden bireylere danışmanlık sağlamak, bağımlılıkları değerlendirmek ve tedavi planları oluşturmak.",
                    Url = "bagimlilik-danismanligi",
                    IsDeleted = false,
                    IsApproved = true,
                    ImageUrl= "bagimlilik-danismanligi.jpeg"
                },
                new Category
                {
                    Id = 5,
                    Name = "Kriz ve Travma Danışmanlığı",
                    Description = "Krize giren bireylere destek sağlamak, travma sonrası stres bozukluğu ve diğer travma reaksiyonlarına müdahale etmek, travma sonrası iyileşmeyi desteklemek.",
                    Url = "kriz-ve-tramva-danismanligi",
                    IsDeleted = false,
                    IsApproved = true,
                    ImageUrl = "krizvetramva.jpg"
                },
                new Category
                {
                    Id = 6,
                    Name = "Sosyal Beceri Eğitimi",
                    Description = "Bireylerin sosyal becerilerini geliştirmek, iletişim, ilişki kurma, sınır koyma gibi sosyal becerileri öğretmek ve desteklemek.",
                    Url = "sosyal-beceri-egitimi",
                    IsDeleted = false,
                    IsApproved = true,
                    ImageUrl= "sosyalbeceridanismanligi.jpg"
                },
                new Category
                {
                    Id = 7,
                    Name = "Öz-değerlendirme ve Kendini Keşfetme",
                    Description = "Bireylerin kendini değerlendirmesine ve keşfetmesine yardımcı olmak, güçlü yönleri ve zorlukları tanımak ve kişisel büyümeyi desteklemek.",
                    Url = "oz-fegerlendirme-ve-kendini-kesfetme",
                    IsDeleted = false,
                    IsApproved = true,
                    ImageUrl= "kendinikesfetme.jpg"
                },
                new Category
                {
                    Id = 8,
                    Name = "Yaşam Değişimleri ve Geçişler",
                    Description = "Bireylerin yaşam değişimleri, dönem geçişleri ve adaptasyon süreçlerine danışmanlık sağlamak, değişime uyum sürecini desteklemek ve başa çıkma becerilerini geliştirmek.",
                    Url = "yasam-degisimi-ve-gecisler",
                    IsDeleted = false,
                    IsApproved = true,
                    ImageUrl= "yasamdegisimivegecisler.jpeg"
                });

        }
    }
}
