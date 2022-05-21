using Patient_Management_System.Web.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Patient_Management_System.Web.Configuration;
using Patient_Management_System.Web.Contracts;
using Patient_Management_System.Web.Repositoriesy;
using Microsoft.AspNetCore.Identity.UI.Services;
using Patient_Management_System.Web.Services;
using Serilog;
using Microsoft.Extensions.DependencyInjection;
using Patient_Management_System.Web.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<Employee>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();


builder.Services.AddTransient<IEmailSender>(s => new EmailSender("localhost", 25, "no-reply@globalmanagementsystem"));

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IRoomRepository, RoomRepository>();
builder.Services.AddScoped<IPatientRepository, PatientRepository>();


builder.Services.AddAutoMapper(typeof(MapperConfig));

builder.Host.UseSerilog((ctx, lc) =>
    lc.WriteTo.Console()
    .ReadFrom.Configuration(ctx.Configuration));

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseSerilogRequestLogging();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
