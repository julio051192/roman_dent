using Microsoft.EntityFrameworkCore;
using romandent.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// ?? AGREGAR DBCONTEXT (ESTO TE FALTA) ??
builder.Services.AddDbContext<RomanDentContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("RomanDentConn")));

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
// ?? AGREGAR USESTATICFILES (ESTO TE FALTA) ??
app.UseStaticFiles();
app.UseRouting();

app.UseAuthorization();

// ?? MODIFICAR LAS RUTAS PARA QUE FUNCIONEN CON .NET 10 ??
//app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();  