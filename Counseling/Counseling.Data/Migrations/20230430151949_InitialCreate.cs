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
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TherapistId = table.Column<int>(type: "INTEGER", nullable: false),
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
                });

            migrationBuilder.CreateTable(
                name: "ClientServices",
                columns: table => new
                {
                    ClientId = table.Column<int>(type: "INTEGER", nullable: false),
                    ServiceId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientServices", x => new { x.ClientId, x.ServiceId });
                    table.ForeignKey(
                        name: "FK_ClientServices_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
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
                    TherapistId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientTherapists", x => new { x.ClientId, x.TherapistId });
                    table.ForeignKey(
                        name: "FK_ClientTherapists_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
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
                    { "760f0e57-2017-473a-bca1-6704714ee68d", null, "Kendilerine özel, kısıtlı izin verilmiş admin paneline sahip olabilir.", "Therapist", "THERAPIST" },
                    { "cd57a5ae-1dc8-431d-b311-624b8f61151a", null, "Tam yönetim hakkı bulunur.", "SuperAdmin", "SUPERADMIN" },
                    { "e732ccbd-cdb2-46b2-8a8a-a5de025ce223", null, "Kısıtlı yönetim hakkı bulunur.", "Admin", "ADMIN" },
                    { "f52464fc-b7ba-4852-b22d-b111e7d681d6", null, "Kendilerine özel, hesap bilgilerini yöenetbilecekleri bir panele sahip olurlar.", "Client", "CLIENT" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "DateOfBirth", "DateOfRegistration", "Email", "EmailConfirmed", "FirstName", "Gender", "ImageId", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedName", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "0f80dbad-d5f4-4f82-a780-165aa66b7d07", 0, "8765 Birch Street, Miami", "7e59debb-0868-437a-afd1-be6b6e3e10b1", new DateTime(1995, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 30, 18, 19, 48, 6, DateTimeKind.Local).AddTicks(4970), "sophia.chen@example.com", false, "Sophia", "Female", null, "Chen", false, null, "SOPHIA.CHEN@EXAMPLE.COM", "SOPHİACHEN", "SOPHIAC", "AQAAAAIAAYagAAAAECiPWsxAUXrcO+pH4CHDQccNccojpTV1gv3NODjdQ+DVs+rc0LwBME9Hqq/MqyDbJg==", null, false, "cd44644c-d6d2-4b78-9ccd-a269038b33cf", false, "sophiac" },
                    { "211e2b50-d08d-4dc7-9944-de813060f3df", 0, "1234 Elm Street", "ae660aca-b323-4ab8-adb2-bf02774e0c16", new DateTime(1995, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 30, 18, 19, 48, 6, DateTimeKind.Local).AddTicks(4926), "emma.johnson@example.com", true, "Emma", "Female", null, "Johnson", false, null, "EMMA.JOHNSON@EXAMPLE.COM", "EMMAJOHNSON", "EMMA.JOHNSON", "AQAAAAIAAYagAAAAEOtuqqcA2XP5GVAwrYmkhj83TDvt5YQCM+1bozj6H1kHBVXSpUp/0pb2JbF9hNlXQw==", null, false, "937c5e47-1488-47c2-8a4e-4fd33552413a", false, "emma.johnson" },
                    { "35891788-47d3-4645-87f0-fda34734bab3", 0, "9876 Maple Street, New York", "d885829e-cb77-44e1-9b7c-c4f7968bb44a", new DateTime(1992, 10, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 30, 18, 19, 48, 6, DateTimeKind.Local).AddTicks(4909), "bob.smith@example.com", false, "Bob", "Male", null, "Smith", false, null, "BOB.SMITH@EXAMPLE.COM", "BOBSMİTH", "BOBSMITH", "AQAAAAIAAYagAAAAEN5LWokQiX+4Wpt3IzLGtD0vYsEpi0hNEtFEr1JYtcZ99DzeWldPHYHFqcaPZhxT7w==", null, false, "f1832b70-308c-4752-9dbc-fca9de089e12", false, "bobsmith" },
                    { "5c4080ce-3cee-4051-8660-4b7f208681ce", 0, "3456 Pine Road, Chicago", "c6f73613-7db9-4112-bc14-5bcb0864b3e6", new DateTime(1998, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 30, 18, 19, 48, 6, DateTimeKind.Local).AddTicks(4941), "emma.brown@example.com", true, "Emma", "Female", null, "Brown", false, null, "EMMA.BROWN@EXAMPLE.COM", "EMMABROWN", "EMMAB", "AQAAAAIAAYagAAAAEP7u82bPK4MSXLVz7qD6zdPu6QyB4UISSW9NsYaCx4MzdpfQffxUMZ6INb7zOfx6Mg==", null, false, "f02cfdfa-a8c3-48f4-b727-d47fe1e09533", false, "emmab" },
                    { "86babe7e-9dea-4cf2-9faf-4439b64d13ba", 0, "1234 Elm Street, Springfield", "fecd68fc-7e3e-495d-8162-06b9502de861", new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 30, 18, 19, 48, 6, DateTimeKind.Local).AddTicks(4896), "john.doe@example.com", true, "John", "Male", null, "Doe", false, null, "JOHN.DOE@EXAMPLE.COM", "JOHNDOE", "JOHNDOE", "AQAAAAIAAYagAAAAECcGTjyh5vvw/jzbN5CtlYRVYcck35q/7Nci94jc/nrQczWhezgOXtDY6Ty3B8gJDA==", null, false, "754956da-bd15-4346-8c8b-4b103f5f7eca", false, "johndoe" },
                    { "b7082603-2d69-4adc-bc4e-1e294a75cd5a", 0, "Çekmeköy", "358dbef5-ae6c-48ad-ac0b-080ff15a3ed1", new DateTime(1999, 12, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 30, 18, 19, 48, 6, DateTimeKind.Local).AddTicks(4845), "ulasdurmus1@gmail.com", true, "Ulaş", "Erkek", null, "Durmuş", false, null, "ULASDURMUS1@GMAIL.COM", "ULAŞDURMUŞ", "ULASDURMUS", "AQAAAAIAAYagAAAAEKlJInJbSI7h5d2nAjQS8lk+sBuj3MprucKXWKvYnuY9g6RPwyzjDLc5EIkxWjiS8Q==", null, false, "0f4f79c8-63e2-432c-b70a-3f0ae5d9accd", false, "ulasdurmus" },
                    { "d9034f11-8877-4c14-ae85-442d2449b547", 0, "2345 Cedar Avenue, San Francisco", "f3a66279-2a33-46ae-ba27-c255674c3ba8", new DateTime(1980, 11, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 30, 18, 19, 48, 6, DateTimeKind.Local).AddTicks(4954), "david.lee@example.com", true, "David", "Male", null, "Lee", false, null, "DAVID.LEE@EXAMPLE.COM", "DAVİDLEE", "DAVIDL", "AQAAAAIAAYagAAAAEArrIhQfiCfslQ0U7pHx/aF6LMaymw9F2vWSE7tEajvABqotSzcJYY0wwHkejZYDYw==", null, false, "80afcc1f-4a02-4447-8b80-d75e9d001de8", false, "davidl" },
                    { "eba9d9f5-bcde-4039-8e38-2f3292ed46b6", 0, "5678 Oak Avenue, Los Angeles", "a67d1087-592c-4cf6-bcd5-cb6bba22e849", new DateTime(1985, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 4, 30, 18, 19, 48, 6, DateTimeKind.Local).AddTicks(4883), "alice.johnson@example.com", true, "Alice", "Female", null, "Johnson", false, null, "ALICE.JOHNSON@EXAMPLE.COM", "ALİCEJOHNSON", "ALICEJ", "AQAAAAIAAYagAAAAEBR+be5YRgKu/lpoH+0kGlfiCsvHmWnTNyg/1RElM2OrUER7seWn4R6IEpbSVskVgQ==", null, false, "bc7a2234-b5ec-469f-bb14-4502bffb66c9", false, "alicej" }
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
                values: new object[] { 1, true, "Image1" });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "IsApproved", "IsConfirmed", "Price", "TherapistId", "Url" },
                values: new object[,]
                {
                    { 1, true, true, 500m, 1, "service1" },
                    { 2, true, true, 400m, 2, "service2" },
                    { 3, true, true, 200m, 3, "service3" }
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
                    { "f52464fc-b7ba-4852-b22d-b111e7d681d6", "0f80dbad-d5f4-4f82-a780-165aa66b7d07" },
                    { "760f0e57-2017-473a-bca1-6704714ee68d", "211e2b50-d08d-4dc7-9944-de813060f3df" },
                    { "760f0e57-2017-473a-bca1-6704714ee68d", "35891788-47d3-4645-87f0-fda34734bab3" },
                    { "f52464fc-b7ba-4852-b22d-b111e7d681d6", "5c4080ce-3cee-4051-8660-4b7f208681ce" },
                    { "760f0e57-2017-473a-bca1-6704714ee68d", "86babe7e-9dea-4cf2-9faf-4439b64d13ba" },
                    { "cd57a5ae-1dc8-431d-b311-624b8f61151a", "b7082603-2d69-4adc-bc4e-1e294a75cd5a" },
                    { "f52464fc-b7ba-4852-b22d-b111e7d681d6", "d9034f11-8877-4c14-ae85-442d2449b547" },
                    { "e732ccbd-cdb2-46b2-8a8a-a5de025ce223", "eba9d9f5-bcde-4039-8e38-2f3292ed46b6" }
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
                columns: new[] { "ClientId", "ServiceId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 3 },
                    { 2, 2 },
                    { 2, 3 },
                    { 3, 1 },
                    { 3, 2 },
                    { 3, 3 }
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
                columns: new[] { "ClientId", "TherapistId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 3 }
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
                name: "IX_ClientServices_ServiceId",
                table: "ClientServices",
                column: "ServiceId");

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
                name: "TherapistTitles");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Clients");

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
                name: "Images");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Universities");
        }
    }
}
