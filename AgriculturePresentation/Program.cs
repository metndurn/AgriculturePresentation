using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.Container;
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
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.ContainerDependencies();//burasý BusinessLayer.Container sýnýfýndan gelen ContainerDependencies metodunu çaðýrýyoruz. Bu metod, baðýmlýlýklarý ekler ve uygulamanýn servislerini yapýlandýrýr.

//baska býr class ýcýne aktardýk ve orada bagýmlýlýklarý ekledýk

builder.Services.AddIdentity<IdentityUser, IdentityRole>()//IdentityUser ve IdentityRole sýnýflarýný kullanarak kimlik doðrulama iþlemlerini yapýyoruz
    .AddEntityFrameworkStores<AgricultureContext>();//Entity Framework ile veritabaný iþlemlerini yapýyoruz
	//.AddDefaultTokenProviders();//Varsayýlan token saðlayýcýlarýný ekliyoruz


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
//app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
