using DataGridView.Storage.MsSql;
using Microsoft.EntityFrameworkCore;
using DataGridView.Services.Contracts;
using DataGridView.Services.Services;
using DataGridView.Storage.Contracts;

var builder = WebApplication.CreateBuilder(args);

System.Globalization.CultureInfo.DefaultThreadCurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
System.Globalization.CultureInfo.DefaultThreadCurrentUICulture = System.Globalization.CultureInfo.InvariantCulture;

// Add services to the container.
builder.Services.AddControllersWithViews();
var connection = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<MsSqlProductContext>(options => options.UseSqlServer(connection));
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductStorage, ProductRepository>();
builder.Services.AddScoped<IReader, MsSqlProductContext>();
builder.Services.AddScoped<IWriter, MsSqlProductContext>();

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

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
