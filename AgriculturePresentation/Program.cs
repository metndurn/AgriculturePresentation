using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccesLayer.Abstract;
using DataAccesLayer.Concrete.EntityFramework;
using DataAccesLayer.Contexts;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;

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
builder.Services.AddScoped<IAddressService, AddressManager>();//burada announcement manager sýnýfý eklenmiþ oldu
builder.Services.AddScoped<IAddressDal, EfAddressDal>();//burada announcement dal sýnýfý eklenmiþ oldu
builder.Services.AddScoped<IContactService, ContactManager>();//burada announcement manager sýnýfý eklenmiþ oldu
builder.Services.AddScoped<IContactDal, EfContactDal>();//burada announcement dal sýnýfý eklenmiþ oldu
builder.Services.AddScoped<ISocialMediaService, SocialMediaManager>();//burada announcement manager sýnýfý eklenmiþ oldu
builder.Services.AddScoped<ISocialMediaDal, EfSocialMediaDal>();//burada announcement dal sýnýfý eklenmiþ oldu
builder.Services.AddScoped<IAboutService, AboutManager>();//burada announcement manager sýnýfý eklenmiþ oldu
builder.Services.AddScoped<IAboutDal, EfAboutDal>();//burada announcement dal sýnýfý eklenmiþ oldu
builder.Services.AddScoped<IAdminService, AdminManager>();//burada announcement manager sýnýfý eklenmiþ oldu
builder.Services.AddScoped<IAdminDal, EfAdminDal>();//burada announcement dal sýnýfý eklenmiþ oldu
builder.Services.AddScoped<IProductService, ProductManager>();//burada announcement manager sýnýfý eklenmiþ oldu
builder.Services.AddScoped<IProductDal, EfProductDal>();//burada announcement dal sýnýfý eklenmiþ oldu

/*giriþ iþlem kodlarý buraya yazdýk yaný admin kullanýcýsý olmadan gýrýs yapýlmayacaktýr*/
builder.Services.AddMvc(config =>
{
    var policy = new AuthorizationPolicyBuilder()//degisken olarak verdýk asagýda ýsteklerýmý yazdýk
        .RequireAuthenticatedUser()
        .Build();
	config.Filters.Add(new AuthorizeFilter(policy));//atama iþlemi yapýldý ve fýltrelendý
});


builder.Services.AddMvc();


builder.Services.AddAuthentication(
    CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
	{
		options.LoginPath = "/Login/Index"; // Giriþ sayfasýnýn yolu
		options.AccessDeniedPath = "/Login/AccessDenied"; // Eriþim reddedildi sayfasýnýn yolu
	});

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
