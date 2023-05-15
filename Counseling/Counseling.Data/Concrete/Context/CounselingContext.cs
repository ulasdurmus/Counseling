using Counseling.Data.Concrete.Config;
using Counseling.Data.Concrete.Extensions;
using Counseling.Entity.Concrete;
using Counseling.Entity.Entity;
using Counseling.Entity.Entity.Identitiy;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Counseling.Data.Concrete.Context
{
    public class CounselingContext : IdentityDbContext<User, Role, string>
    {
        public CounselingContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Image> Images { get; set; }
        public DbSet<University> Universities { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Category> Categories{ get; set; }
        public DbSet<Service> Services{ get; set; }
        public DbSet<ServiceCategory> ServiceCategories{ get; set; }
        public DbSet<Therapist> Therapists{ get; set; }
        public DbSet<ServiceTherapist> ServiceTherapists { get; set; }
        public DbSet<TherapistCategory> TherapistCategories{ get; set; }
        public DbSet<TherapistTitle> TherapistTitles{ get; set; }
        public DbSet<Certificate> Certificates{ get; set; }
        public DbSet<Client> Clients{ get; set; }
        public DbSet<ClientService> ClientServices{ get; set; }
        public DbSet<ClientTherapist> ClientTherapists{ get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<ReservationHour> ReservationHours { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.SeedData();
            builder.ApplyConfigurationsFromAssembly(typeof(CategoryConfig).Assembly);
            base.OnModelCreating(builder);
        }
    }
}
