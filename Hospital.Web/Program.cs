using Hospital.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Identity;
using Hospital.Repositories.Interfaces;
using Hospital.Services.Interfaces;
using Hospital.Services;
using Hospital.Models;
using Microsoft.AspNetCore.Identity.UI.Services;
using HospitalApp.Tests.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<HospitalAppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<ApplicationUser, IdentityRole<Guid>>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<HospitalAppDbContext>()
    .AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = true;
    options.Password.RequireLowercase = false;
    options.Password.RequiredUniqueChars = 6;

    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.AllowedForNewUsers = true;

    options.User.RequireUniqueEmail = true;
});
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

#region Repositories and services
builder.Services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();

builder.Services.AddScoped<IHospitalInfoRepository, HospitalInfoRepository>();
builder.Services.AddScoped<IHospitalInfoService, HospitalInfoService>();

builder.Services.AddScoped<IFeedbackFormRepository, FeedbackFormRepository>();
builder.Services.AddScoped<IFeedbackFormService, FeedbackFormService>();

builder.Services.AddScoped<IAppointmentRepository, AppointmentRepository>();
builder.Services.AddScoped<IAppointmentService, AppointmentService>();

builder.Services.AddScoped<IContactRepository, ContactRepository>();
builder.Services.AddScoped<IContactServices, ContactService>();

builder.Services.AddScoped<IDeparmentRepository, DepartmentRepository>();
builder.Services.AddScoped<IDepartmentService, DepartmentService>();

builder.Services.AddScoped<IRoomRepository, RoomRepository>();
builder.Services.AddScoped<IRoomService, RoomService>();
#endregion

builder.Services.ConfigureApplicationCookie(options =>
{
    options.AccessDeniedPath = "/Home/Error"; // Path to your Error action
});


builder.Services.AddTransient<IEmailSender>(sp =>
    new SmtpEmailSender(
        smtpServer: "smtp.example.com",
        smtpPort: 587,
        smtpUser: "your-email@example.com",
        smtpPass: "your-password"
    ));

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

app.UseAuthentication();;
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();
app.Run();
