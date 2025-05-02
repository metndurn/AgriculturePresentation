using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.Controllers
{
	public class AnnouncementController : Controller
	{
		private readonly IAnnouncementService _announcementService;

		public AnnouncementController(IAnnouncementService announcementService)
		{
			_announcementService = announcementService;
		}
		public IActionResult Index()
		{
			var values = _announcementService.GetListAll();
			return View(values);
		}
		[HttpGet]
		public IActionResult AddAnnouncement()//modeldekı herseyı ıstedık
		{
			return View();
		}
		[HttpPost]
		public IActionResult AddAnnouncement(Announcement announcement)//ekleme
		{
			_announcementService.Insert(announcement);
			return RedirectToAction("Index");
		}
		public IActionResult DeleteAnnouncement(int id)//silme
		{
			var value = _announcementService.GetById(id);//id ye gore servisi buluyoruz
			_announcementService.Delete(value);
			return RedirectToAction("Index");
		}
		[HttpGet]
		public IActionResult UpdateAnnouncement(int id)//guncelleme ilk gorunen
		{
			var value = _announcementService.GetById(id);
			return View(value);
		}
		[HttpPost]
		public IActionResult UpdateAnnouncement(Announcement announcement)//guncelleme sonrası burası calısacak
		{
			_announcementService.Update(announcement);
			return RedirectToAction("Index");
		}
	}
}
