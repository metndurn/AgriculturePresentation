using AgriculturePresentation.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.Controllers
{
	public class ProfileController : Controller
	{
		private readonly UserManager<IdentityUser> _userManager; // kullanıcı işlemleri için UserManager sınıfını kullanıyoruz

		public ProfileController(UserManager<IdentityUser> userManager)
		{
			_userManager = userManager;
		}

		[HttpGet]
		public async Task<IActionResult> Index()
		{
			var values = await _userManager.FindByNameAsync(User.Identity.Name); // giriş yapan kullanıcının bilgilerini alıyoruz

			UserEditViewModel userEditViewModel = new UserEditViewModel();

			userEditViewModel.UserName = values.UserName; // kullanıcı adını modelimize atıyoruz
			userEditViewModel.EMail = values.Email; // email bilgisini modelimize atıyoruz
			userEditViewModel.Phone = values.PhoneNumber; // kullanıcı ID'sini modelimize atıyoruz
			return View(userEditViewModel);
		}
		[HttpPost]
		public async Task<IActionResult> Index(UserEditViewModel userEditViewModel)
		{
			var values = await _userManager.FindByNameAsync(User.Identity.Name);

			if (userEditViewModel.Password == userEditViewModel.ConfirmPassword)
			{
				values.UserName = userEditViewModel.UserName; // kullanıcı adını güncelliyoruz
				values.Email = userEditViewModel.EMail; // email bilgisini güncelliyoruz
				values.PhoneNumber = userEditViewModel.Phone; // telefon numarasını güncelliyoruz
				values.PasswordHash = _userManager.PasswordHasher.HashPassword(values, userEditViewModel.Password); // şifreyi hashleyerek güncelliyoruz
				var result = await _userManager.UpdateAsync(values); // güncellenen bilgileri veritabanına kaydediyoruz
				if (result.Succeeded)
				{
					return RedirectToAction("Index", "Login"); // güncelleme başarılı ise Dashboard sayfasına yönlendiriyoruz
				}
			}
			return View();
		}
	}
}
