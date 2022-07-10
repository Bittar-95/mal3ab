using Microsoft.EntityFrameworkCore;
using AspnetRun.Infrastructure.Data;
using AspnetRun.Core.Entities;
using AspnetRun.Application.Interfaces;
using AspnetRun.Application.Services;
using AspnetRun.Core.Repositories;
using AspnetRun.Infrastructure.Repository;
using AspnetRun.Core.Mapper;

var builder = WebApplication.CreateBuilder(args);
var connectionString = "server=127.0.0.1;database=mal3ab;uid=root;password=123456789"/*builder.Configuration.GetConnectionString("appContextConnection") */?? throw new InvalidOperationException("Connection string 'appContextConnection' not found.");

builder.Services.AddDbContext<appContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))); ;

builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<appContext>();

builder.Services.AddScoped<ICourtsRepository, CourtRepository>();
builder.Services.AddScoped<ICourtService, CourtService>();
builder.Services.AddScoped<IReservationRepository, ReservationRepository>();
builder.Services.AddScoped<IReservationService, ReservationService>();
builder.Services.AddScoped<ICourtTypeRepository, CourtTypeRepository>();
builder.Services.AddScoped<ICourtTypeService, CourtTypeService>();
builder.Services.AddScoped<IWorkingHoursRepository, WorkingHoursRepository>();
builder.Services.AddScoped<IWorkingHoursService, WorkingHoursService>();
builder.Services.AddScoped<MapperConfig>();

// Add services to the container.
builder.Services.AddControllersWithViews();

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
app.UseAuthentication(); ;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
