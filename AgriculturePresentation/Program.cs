using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccesLayer.Abstract;
using DataAccesLayer.Concrete.EntityFramework;
using DataAccesLayer.Contexts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IServiceService, ServiceManager>();//burada service manager sýnýfý eklenmiþ oldu
builder.Services.AddScoped<IServiceDal, EfServiceDal>();//burada service dal sýnýfý eklenmiþ oldu
builder.Services.AddDbContext<AgricultureContext>();//bununla birlikte context sýnýfý da eklenmiþ oldu.
builder.Services.AddScoped<ITeamService, TeamManager>();//burada team manager sýnýfý eklenmiþ oldu
builder.Services.AddScoped<ITeamDal, EfTeamDal>();//burada team dal sýnýfý eklenmiþ oldu
builder.Services.AddScoped<IAnnouncementService, AnnouncementManager>();//burada announcement manager sýnýfý eklenmiþ oldu
builder.Services.AddScoped<IAnnouncementDal, EfAnnouncementDal>();//burada announcement dal sýnýfý eklenmiþ oldu
builder.Services.AddScoped<IImageService, ImageManager>();//burada announcement manager sýnýfý eklenmiþ oldu
builder.Services.AddScoped<IImageDal, EfImageDal>();//burada announcement dal sýnýfý eklenmiþ oldu


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
