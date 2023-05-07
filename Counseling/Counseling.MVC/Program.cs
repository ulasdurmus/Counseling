using Counseling.Business.Abstract;
using Counseling.Business.Concrete;
using Counseling.Data.Abstract;
using Counseling.Data.Concrete.Context;
using Counseling.Data.Concrete.EfCoreRepositories;
using Counseling.Entity.Entity.Identitiy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Sqlite Connection
builder.Services.AddDbContext<CounselingContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("SqliteConnection")));
//Identity Package
builder.Services.AddIdentity<User, Role>()
    .AddEntityFrameworkStores<CounselingContext>()
    .AddDefaultTokenProviders();

// User Settings
builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = true;

    options.Lockout.MaxFailedAccessAttempts = 3;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);

    options.User.RequireUniqueEmail = true;

    options.SignIn.RequireConfirmedEmail = false;
    options.SignIn.RequireConfirmedPhoneNumber = false;
});

//Cookie Settings
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/account/login";
    options.LogoutPath = "/account/logout";
    options.AccessDeniedPath = "/account/accessdenied";
    options.SlidingExpiration = true;
    options.ExpireTimeSpan = TimeSpan.FromDays(10);
    options.Cookie = new CookieBuilder
    {
        HttpOnly = true,
        SameSite = SameSiteMode.Strict,
        Name = ".Counseling.Security.Cookie"
    };
});

//Add Services-Manager
builder.Services.AddScoped<ICategoryService, CategoryManager>();
builder.Services.AddScoped<IClientService, ClientManager>();
builder.Services.AddScoped<IServiceService,ServiceManager>();
builder.Services.AddScoped<ITherapistService,TherapistManager>();
builder.Services.AddScoped<IImageService, ImageManager>();
builder.Services.AddScoped<IReservationService,ReservationManager>();
//Add Repository
builder.Services.AddScoped<ICategoryRepository, EfCoreCategoryRepository>();
builder.Services.AddScoped<IClientRepository,EfCoreClientRepository>();
builder.Services.AddScoped<IServiceRepository,EfCoreServiceRepository>();
builder.Services.AddScoped<ITherapistRepository,EfCoreTherapistRepository>();
builder.Services.AddScoped<IImageRepository, EfCoreImageRepository>();
builder.Services.AddScoped<IReservationRepository,EfCoreReservationRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapAreaControllerRoute(
    name: "Admin",
    areaName: "Admin",
    pattern: "admin/{controller=Home}/{action=Index}/{id?}"
    );
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
