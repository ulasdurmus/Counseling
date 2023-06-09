﻿using Counseling.Entity.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Counseling.Data.Concrete.Config
{
    public class ServiceConfig : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Url).IsRequired().HasMaxLength(500);
            builder.Property(x => x.Price).IsRequired();
            builder.HasOne(x => x.Therapist).WithMany(x => x.Services).HasForeignKey(x => x.TherapistId).OnDelete(DeleteBehavior.Cascade);
            //builder.HasOne(x => x.Client).WithMany(x => x.Services).HasForeignKey(x => x.ClientId).OnDelete(DeleteBehavior.Cascade);
            builder.HasData(
                new Service { Id = 1, Price = 500, IsApproved=true,IsConfirmed=true, TherapistId=1, Url="service1", Description = "Seans açıklaması 1" },
                new Service { Id = 2, Price = 400, IsApproved=true,IsConfirmed=true, TherapistId=2, Url="service2", Description = "Seans açıklaması 2" },
                new Service { Id = 3, Price = 200, IsApproved=true,IsConfirmed=true, TherapistId=3, Url="service3", Description = "Seans açıklaması 3" }
                ) ;
        }
    }
}
