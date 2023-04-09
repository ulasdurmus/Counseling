using Counseling.Entity.Entity.Identitiy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Counseling.Data.Concrete.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            #region Role Informations
            List<Role> roles = new List<Role>
            {
                new Role{Name="Super Admin", Description="Tam yönetim hakkı bulunur.",NormalizedName="SUPERADMIN"},
                new Role{Name="Admin", Description="Kısıtlı yönetim hakkı bulunur.",NormalizedName="ADMIN"},
                new Role{Name="Therapist", Description="Kendilerine özel, kısıtlı izin verilmiş admin paneline sahip olabilir.",NormalizedName="THERAPIST"},
                new Role{Name="Client", Description="Kendilerine özel, hesap bilgilerini yöenetbilecekleri bir panele sahip olurlar.",NormalizedName="CLIENT"}
            };
            #endregion
            #region User Informations
            List<User> users = new List<User>
            {
                //SuperAdmin
                new User{
                    Id="SuperAdmin1",
                    FirstName="Ulaş", 
                    LastName="Durmuş",
                    UserName="ulasdurmus",
                    NormalizedUserName="ULASDURMUS",
                    Email="ulasdurmus1@gmail.com",
                    NormalizedEmail="ULASDURMUS1@GMAIL.COM",
                    Gender="Erkek",
                    DateOfBirth=new DateTime(12,13,1999), 
                    Address="Çekmeköy", 
                    EmailConfirmed=true},
                //Admin
                new User
                {
                    Id="Admin1",
                    FirstName = "Alice",
                    LastName = "Johnson",
                    UserName = "alicej",
                    NormalizedUserName = "ALICEJ",
                    Email = "alice.johnson@example.com",
                    NormalizedEmail = "ALICE.JOHNSON@EXAMPLE.COM",
                    Gender = "Female",
                    DateOfBirth = new DateTime(1985, 05, 15),
                    Address = "5678 Oak Avenue, Los Angeles",
                    EmailConfirmed = true
                },
                //Therapist
                new User
                {
                    Id="Therapist1",
                    FirstName = "John",
                    LastName = "Doe",
                    UserName = "johndoe",
                    NormalizedUserName = "JOHNDOE",
                    Email = "john.doe@example.com",
                    NormalizedEmail = "JOHN.DOE@EXAMPLE.COM",
                    Gender = "Male",
                    DateOfBirth = new DateTime(1990, 01, 01),
                    Address = "1234 Elm Street, Springfield",
                    EmailConfirmed = true
                },
                new User
                {
                    Id="Therapist2",
                    FirstName = "Bob",
                    LastName = "Smith",
                    UserName = "bobsmith",
                    NormalizedUserName = "BOBSMITH",
                    Email = "bob.smith@example.com",
                    NormalizedEmail = "BOB.SMITH@EXAMPLE.COM",
                    Gender = "Male",
                    DateOfBirth = new DateTime(1992, 10, 28),
                    Address = "9876 Maple Street, New York",
                    EmailConfirmed = false
                },
                new User
                {
                    Id="Therapist3",
                    FirstName = "Emma",
                    LastName = "Johnson",
                    UserName = "emma.johnson",
                    NormalizedUserName = "EMMA.JOHNSON",
                    Email = "emma.johnson@example.com",
                    NormalizedEmail = "EMMA.JOHNSON@EXAMPLE.COM",
                    Gender = "Female",
                    DateOfBirth = new DateTime(1995, 7, 22),
                    Address = "1234 Elm Street",
                    EmailConfirmed = true
                },
                //Client
                new User
                {
                    Id="Client1",
                    FirstName = "Emma",
                    LastName = "Brown",
                    UserName = "emmab",
                    NormalizedUserName = "EMMAB",
                    Email = "emma.brown@example.com",
                    NormalizedEmail = "EMMA.BROWN@EXAMPLE.COM",
                    Gender = "Female",
                    DateOfBirth = new DateTime(1998, 03, 12),
                    Address = "3456 Pine Road, Chicago",
                    EmailConfirmed = true
                },
                new User
                {
                    Id="Client2",
                    FirstName = "David",
                    LastName = "Lee",
                    UserName = "davidl",
                    NormalizedUserName = "DAVIDL",
                    Email = "david.lee@example.com",
                    NormalizedEmail = "DAVID.LEE@EXAMPLE.COM",
                    Gender = "Male",
                    DateOfBirth = new DateTime(1980, 11, 22),
                    Address = "2345 Cedar Avenue, San Francisco",
                    EmailConfirmed = true
                },
                new User
                {
                    Id="Client3",
                    FirstName = "Sophia",
                    LastName = "Chen",
                    UserName = "sophiac",
                    NormalizedUserName = "SOPHIAC",
                    Email = "sophia.chen@example.com",
                    NormalizedEmail = "SOPHIA.CHEN@EXAMPLE.COM",
                    Gender = "Female",
                    DateOfBirth = new DateTime(1995, 07, 03),
                    Address = "8765 Birch Street, Miami",
                    EmailConfirmed = false
                }


            };
            #endregion
            #region Password
            PasswordHasher<User> passwordHasher = new PasswordHasher<User>();
            for (int i = 0; i < users.Count; i++)
            {
                users[i].PasswordHash = passwordHasher.HashPassword(users[i], "Qwe123.");
            }
            #endregion
            #region Role-User
            List<IdentityUserRole<string>> userRoles = new List<IdentityUserRole<string>>
            {
                new IdentityUserRole<string>{UserId=users[0].Id, RoleId=roles.FirstOrDefault(r=> r.Name=="Super Admin").Id},
                new IdentityUserRole<string>{UserId=users[1].Id, RoleId=roles.FirstOrDefault(r=> r.Name=="Admin").Id},
                new IdentityUserRole<string>{UserId=users[2].Id, RoleId=roles.FirstOrDefault(r=> r.Name=="Therapist").Id},
                new IdentityUserRole<string>{UserId=users[3].Id, RoleId=roles.FirstOrDefault(r=> r.Name=="Therapist").Id},
                new IdentityUserRole<string>{UserId=users[4].Id, RoleId=roles.FirstOrDefault(r=> r.Name=="Therapist").Id},
                new IdentityUserRole<string>{UserId=users[5].Id, RoleId=roles.FirstOrDefault(r=> r.Name=="Client").Id},
                new IdentityUserRole<string>{UserId=users[6].Id, RoleId=roles.FirstOrDefault(r=> r.Name=="Client").Id},
                new IdentityUserRole<string>{UserId=users[7].Id, RoleId=roles.FirstOrDefault(r=> r.Name=="Client").Id},
            };
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(userRoles);
            #endregion
        }
    }
}
