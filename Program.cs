using MongoDB.Driver;
using OnlineLibrary.Data;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.DependencyInjection;
using OnlineLibrary.Interfaces;
using OnlineLibrary.Models;

//using MongoBookStoreApp.Contracts;
//using OnlineLibrary.Models;

var builder = WebApplication.CreateBuilder(args);
var settings = builder.Configuration.GetSection(nameof(Settings)).Get<Settings>();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddScoped<IBooks, BooksDBContext>();
builder.Services.AddScoped<IUsers, UsersDBContext>();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(10);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});


//builder.Services.AddDbContext<Settings>();
//builder.Services.AddSingleton<OnlineLibraryDatabaseSettings>();




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

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
