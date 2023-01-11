using Microsoft.EntityFrameworkCore;
using StoreSample.ShopUI.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
var cnnstring = builder.Configuration.GetConnectionString("StoreCnn");
builder.Services.AddDbContext<StoreDbContext>(options =>
        options.UseSqlServer(cnnstring));
builder.Services.AddScoped<IProductRepository, EfProductRepository>();

var app = builder.Build();

app.UseDeveloperExceptionPage();
app.UseStatusCodePages();
app.UseStaticFiles();
app.UseRouting();

app.UseEndpoints(endpoint =>
{
    endpoint.MapControllerRoute("pagination", "/{controller=home}/{action=index}/{category}/page{pageNumber}");
    endpoint.MapControllerRoute("pagination", "/{controller=home}/{action=index}/page{pageNumber}");
    endpoint.MapControllerRoute("pagination", "/{controller=home}/{action=index}/{category}");
    endpoint.MapDefaultControllerRoute();
});

//*{controller}//{actionIndex}/{id}

app.Run();
 