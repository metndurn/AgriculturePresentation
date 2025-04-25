using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccesLayer.Abstract;
using DataAccesLayer.Concrete.EntityFramework;
using DataAccesLayer.Contexts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IServiceService, ServiceManager>();//burada service manager s�n�f� eklenmi� oldu
builder.Services.AddScoped<IServiceDal, EfServiceDal>();//burada service dal s�n�f� eklenmi� oldu
builder.Services.AddDbContext<AgricultureContext>();//bununla birlikte context s�n�f� da eklenmi� oldu.
//builder.Services.AddScoped<ITeamService, TeamManager>();

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
