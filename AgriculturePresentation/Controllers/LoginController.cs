using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.Controllers
{
	public class LoginController : Controller
	{
		[AllowAnonymous]/*projenın genel olarak muaf tutmasına yarar*/
		public IActionResult Index()
		{
			return View();
		}
	}
}
