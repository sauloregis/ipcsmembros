using FluentValidation;
using ipcsmembros.Contexts;
using ipcsmembros.Validators.Membros;
using ipcsmembros.ViewModels.Membros;
using Microsoft.EntityFrameworkCore.Design;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews(options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true);
builder.Services.AddDbContext<MembroContext>();
builder.Services.AddScoped<IValidator<AdicionarMembroViewModel>, AdicionarMembroValidator>();  
builder.Services.AddScoped<IValidator<EditarMembroViewModel>, EditarMembroValidator>();  

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
    //name: "default",
    //pattern: "{controller=Home}/{action=Index}/{id?}");
    name: "default",
    pattern: "{controller=Account}/{action=Index}/{id?}");

app.Run();
