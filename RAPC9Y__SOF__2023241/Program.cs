using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using RAPC9Y__SOF__2023241.Data;
using RAPC9Y__SOF__2023241.Helper;
using RAPC9Y_SOF_2023241.MVC.Data;
using RAPC9Y_SOF_2023241.MVC.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("AzureConnection");
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddTransient<ILoLRepository, LoLRepository>();
builder.Services.AddDbContext<LoLDbContext>(opt =>
{
    opt
   .UseSqlServer(connectionString)
   .UseLazyLoadingProxies();
});


builder.Services.AddDefaultIdentity<SiteUser>(options => 
{
    options.SignIn.RequireConfirmedAccount = true;
    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 4;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;

})
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<LoLDbContext>();

builder.Services.AddAuthentication().AddFacebook(opt =>
{
    opt.AppId = "608115458103194";
    opt.AppSecret = "6368bc0c8405cb0181d946ec6f16b434";
});

builder.Services.AddTransient<IEmailSender, EmailSender>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

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
