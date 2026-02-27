using Microsoft.EntityFrameworkCore;
using OnlineShoppingApp.Data;
using OnlineShoppingApp.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(
        "Server=(localdb)\\MSSQLLocalDB;Database=OnlineShoppingDB;Trusted_Connection=True;MultipleActiveResultSets=true"));

builder.Services.AddSingleton<ICartService, CartService>();

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Product}/{action=Index}/{id?}");

app.Run();