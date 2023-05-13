using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Counseling.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    Url = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    IsApproved = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Url = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    IsApproved = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ServiceId = table.Column<int>(type: "INTEGER", nullable: false),
                    ClientId = table.Column<int>(type: "INTEGER", nullable: false),
                    TherapistId = table.Column<int>(type: "INTEGER", nullable: false),
                    ReservationDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    IsConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsPaid = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TherapistId = table.Column<int>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Url = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    IsApproved = table.Column<bool>(type: "INTEGER", nullable: false),
                    Price = table.Column<decimal>(type: "TEXT", nullable: false),
                    IsConfirmed = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TherapistTitles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TherapistTitles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Universities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Universities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true),
                    NormalizedName = table.Column<string>(type: "TEXT", nullable: true),
                    Address = table.Column<string>(type: "TEXT", nullable: true),
                    Gender = table.Column<string>(type: "TEXT", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DateOfRegistration = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ImageId = table.Column<int>(type: "INTEGER", nullable: true),
                    UserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "TEXT", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    PasswordHash = table.Column<string>(type: "TEXT", nullable: true),
                    SecurityStamp = table.Column<string>(type: "TEXT", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "INTEGER", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "TEXT", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "INTEGER", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Images_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Images",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ServiceCategories",
                columns: table => new
                {
                    ServiceId = table.Column<int>(type: "INTEGER", nullable: false),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceCategories", x => new { x.ServiceId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_ServiceCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceCategories_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Educations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StartedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EndedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UniversityId = table.Column<int>(type: "INTEGER", nullable: false),
                    DepartmentId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Educations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Educations_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Educations_Universities_UniversityId",
                        column: x => x.UniversityId,
                        principalTable: "Universities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    ClaimType = table.Column<string>(type: "TEXT", nullable: true),
                    ClaimValue = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderKey = table.Column<string>(type: "TEXT", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    RoleId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    LoginProvider = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Value = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: true),
                    Url = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    IsApproved = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clients_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Therapists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: true),
                    Url = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    IsApproved = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsOnline = table.Column<bool>(type: "INTEGER", nullable: false),
                    EducationId = table.Column<int>(type: "INTEGER", nullable: false),
                    TitleId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Therapists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Therapists_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Therapists_Educations_EducationId",
                        column: x => x.EducationId,
                        principalTable: "Educations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Therapists_TherapistTitles_TitleId",
                        column: x => x.TitleId,
                        principalTable: "TherapistTitles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ClientServices",
                columns: table => new
                {
                    ClientId = table.Column<int>(type: "INTEGER", nullable: false),
                    ServiceId = table.Column<int>(type: "INTEGER", nullable: false),
                    ReservationId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientServices", x => new { x.ClientId, x.ServiceId, x.ReservationId });
                    table.ForeignKey(
                        name: "FK_ClientServices_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClientServices_Reservations_ReservationId",
                        column: x => x.ReservationId,
                        principalTable: "Reservations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClientServices_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Certificates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    PdfUrl = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    TherapistId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Certificates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Certificates_Therapists_TherapistId",
                        column: x => x.TherapistId,
                        principalTable: "Therapists",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ClientTherapists",
                columns: table => new
                {
                    ClientId = table.Column<int>(type: "INTEGER", nullable: false),
                    TherapistId = table.Column<int>(type: "INTEGER", nullable: false),
                    ReservationId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientTherapists", x => new { x.ClientId, x.TherapistId, x.ReservationId });
                    table.ForeignKey(
                        name: "FK_ClientTherapists_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClientTherapists_Reservations_ReservationId",
                        column: x => x.ReservationId,
                        principalTable: "Reservations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClientTherapists_Therapists_TherapistId",
                        column: x => x.TherapistId,
                        principalTable: "Therapists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceTherapists",
                columns: table => new
                {
                    ServiceId = table.Column<int>(type: "INTEGER", nullable: false),
                    TherapistId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceTherapists", x => new { x.ServiceId, x.TherapistId });
                    table.ForeignKey(
                        name: "FK_ServiceTherapists_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceTherapists_Therapists_TherapistId",
                        column: x => x.TherapistId,
                        principalTable: "Therapists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TherapistCategories",
                columns: table => new
                {
                    TherapistId = table.Column<int>(type: "INTEGER", nullable: false),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TherapistCategories", x => new { x.TherapistId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_TherapistCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TherapistCategories_Therapists_TherapistId",
                        column: x => x.TherapistId,
                        principalTable: "Therapists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4dd382ce-bc59-4ff5-a5d3-446a11d34941", null, "Kısıtlı yönetim hakkı bulunur.", "Admin", "ADMIN" },
                    { "5b2458f2-3be9-4be3-ad1b-1e30eeb1da0d", null, "Kendilerine özel, hesap bilgilerini yöenetbilecekleri bir panele sahip olurlar.", "Client", "CLIENT" },
                    { "7619050e-3a6a-4a33-9491-ea5b2db63c0b", null, "Kendilerine özel, kısıtlı izin verilmiş admin paneline sahip olabilir.", "Therapist", "THERAPIST" },
                    { "8d07f8b3-1020-4da7-9d57-b025719e6200", null, "Tam yönetim hakkı bulunur.", "SuperAdmin", "SUPERADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "DateOfBirth", "DateOfRegistration", "Email", "EmailConfirmed", "FirstName", "Gender", "ImageId", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedName", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "0f80dbad-d5f4-4f82-a780-165aa66b7d07", 0, "8765 Birch Street, Miami", "22f8792c-608d-4a25-8af2-b24ac143a2fc", new DateTime(1995, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 13, 13, 38, 48, 52, DateTimeKind.Local).AddTicks(6810), "sophia.chen@example.com", false, "Sophia", "Female", null, "Chen", false, null, "SOPHIA.CHEN@EXAMPLE.COM", "SOPHİACHEN", "SOPHIAC", "AQAAAAIAAYagAAAAEJHl2V3nbsqkGRz6UzfDDJk7CLoq246YqNutiJTqQa+tXNYxYXFQUk1hhPB2Wobdzg==", null, false, "7323c44c-7be9-4709-bf91-ec7883dbe0b0", false, "sophiac" },
                    { "211e2b50-d08d-4dc7-9944-de813060f3df", 0, "1234 Elm Street", "9d968c76-558d-44e4-80a4-9935eecfdcdb", new DateTime(1995, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 13, 13, 38, 48, 52, DateTimeKind.Local).AddTicks(6765), "emma.johnson@example.com", true, "Emma", "Female", null, "Johnson", false, null, "EMMA.JOHNSON@EXAMPLE.COM", "EMMAJOHNSON", "EMMA.JOHNSON", "AQAAAAIAAYagAAAAEB/fiqK3+IwPyd9cMqZcwEqHNjqvk9W+ImyNEBOKT+sIaEkxxeogaNyk5YAhJtAxyw==", "0532 872 42 55", false, "2806234f-e8c7-4166-a1ea-852ee429e295", false, "emma.johnson" },
                    { "35891788-47d3-4645-87f0-fda34734bab3", 0, "9876 Maple Street, New York", "83c56a90-ada5-4935-9882-0634d8524675", new DateTime(1992, 10, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 13, 13, 38, 48, 52, DateTimeKind.Local).AddTicks(6749), "bob.smith@example.com", false, "Bob", "Male", null, "Smith", false, null, "BOB.SMITH@EXAMPLE.COM", "BOBSMİTH", "BOBSMITH", "AQAAAAIAAYagAAAAEFS1wdihkHKPS8Dn389alBo+ftjxGZEhWnO7QvNmr7x5GLkFJyqLYwV3zHlQrEaz2g==", "0544 372 51 33", false, "11e7341f-f86e-482d-94f7-6c16c5da6f51", false, "bobsmith" },
                    { "5c4080ce-3cee-4051-8660-4b7f208681ce", 0, "3456 Pine Road, Chicago", "3126664e-6907-4718-89e3-b3ce83fb6d04", new DateTime(1998, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 13, 13, 38, 48, 52, DateTimeKind.Local).AddTicks(6780), "emma.brown@example.com", true, "Emma", "Female", null, "Brown", false, null, "EMMA.BROWN@EXAMPLE.COM", "EMMABROWN", "EMMAB", "AQAAAAIAAYagAAAAEGgjEVyNM4iBnmxZrAt36DKaZd9hd/BpcOaI/XRVdIg7SJ4S8ufjgCMy8+fSGBGrVg==", null, false, "07db9f1f-7b8b-47d7-b656-c9af32b361e6", false, "emmab" },
                    { "86babe7e-9dea-4cf2-9faf-4439b64d13ba", 0, "1234 Elm Street, Springfield", "23df20bf-0aa5-4f22-992c-6f21f38f638c", new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 13, 13, 38, 48, 52, DateTimeKind.Local).AddTicks(6735), "john.doe@example.com", true, "John", "Male", null, "Doe", false, null, "JOHN.DOE@EXAMPLE.COM", "JOHNDOE", "JOHNDOE", "AQAAAAIAAYagAAAAEDszwUT3i1u+wLT1PY2TCVY3utI5kP7WqUM9e/TZZWt3nflPwFrl+cDJ6xSEo1UqNQ==", "0544 372 12 11", false, "8ee006e6-6e4a-43d2-92bc-173ccada7bce", false, "johndoe" },
                    { "b7082603-2d69-4adc-bc4e-1e294a75cd5a", 0, "Çekmeköy", "8908d845-753b-4c1d-8760-93d653b189bd", new DateTime(1999, 12, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 13, 13, 38, 48, 52, DateTimeKind.Local).AddTicks(6676), "ulasdurmus1@gmail.com", true, "Ulaş", "Erkek", null, "Durmuş", false, null, "ULASDURMUS1@GMAIL.COM", "ULAŞDURMUŞ", "ULASDURMUS", "AQAAAAIAAYagAAAAEJSbkZ+jEnRgiG1mqLwZ9kU7mOeYrkDoHit7I2QR8+7vnGEoyZxl47vE6kCygifo4A==", null, false, "073dd180-0158-4dec-8b74-93e2678be737", false, "ulasdurmus" },
                    { "d9034f11-8877-4c14-ae85-442d2449b547", 0, "2345 Cedar Avenue, San Francisco", "745688e2-88ff-457b-a7f9-d9f888ff87e6", new DateTime(1980, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 13, 13, 38, 48, 52, DateTimeKind.Local).AddTicks(6794), "david.lee@example.com", true, "David", "Male", null, "Lee", false, null, "DAVID.LEE@EXAMPLE.COM", "DAVİDLEE", "DAVIDL", "AQAAAAIAAYagAAAAEDEp7kcgvdX/5eAcoSdYpM6gU2QMY7A8T/3VQi5vAx4lLBlf5oABPfTpBuK0Xwc5Ag==", null, false, "e5b9c15b-446a-4cd0-bcf7-fdbb6bad35d1", false, "davidl" },
                    { "eba9d9f5-bcde-4039-8e38-2f3292ed46b6", 0, "5678 Oak Avenue, Los Angeles", "295062b7-4498-4f8d-99ae-e5647c885e3d", new DateTime(1985, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 5, 13, 13, 38, 48, 52, DateTimeKind.Local).AddTicks(6720), "alice.johnson@example.com", true, "Alice", "Female", null, "Johnson", false, null, "ALICE.JOHNSON@EXAMPLE.COM", "ALİCEJOHNSON", "ALICEJ", "AQAAAAIAAYagAAAAEOlP1pBRIIY0eKZnRmQKXz8B4WmanG/rFFNYEUAqkYTfh1iaegUJ1qvGbFaZkOQ2VQ==", null, false, "dd6f9ba4-4e61-4f9a-beb9-a7d9eeab2fdf", false, "alicej" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "IsApproved", "IsDeleted", "Name", "Url" },
                values: new object[,]
                {
                    { 1, "Bireylerin duygusal, zihinsel ve davranışsal sorunlarını değerlendirmek ve bireysel olarak danışmanlık sağlamak.", true, false, "Bireysel Danışmanlık", "bireysel-danismanlik" },
                    { 2, "Çiftler ve aileler arasındaki ilişki sorunlarını değerlendirmek ve terapi yöntemleri kullanarak çiftler ve ailelerle danışmanlık sağlamak.", true, false, "Çift ve Aile Danışmanlığı", "cift-ve-aile-danismanligi" },
                    { 3, "Ergenlerin duygusal, sosyal ve davranışsal gelişimini desteklemek, ergenlerle danışmanlık yapmak ve onlara rehberlik etmek.", true, false, "Ergen Danışmanlığı", "ergen-danismanligi" },
                    { 4, "Madde bağımlılığı veya diğer bağımlılıklarla mücadele eden bireylere danışmanlık sağlamak, bağımlılıkları değerlendirmek ve tedavi planları oluşturmak.", true, false, "Bağımlılık Danışmanlığı", "bagimlilik-danismanligi" },
                    { 5, "Krize giren bireylere destek sağlamak, travma sonrası stres bozukluğu ve diğer travma reaksiyonlarına müdahale etmek, travma sonrası iyileşmeyi desteklemek.", true, false, "Kriz ve Travma Danışmanlığı", "kriz-ve-tramva-danismanligi" },
                    { 6, "Bireylerin sosyal becerilerini geliştirmek, iletişim, ilişki kurma, sınır koyma gibi sosyal becerileri öğretmek ve desteklemek.", true, false, "Sosyal Beceri Eğitimi", "sosyal-beceri-egitimi" },
                    { 7, "Bireylerin kendini değerlendirmesine ve keşfetmesine yardımcı olmak, güçlü yönleri ve zorlukları tanımak ve kişisel büyümeyi desteklemek.", true, false, "Öz-değerlendirme ve Kendini Keşfetme", "oz-fegerlendirme-ve-kendini-kesfetme" },
                    { 8, "Bireylerin yaşam değişimleri, dönem geçişleri ve adaptasyon süreçlerine danışmanlık sağlamak, değişime uyum sürecini desteklemek ve başa çıkma becerilerini geliştirmek.", true, false, "Yaşam Değişimleri ve Geçişler", "yasam-degisimi-ve-gecisler" }
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Psikoloji" },
                    { 2, "Rehberlik ve Psikolojik Danışmanlık" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "IsApproved", "Url" },
                values: new object[,]
                {
                    { 1, true, "messages-3(16).jpg" },
                    { 2, true, "messages-3(3).jpg" },
                    { 3, true, "messages-3(16).jpg" }
                });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "Id", "ClientId", "IsConfirmed", "IsPaid", "Price", "ReservationDate", "ServiceId", "TherapistId" },
                values: new object[,]
                {
                    { 1, 1, true, true, 500m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1 },
                    { 2, 2, true, false, 500m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2 },
                    { 3, 3, true, true, 500m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "Description", "IsApproved", "IsConfirmed", "Price", "TherapistId", "Url" },
                values: new object[,]
                {
                    { 1, "Seans açıklaması 1", true, true, 500m, 1, "service1" },
                    { 2, "Seans açıklaması 2", true, true, 400m, 2, "service2" },
                    { 3, "Seans açıklaması 3", true, true, 200m, 3, "service3" }
                });

            migrationBuilder.InsertData(
                table: "TherapistTitles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Uzman Psikolog" },
                    { 2, "Klinik Psikolog" },
                    { 3, "Sağlık Psikoloğu" },
                    { 4, "İş ve Örgüt Psikoloğu" },
                    { 5, "Ruh Sağlığı ve Rehabilitasyon Psikoloğu" },
                    { 6, "Uzman Psikolojik Danışman" },
                    { 7, "Okul Psikolojik Danışmanı" },
                    { 8, "Kariyer Psikolojik Danışmanı" },
                    { 9, "Bağımlılık Danışmanı" },
                    { 10, "Sosyal Hizmet Uzmanı" }
                });

            migrationBuilder.InsertData(
                table: "Universities",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Adana Alparslan Türkeş Bilim ve Teknoloji Üniversitesi" },
                    { 2, "Adana Bilim ve Teknoloji Üniversitesi" },
                    { 3, "Adıyaman Üniversitesi" },
                    { 4, "Afyonkarahisar Sağlık Bilimleri Üniversitesi" },
                    { 5, "Afyonkarahisar Sandıklı Onmyo Meslek Yüksekokulu" },
                    { 6, "Ağrı İbrahim Çeçen Üniversitesi" },
                    { 7, "Ahi Evran Üniversitesi" },
                    { 8, "Akdeniz Üniversitesi" },
                    { 9, "Aksaray Üniversitesi" },
                    { 10, "Alanya Alaaddin Keykubat Üniversitesi" },
                    { 11, "Altınbaş Üniversitesi" },
                    { 12, "Amasya Üniversitesi" },
                    { 13, "Anadolu Üniversitesi" },
                    { 14, "Ankara Hacı Bayram Veli Üniversitesi" },
                    { 15, "Ankara Üniversitesi" },
                    { 16, "Ankara Yıldırım Beyazıt Üniversitesi" },
                    { 17, "Antalya Akev Üniversitesi" },
                    { 18, "Antalya Bilim Üniversitesi" },
                    { 19, "Arda Üniversitesi" },
                    { 20, "Ardahan Üniversitesi" },
                    { 21, "Artvin Çoruh Üniversitesi" },
                    { 22, "Atatürk Üniversitesi" },
                    { 23, "Avrasya Üniversitesi" },
                    { 24, "Aydın Adnan Menderes Üniversitesi" },
                    { 25, "Aydın Üniversitesi" },
                    { 26, "Bahçeşehir Üniversitesi" },
                    { 27, "Balıkesir Üniversitesi" },
                    { 28, "Bandırma Onyedi Eylül Üniversitesi" },
                    { 29, "Bartın Üniversitesi" },
                    { 30, "Batman Üniversitesi" },
                    { 31, "Beykent Üniversitesi" },
                    { 32, "Bilecik Şeyh Edebali Üniversitesi" },
                    { 33, "Bingöl Üniversitesi" },
                    { 34, "Bursa Orhangazi Üniversitesi" },
                    { 35, "Bursa Teknik Üniversitesi" },
                    { 36, "Çağ Üniversitesi" },
                    { 37, "Çankaya Üniversitesi" },
                    { 38, "Çanakkale Onsekiz Mart Üniversitesi" },
                    { 39, "Çankırı Karatekin Üniversitesi" },
                    { 40, "Çukurova Üniversitesi" },
                    { 41, "Dicle Üniversitesi" },
                    { 42, "Dokuz Eylül Üniversitesi" },
                    { 43, "Dumlupınar Üniversitesi" },
                    { 44, "Düzce Üniversitesi" },
                    { 45, "Ege Üniversitesi" },
                    { 46, "Erciyes Üniversitesi" },
                    { 47, "Erzincan Üniversitesi" },
                    { 48, "Erzurum Atatürk Üniversitesi" },
                    { 49, "Erzurum Teknik Üniversitesi" },
                    { 50, "Eskişehir Osmangazi Üniversitesi" },
                    { 51, "Eskişehir Teknik Üniversitesi" },
                    { 52, "Fırat Üniversitesi" },
                    { 53, "Galatasaray Üniversitesi" },
                    { 54, "Gaziantep Üniversitesi" },
                    { 55, "Gaziantep Bilim ve Teknoloji Üniversitesi" },
                    { 56, "Gazi Üniversitesi" },
                    { 57, "Gebze Teknik Üniversitesi" },
                    { 58, "Giresun Üniversitesi" },
                    { 59, "Gümüşhane Üniversitesi" },
                    { 60, "Hacettepe Üniversitesi" },
                    { 61, "Hakkari Üniversitesi" },
                    { 62, "Harran Üniversitesi" },
                    { 63, "Hitit Üniversitesi" },
                    { 64, "Iğdır Üniversitesi" },
                    { 65, "İnönü Üniversitesi" },
                    { 66, "İstanbul Medeniyet Üniversitesi" },
                    { 67, "İstanbul Sabahattin Zaim Üniversitesi" },
                    { 68, "İstanbul Teknik Üniversitesi" },
                    { 69, "İstanbul Ticaret Üniversitesi" },
                    { 70, "İstanbul Üniversitesi" },
                    { 71, "İstinye Üniversitesi" },
                    { 72, "İzmir Bakırçay Üniversitesi" },
                    { 73, "İzmir Demokrasi Üniversitesi" },
                    { 74, "İzmir Ekonomi Üniversitesi" },
                    { 75, "İzmir Kâtip Çelebi Üniversitesi" },
                    { 76, "Kafkas Üniversitesi" },
                    { 77, "Kahramanmaraş İstiklal Üniversitesi" },
                    { 78, "Kahramanmaraş Sütçü İmam Üniversitesi" },
                    { 79, "Karabük Üniversitesi" },
                    { 80, "Karadeniz Teknik Üniversitesi" },
                    { 81, "Karamanoğlu Mehmetbey Üniversitesi" },
                    { 82, "Kastamonu Üniversitesi" },
                    { 83, "Koç Üniversitesi" },
                    { 84, "Konya Necmettin Erbakan Üniversitesi" },
                    { 85, "KTO Karatay Üniversitesi" },
                    { 86, "Malatya Turgut Özal Üniversitesi" },
                    { 87, "Manisa Celal Bayar Üniversitesi" },
                    { 88, "Mardin Artuklu Üniversitesi" },
                    { 89, "Marmara Üniversitesi" },
                    { 90, "Mehmet Akif Ersoy Üniversitesi" },
                    { 91, "Mersin Üniversitesi" },
                    { 92, "Mimar Sinan Güzel Sanatlar Üniversitesi" },
                    { 93, "Muğla Sıtkı Koçman Üniversitesi" },
                    { 94, "Muş Alparslan Üniversitesi" },
                    { 95, "Namık Kemal Üniversitesi" },
                    { 96, "Nevşehir Hacı Bektaş Veli Üniversitesi" },
                    { 97, "Niğde Ömer Halisdemir Üniversitesi" },
                    { 98, "Nuh Naci Yazgan Üniversitesi" },
                    { 99, "Ordu Üniversitesi" },
                    { 100, "Orta Doğu Teknik Üniversitesi" },
                    { 101, "Osmaniye Korkut Ata Üniversitesi" },
                    { 102, "Pamukkale Üniversitesi" },
                    { 103, "Recep Tayyip Erdoğan Üniversitesi" },
                    { 104, "Sakarya Üniversitesi" },
                    { 105, "Selahaddin Eyyubi Üniversitesi" },
                    { 106, "Siirt Üniversitesi" },
                    { 107, "Sinop Üniversitesi" },
                    { 108, "Sivas Cumhuriyet Üniversitesi" },
                    { 109, "Süleyman Demirel Üniversitesi" },
                    { 110, "Trakya Üniversitesi" },
                    { 111, "Tunceli Üniversitesi" },
                    { 112, "Uşak Üniversitesi" },
                    { 113, "Yalova Üniversitesi" },
                    { 114, "Yıldırım Beyazıt Üniversitesi" },
                    { 115, "Yozgat Bozok Üniversitesi" },
                    { 116, "Zonguldak Bülent Ecevit Üniversitesi" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "5b2458f2-3be9-4be3-ad1b-1e30eeb1da0d", "0f80dbad-d5f4-4f82-a780-165aa66b7d07" },
                    { "7619050e-3a6a-4a33-9491-ea5b2db63c0b", "211e2b50-d08d-4dc7-9944-de813060f3df" },
                    { "7619050e-3a6a-4a33-9491-ea5b2db63c0b", "35891788-47d3-4645-87f0-fda34734bab3" },
                    { "5b2458f2-3be9-4be3-ad1b-1e30eeb1da0d", "5c4080ce-3cee-4051-8660-4b7f208681ce" },
                    { "7619050e-3a6a-4a33-9491-ea5b2db63c0b", "86babe7e-9dea-4cf2-9faf-4439b64d13ba" },
                    { "8d07f8b3-1020-4da7-9d57-b025719e6200", "b7082603-2d69-4adc-bc4e-1e294a75cd5a" },
                    { "5b2458f2-3be9-4be3-ad1b-1e30eeb1da0d", "d9034f11-8877-4c14-ae85-442d2449b547" },
                    { "4dd382ce-bc59-4ff5-a5d3-446a11d34941", "eba9d9f5-bcde-4039-8e38-2f3292ed46b6" }
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "IsApproved", "Url", "UserId" },
                values: new object[,]
                {
                    { 1, true, "1", "5c4080ce-3cee-4051-8660-4b7f208681ce" },
                    { 2, false, "2", "d9034f11-8877-4c14-ae85-442d2449b547" },
                    { 3, true, "3", "0f80dbad-d5f4-4f82-a780-165aa66b7d07" }
                });

            migrationBuilder.InsertData(
                table: "Educations",
                columns: new[] { "Id", "DepartmentId", "EndedDate", "StartedDate", "UniversityId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2014, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2010, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, 2, new DateTime(209, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2005, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 3, 1, new DateTime(2018, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2013, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 }
                });

            migrationBuilder.InsertData(
                table: "ServiceCategories",
                columns: new[] { "CategoryId", "ServiceId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 4, 2 },
                    { 3, 3 },
                    { 5, 3 }
                });

            migrationBuilder.InsertData(
                table: "ClientServices",
                columns: new[] { "ClientId", "ReservationId", "ServiceId" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 1, 2, 2 },
                    { 1, 3, 3 },
                    { 2, 1, 2 },
                    { 2, 2, 3 },
                    { 3, 2, 1 },
                    { 3, 3, 2 },
                    { 3, 1, 3 }
                });

            migrationBuilder.InsertData(
                table: "Therapists",
                columns: new[] { "Id", "Description", "EducationId", "IsApproved", "IsOnline", "TitleId", "Url", "UserId" },
                values: new object[,]
                {
                    { 1, "Therapist Açıklama 1", 1, true, false, 1, "therapist1", "86babe7e-9dea-4cf2-9faf-4439b64d13ba" },
                    { 2, "Therapist Açıklama 2", 2, true, false, 1, "therapist2", "35891788-47d3-4645-87f0-fda34734bab3" },
                    { 3, "Therapist Açıklama 3", 3, true, false, 1, "therapist3", "211e2b50-d08d-4dc7-9944-de813060f3df" }
                });

            migrationBuilder.InsertData(
                table: "ClientTherapists",
                columns: new[] { "ClientId", "ReservationId", "TherapistId" },
                values: new object[,]
                {
                    { 1, 3, 1 },
                    { 1, 2, 2 },
                    { 1, 1, 3 }
                });

            migrationBuilder.InsertData(
                table: "ServiceTherapists",
                columns: new[] { "ServiceId", "TherapistId" },
                values: new object[,]
                {
                    { 1, 2 },
                    { 2, 1 },
                    { 3, 3 }
                });

            migrationBuilder.InsertData(
                table: "TherapistCategories",
                columns: new[] { "CategoryId", "TherapistId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 1 },
                    { 3, 1 },
                    { 4, 1 },
                    { 1, 2 },
                    { 5, 2 },
                    { 7, 2 },
                    { 1, 3 },
                    { 8, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ImageId",
                table: "AspNetUsers",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Certificates_TherapistId",
                table: "Certificates",
                column: "TherapistId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_UserId",
                table: "Clients",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientServices_ReservationId",
                table: "ClientServices",
                column: "ReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientServices_ServiceId",
                table: "ClientServices",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientTherapists_ReservationId",
                table: "ClientTherapists",
                column: "ReservationId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientTherapists_TherapistId",
                table: "ClientTherapists",
                column: "TherapistId");

            migrationBuilder.CreateIndex(
                name: "IX_Educations_DepartmentId",
                table: "Educations",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Educations_UniversityId",
                table: "Educations",
                column: "UniversityId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceCategories_CategoryId",
                table: "ServiceCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceTherapists_ServiceId",
                table: "ServiceTherapists",
                column: "ServiceId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ServiceTherapists_TherapistId",
                table: "ServiceTherapists",
                column: "TherapistId");

            migrationBuilder.CreateIndex(
                name: "IX_TherapistCategories_CategoryId",
                table: "TherapistCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Therapists_EducationId",
                table: "Therapists",
                column: "EducationId");

            migrationBuilder.CreateIndex(
                name: "IX_Therapists_TitleId",
                table: "Therapists",
                column: "TitleId");

            migrationBuilder.CreateIndex(
                name: "IX_Therapists_UserId",
                table: "Therapists",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Certificates");

            migrationBuilder.DropTable(
                name: "ClientServices");

            migrationBuilder.DropTable(
                name: "ClientTherapists");

            migrationBuilder.DropTable(
                name: "ServiceCategories");

            migrationBuilder.DropTable(
                name: "ServiceTherapists");

            migrationBuilder.DropTable(
                name: "TherapistCategories");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Therapists");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Educations");

            migrationBuilder.DropTable(
                name: "TherapistTitles");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Universities");
        }
    }
}
