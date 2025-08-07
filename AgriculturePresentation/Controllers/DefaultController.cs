using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.Controllers
{
	[AllowAnonymous]
	public class DefaultController : Controller
	{
		private readonly IContactService _contactService;//tablolara buradan erısım saglandı

		public DefaultController(IContactService contactService)// erisim saglandıgı yerden servisi alıyoruz
		{
			_contactService = contactService;
		}

		public IActionResult Index()
		{
			return View();
		}
		[HttpGet]
		public PartialViewResult SendMessage()//bunun amacı, mesaj gonderme alanını acmak
		{
			return PartialView();
		}
		[HttpPost]
		public IActionResult SendMessage(Contact contact)//bu metot, mesaj gonderme alanından gelen verileri alır
		{
			// burada contact nesnesini kullanarak veritabanına kaydetme işlemi yapılabilir
			// Örneğin: _contactService.Add(contact);
			contact.Date = DateTime.Parse(DateTime.Now.ToShortDateString());//tarih kısmını alır
			_contactService.Insert(contact);//contact nesnesini veritabanına ekler
			return RedirectToAction("Index","Default");
		}
		public PartialViewResult ScriptView()//bunun amacı, mesaj gonderme alanındaki javascript kodlarını cagırmak
		{
			return PartialView();
		}
	}
}
