using LinkShorteningSite.Data;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using LinkShorteningSite.Core.Interfaces.Services;
using LinkShorteningSite.Domain.Services;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<LinkShorteningSiteContext>(opt
    => opt.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString), b => b.MigrationsAssembly("LinkShorteningSite.Data")));

// Add services to the container.
builder.Services.AddControllersWithViews();

Assembly.Load("LinKShorteningSite.CQRS");
builder.Services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());

//AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<IUrlService, UrlService>();

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Url}/{action=Index}/{id?}");

app.Run();
