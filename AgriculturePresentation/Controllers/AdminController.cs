using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.Controllers
{
	public class AdminController : Controller
	{
		private readonly IAdminService _adminService;
		public AdminController(IAdminService adminService)
		{
			_adminService = adminService;
		}

		public IActionResult Index()//list all ile admin users olan hepsine listeleme yapıldı
		{
			var values = _adminService.GetListAll();
			return View(values);
		}
		[HttpGet]
		public IActionResult AddAdmin()
		{
			return View();
		}
		[HttpPost]
		public IActionResult AddAdmin(Admin admin)//ekleme metodu 
		{
			_adminService.Insert(admin);
			return RedirectToAction("Index");
		}
		public IActionResult DeleteAdmin(int id)//silme metodu
		{
			var value = _adminService.GetById(id);
			_adminService.Delete(value);
			return RedirectToAction("Index");
		}
		[HttpGet]
		public IActionResult EditAdmin(int id)
		{
			var value = _adminService.GetById(id);
			return View("EditAdmin", value);
		}
		[HttpPost]
		public IActionResult EditAdmin(Admin admin)//güncelleme metodu
		{
			_adminService.Update(admin);
			return RedirectToAction("Index");
		}
	}
}
