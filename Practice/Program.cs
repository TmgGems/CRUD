using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Practice;
using Practice.Data;
using Practice.DI;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection")));
//registering dependency
builder.Services.AddTransient<IProvinceService,ProvinceService>();
builder.Services.AddTransient<ISimpleInterest, SimpleInterest>();
builder.Services.AddTransient<IUserService, UserService>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(config =>
    {
        config.ExpireTimeSpan = TimeSpan.FromSeconds(5);
        config.LoginPath = "/LogIn";
        //config.AccessDeniedPath = "/home/AccessDenied";
    });

builder.Services.AddAuthorization(options =>
{ 
options.FallbackPolicy = new AuthorizationPolicyBuilder()
.RequireAuthenticatedUser()
.Build();
});

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
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
