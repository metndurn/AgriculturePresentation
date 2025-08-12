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

builder.Services.ContainerDependencies();//buras� BusinessLayer.Container s�n�f�ndan gelen ContainerDependencies metodunu �a��r�yoruz. Bu metod, ba��ml�l�klar� ekler ve uygulaman�n servislerini yap�land�r�r.

//baska b�r class �c�ne aktard�k ve orada bag�ml�l�klar� ekled�k

builder.Services.AddIdentity<IdentityUser, IdentityRole>()//IdentityUser ve IdentityRole s�n�flar�n� kullanarak kimlik do�rulama i�lemlerini yap�yoruz
    .AddEntityFrameworkStores<AgricultureContext>();//Entity Framework ile veritaban� i�lemlerini yap�yoruz
	//.AddDefaultTokenProviders();//Varsay�lan token sa�lay�c�lar�n� ekliyoruz


/*giri� i�lem kodlar� buraya yazd�k yan� admin kullan�c�s� olmadan g�r�s yap�lmayacakt�r*/
builder.Services.AddMvc(config =>
{
    var policy = new AuthorizationPolicyBuilder()//degisken olarak verd�k asag�da �stekler�m� yazd�k
        .RequireAuthenticatedUser()
        .Build();
	config.Filters.Add(new AuthorizeFilter(policy));//atama i�lemi yap�ld� ve f�ltrelend�
});


builder.Services.AddMvc();


builder.Services.AddAuthentication(
    CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
	{
		options.LoginPath = "/Login/Index"; // Giri� sayfas�n�n yolu
		options.AccessDeniedPath = "/Login/AccessDenied"; // Eri�im reddedildi sayfas�n�n yolu
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
