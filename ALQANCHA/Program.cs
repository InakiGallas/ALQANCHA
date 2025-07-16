using Microsoft.EntityFrameworkCore;
using ALQCANCHA.Context;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Configurar el DbContext con SQL Server
builder.Services.AddDbContext<AlqanchaDatabaseContext>(options =>
    options.UseSqlServer(builder.Configuration["ConnectionString:ALQANCHADBConnection"]));

// Configurar los servicios de controladores con vistas y suprimir la validación implícita
builder.Services.AddControllersWithViews(options =>
    options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true);

var app = builder.Build();

// Configuración del pipeline de la aplicación
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
