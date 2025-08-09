using AgriculturePresentation.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.Controllers
{
	[AllowAnonymous]/*projenın genel olarak muaf tutmasına yarar*/
	public class LoginController : Controller
	{
		private readonly UserManager<IdentityUser> _userManager;

		public LoginController(UserManager<IdentityUser> userManager)
		{
			_userManager = userManager;
		}

		public IActionResult Index()
		{
			return View();
		}

		[HttpGet]
		public IActionResult SignUp()
		{
			return View();
		}
		[HttpPost]/*parametre olarak model verıp ıstenılen bılgılerın gırılmesı saglıyoruz*/
		public async Task<IActionResult> SignUp(RegisterViewModel registerViewModel)
		{
			IdentityUser identityuser = new IdentityUser/*burada newleyıp ıcındekılere erıstık*/
			{
				Id = "1",/*Id kısmını manuel olarak atadık, genelde veritabanı otomatik atar ama biz burada manuel atıyoruz*/
				UserName = registerViewModel.userName,
				Email = registerViewModel.Email
			};
			if (registerViewModel.password == registerViewModel.passwordConfirm)/*şifre işlemi icin şart koştuk yani şifreler aynı dedık*/
			{
				var result = await _userManager.CreateAsync(identityuser, registerViewModel.password);/*sonuc degıskenıne atadık ve şifreler aynı ise kayıt ıslemı yapsın*/

				if (result.Succeeded)/*eğer kayıt başarılı ise*/
				{
					return RedirectToAction("Index"/*, "Login"*/);/*login sayfasına yönlendir*/
				}
				else
				{
					foreach (var item in result.Errors)/*hata varsa hata mesajlarını döndür*/
					{
						ModelState.AddModelError("", item.Description);
					}
				}
			}
			return View(registerViewModel);
		}
	}
}
