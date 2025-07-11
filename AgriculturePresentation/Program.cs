using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccesLayer.Abstract;
using DataAccesLayer.Concrete.EntityFramework;
using DataAccesLayer.Contexts;
using EntityLayer.Concrete;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IServiceService, ServiceManager>();//burada service manager s�n�f� eklenmi� oldu
builder.Services.AddScoped<IServiceDal, EfServiceDal>();//burada service dal s�n�f� eklenmi� oldu
builder.Services.AddDbContext<AgricultureContext>();//bununla birlikte context s�n�f� da eklenmi� oldu.
builder.Services.AddScoped<ITeamService, TeamManager>();//burada team manager s�n�f� eklenmi� oldu
builder.Services.AddScoped<ITeamDal, EfTeamDal>();//burada team dal s�n�f� eklenmi� oldu
builder.Services.AddScoped<IAnnouncementService, AnnouncementManager>();//burada announcement manager s�n�f� eklenmi� oldu
builder.Services.AddScoped<IAnnouncementDal, EfAnnouncementDal>();//burada announcement dal s�n�f� eklenmi� oldu
builder.Services.AddScoped<IImageService, ImageManager>();//burada announcement manager s�n�f� eklenmi� oldu
builder.Services.AddScoped<IImageDal, EfImageDal>();//burada announcement dal s�n�f� eklenmi� oldu
builder.Services.AddScoped<IAddressService, AddresManager>();//burada announcement manager s�n�f� eklenmi� oldu
builder.Services.AddScoped<IAddressDal, EfAddressDal>();//burada announcement dal s�n�f� eklenmi� oldu
builder.Services.AddScoped<IContactService, ContactManager>();//burada announcement manager s�n�f� eklenmi� oldu
builder.Services.AddScoped<IContactDal, EfContactDal>();//burada announcement dal s�n�f� eklenmi� oldu
builder.Services.AddScoped<ISocialMediaService, SocialMediaManager>();//burada announcement manager s�n�f� eklenmi� oldu
builder.Services.AddScoped<ISocialMediaDal, EfSocialMediaDal>();//burada announcement dal s�n�f� eklenmi� oldu
builder.Services.AddScoped<IAboutService, AboutManager>();//burada announcement manager s�n�f� eklenmi� oldu
builder.Services.AddScoped<IAboutDal, EfAboutDal>();//burada announcement dal s�n�f� eklenmi� oldu
builder.Services.AddScoped<IAdminService, AdminManager>();//burada announcement manager s�n�f� eklenmi� oldu
builder.Services.AddScoped<IAdminDal, EfAdminDal>();//burada announcement dal s�n�f� eklenmi� oldu



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
