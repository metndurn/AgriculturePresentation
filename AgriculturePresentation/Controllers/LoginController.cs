using AgriculturePresentation.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.Controllers
{
	[AllowAnonymous]/*projenın genel olarak muaf tutmasına yarar*/
	public class LoginController : Controller
	{
		private readonly UserManager<IdentityUser> _userManager;//kullanıcı işlemleri için UserManager sınıfını kullanıyoruz
		private readonly SignInManager<IdentityUser> _signInManager;// giriş işlemleri için SignInManager sınıfını kullanıyoruz
		
		public LoginController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
		{
			_userManager = userManager;
			_signInManager = signInManager;
		}

		[HttpGet]/*giriş sayfasına yönlendirme için kullanılır*/
		public IActionResult Index()//admin view kısmıdır
		{
			return View();
		}

		[HttpPost]/*parametre olarak model verıp ıstenılen bılgılerın gırılmesı saglıyoruz*/
		public async Task<IActionResult> Index(LoginViewModel loginViewModel)
		{
			if (ModelState.IsValid)
			{
				var result = await _signInManager.PasswordSignInAsync
					(loginViewModel.userName, loginViewModel.password, false, false);/*giriş işlemi için kullanılır, false parametresi hatırlama özelliğini devre dışı bırakır*/
				if (result.Succeeded)
				{
					return RedirectToAction("Index", "Dashboard");/*giriş başarılı ise anasayfaya yönlendirir*/
				}
				else
				{
					return RedirectToAction("Index");/*giriş başarısız ise anasayfaya yönlendirir*/
					//	ModelState.AddModelError("", "Kullanıcı Adı veya Şifre Hatalı!");/*eğer giriş başarısız ise hata mesajı gösterir*/;/*eğer giriş başarılı ise*/
				}
			}
			return View();/*model geçerli değilse tekrar giriş sayfasını gösterir*/
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

		[HttpGet]
		public async Task<IActionResult> LogOut()
		{
			await _signInManager.SignOutAsync(); // Oturumu kapat
			return RedirectToAction("Index", "Login"); // Login sayfasına yönlendir
		}

	}
}
