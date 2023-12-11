using Cofoundry.Domain;
using Cofoundry.Web;
using Microsoft.EntityFrameworkCore;
using MyConstruction.Cofoundry.ApiCalls;
using OctaLib.Plugins.MyConstruction.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddControllersWithViews()
    .AddCofoundry(builder.Configuration);
builder.Services.AddDbContext<MyConstructionDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionString"));
});

var app = builder.Build();


app.UseHttpsRedirection();
app.UseCofoundry();

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
