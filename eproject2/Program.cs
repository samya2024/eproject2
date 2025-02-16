using eproject2.Data;
using eproject2.Reposatory.Interface;
using eproject2.Reposatory.Services;
using eproject2.Repositories.Interfaces;
using eproject2.Repositories.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Runtime.Versioning;



var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSession();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Auth/Login"; // Redirect to login
        options.LogoutPath = "/Auth/Logout"; // Redirect to logout
    });

// Add services to the container.
builder.Services.AddControllersWithViews();
var provider = builder.Services.BuildServiceProvider();
var config = provider.GetRequiredService<IConfiguration>();
builder.Services.AddDbContext<Context>(Options => Options.UseSqlServer(config.GetConnectionString("default")));
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped<IAuthRepository, AuthRepository>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IEmailSender, EmailSender>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseStaticFiles();
app.UseSession();
app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Auth}/{action=Register}/{id?}")
    .WithStaticAssets();



app.Run();
