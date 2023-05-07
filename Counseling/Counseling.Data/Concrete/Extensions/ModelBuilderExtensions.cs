using Counseling.Entity.Entity;
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
                new Role
                {
                    //Id="a116760b-7777-45f6-ae6e-eaf8f434ea49",
                    Name="SuperAdmin", 
                    Description="Tam yönetim hakkı bulunur.",
                    NormalizedName="SUPERADMIN"
                },
                new Role
                {
                    //Id="da4903c5-afb5-4990-ab58-0da456b838c2",
                    Name="Admin", 
                    Description="Kısıtlı yönetim hakkı bulunur.",
                    NormalizedName="ADMIN"
                },
                new Role
                {
                    //Id="78ff3433-5ca3-4e26-a2bd-d91c35a67a25",
                    Name="Therapist", 
                    Description="Kendilerine özel, kısıtlı izin verilmiş admin paneline sahip olabilir.",
                    NormalizedName="THERAPIST"
                },
                new Role
                {
                    //Id="b62dd87d-1a4b-4f7f-a3e1-2560b9af4198",
                    Name="Client", 
                    Description="Kendilerine özel, hesap bilgilerini yöenetbilecekleri bir panele sahip olurlar.",
                    NormalizedName="CLIENT"
                }
            };
            modelBuilder.Entity<Role>().HasData(roles);
            #endregion
            #region User Informations
            List<User> users = new List<User>
            {
                //SuperAdmin
                new User{
                    Id="b7082603-2d69-4adc-bc4e-1e294a75cd5a",
                    FirstName="Ulaş", 
                    LastName="Durmuş",
                    NormalizedName="ULAŞDURMUŞ",
                    UserName="ulasdurmus",
                    NormalizedUserName="ULASDURMUS",
                    Email="ulasdurmus1@gmail.com",
                    NormalizedEmail="ULASDURMUS1@GMAIL.COM",
                    Gender="Erkek",
                    DateOfBirth=new DateTime(1999,12,13),
                    DateOfRegistration= DateTime.Now,
                    Address="Çekmeköy", 
                    EmailConfirmed=true
                },
                //Admin
                new User
                {
                    Id="eba9d9f5-bcde-4039-8e38-2f3292ed46b6",
                    FirstName = "Alice",
                    LastName = "Johnson",
                    NormalizedName="ALİCEJOHNSON",
                    UserName = "alicej",
                    NormalizedUserName = "ALICEJ",
                    Email = "alice.johnson@example.com",
                    NormalizedEmail = "ALICE.JOHNSON@EXAMPLE.COM",
                    Gender = "Female",
                    DateOfBirth = new DateTime(1985, 05, 15),
                    DateOfRegistration= DateTime.Now,
                    Address = "5678 Oak Avenue, Los Angeles",
                    EmailConfirmed = true
                },
                //Therapist
                new User
                {
                    Id="86babe7e-9dea-4cf2-9faf-4439b64d13ba",
                    FirstName = "John",
                    LastName = "Doe",
                    NormalizedName="JOHNDOE",
                    UserName = "johndoe",
                    NormalizedUserName = "JOHNDOE",
                    Email = "john.doe@example.com",
                    NormalizedEmail = "JOHN.DOE@EXAMPLE.COM",
                    Gender = "Male",
                    DateOfBirth = new DateTime(1990, 01, 01),
                    DateOfRegistration= DateTime.Now,
                    Address = "1234 Elm Street, Springfield",
                    EmailConfirmed = true,
                    PhoneNumber = "0544 372 12 11"
                },
                new User
                {
                    Id="35891788-47d3-4645-87f0-fda34734bab3",
                    FirstName = "Bob",
                    LastName = "Smith",
                    NormalizedName="BOBSMİTH",
                    UserName = "bobsmith",
                    NormalizedUserName = "BOBSMITH",
                    Email = "bob.smith@example.com",
                    NormalizedEmail = "BOB.SMITH@EXAMPLE.COM",
                    Gender = "Male",
                    DateOfBirth = new DateTime(1992, 10, 28),
                    DateOfRegistration= DateTime.Now,
                    Address = "9876 Maple Street, New York",
                    EmailConfirmed = false,
                    PhoneNumber = "0544 372 51 33"
                },
                new User
                {
                    Id="211e2b50-d08d-4dc7-9944-de813060f3df",
                    FirstName = "Emma",
                    LastName = "Johnson",
                    UserName = "emma.johnson",
                    NormalizedName="EMMAJOHNSON",
                    NormalizedUserName = "EMMA.JOHNSON",
                    Email = "emma.johnson@example.com",
                    NormalizedEmail = "EMMA.JOHNSON@EXAMPLE.COM",
                    Gender = "Female",
                    DateOfBirth = new DateTime(1995, 7, 22),
                    DateOfRegistration= DateTime.Now,
                    Address = "1234 Elm Street",
                    EmailConfirmed = true,
                    PhoneNumber = "0532 872 42 55"
                },
                //Client
                new User
                {
                    Id="5c4080ce-3cee-4051-8660-4b7f208681ce",
                    FirstName = "Emma",
                    LastName = "Brown",
                    NormalizedName="EMMABROWN",
                    UserName = "emmab",
                    NormalizedUserName = "EMMAB",
                    Email = "emma.brown@example.com",
                    NormalizedEmail = "EMMA.BROWN@EXAMPLE.COM",
                    Gender = "Female",
                    DateOfBirth = new DateTime(1998, 03, 12),
                    DateOfRegistration= DateTime.Now,
                    Address = "3456 Pine Road, Chicago",
                    EmailConfirmed = true
                },
                new User
                {
                    Id="d9034f11-8877-4c14-ae85-442d2449b547",
                    FirstName = "David",
                    LastName = "Lee",
                    NormalizedName="DAVİDLEE",
                    UserName = "davidl",
                    NormalizedUserName = "DAVIDL",
                    Email = "david.lee@example.com",
                    NormalizedEmail = "DAVID.LEE@EXAMPLE.COM",
                    Gender = "Male",
                    DateOfBirth = new DateTime(1980, 11, 22),
                    DateOfRegistration= DateTime.Now,
                    Address = "2345 Cedar Avenue, San Francisco",
                    EmailConfirmed = true
                },
                new User
                {
                    Id="0f80dbad-d5f4-4f82-a780-165aa66b7d07",
                    FirstName = "Sophia",
                    LastName = "Chen",
                    NormalizedName="SOPHİACHEN",
                    UserName = "sophiac",
                    NormalizedUserName = "SOPHIAC",
                    Email = "sophia.chen@example.com",
                    NormalizedEmail = "SOPHIA.CHEN@EXAMPLE.COM",
                    Gender = "Female",
                    DateOfBirth = new DateTime(1995, 07, 03),
                    DateOfRegistration= DateTime.Now,
                    Address = "8765 Birch Street, Miami",
                    EmailConfirmed = false
                }


            };
            modelBuilder.Entity<User>().HasData(users);
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
                new IdentityUserRole<string>{UserId=users[0].Id, RoleId=roles.FirstOrDefault(r=> r.Name=="SuperAdmin").Id},
                new IdentityUserRole<string>{UserId=users[1].Id, RoleId=roles.FirstOrDefault(r=> r.Name=="Admin").Id},
                new IdentityUserRole<string>{UserId=users[2].Id, RoleId=roles.FirstOrDefault(r=> r.Name=="Therapist").Id},
                new IdentityUserRole<string>{UserId=users[3].Id, RoleId=roles.FirstOrDefault(r=> r.Name=="Therapist").Id},
                new IdentityUserRole<string>{UserId=users[4].Id, RoleId=roles.FirstOrDefault(r=> r.Name=="Therapist").Id},
                new IdentityUserRole<string>{UserId=users[5].Id, RoleId=roles.FirstOrDefault(r=> r.Name=="Client").Id},
                new IdentityUserRole<string>{UserId=users[6].Id, RoleId=roles.FirstOrDefault(r=> r.Name=="Client").Id},
                new IdentityUserRole<string>{UserId=users[7].Id, RoleId=roles.FirstOrDefault(r=> r.Name=="Client").Id}
            };
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(userRoles);
            #endregion
            #region Client
            List<Client> clients = new List<Client>
            {
                new Client { Id = 1, UserId = "5c4080ce-3cee-4051-8660-4b7f208681ce", IsApproved = true, Url = "1" },
                new Client { Id = 2, UserId = "d9034f11-8877-4c14-ae85-442d2449b547", IsApproved = false, Url = "2" },
                new Client { Id = 3, UserId = "0f80dbad-d5f4-4f82-a780-165aa66b7d07", IsApproved = true, Url = "3" }
            };
            modelBuilder.Entity<Client>().HasData(clients);
            #endregion
            #region Therapist
            List<Therapist> therapists = new List<Therapist>
            {
                new Therapist
                {
                    Id=1,
                    Description="Therapist Açıklama 1",
                    UserId= "86babe7e-9dea-4cf2-9faf-4439b64d13ba",
                    IsApproved=true,
                    IsOnline=false,
                    Url="therapist1",
                    TitleId=1,
                    EducationId=1

                },
                new Therapist
                {
                    Id=2,
                    Description="Therapist Açıklama 2",
                    UserId= "35891788-47d3-4645-87f0-fda34734bab3",
                    IsApproved=true,
                    IsOnline=false,
                    Url="therapist2",
                    TitleId = 1,
                    EducationId=2
                },
                new Therapist
                {
                    Id=3,
                    Description="Therapist Açıklama 3",
                    UserId= "211e2b50-d08d-4dc7-9944-de813060f3df",
                    IsApproved=true,
                    IsOnline=false,
                    Url="therapist3",
                    TitleId = 1,
                    EducationId=3
                }
            };
            modelBuilder.Entity<Therapist>().HasData(therapists);
            #endregion
        }
    }
}
