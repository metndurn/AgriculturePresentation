using DataAccesLayer.Contexts;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.ViewComponents.DashboardComponents
{
	public class _DashboardOverviewView : ViewComponent
	{
		AgricultureContext c = new AgricultureContext();// veri tabanı bağlantısı için context sınıfından nesne oluşturduk
		public IViewComponentResult Invoke()
		{
			ViewBag.teamCount = c.Teams.Count();//takım sayısı	
			ViewBag.serviceCount = c.Services.Count();//hizmet sayısı
			ViewBag.messageCount = c.Contacts.Count();//mesaj sayısı
			ViewBag.currentMonthMessage = c.Contacts.Where(x => x.Date.Month == DateTime.Now.Month).Count();//bu ay gelen mesaj sayısı

			ViewBag.announcementTrue = c.Announcements.Where(x => x.Status == true).Count();
			ViewBag.announcementFalse = c.Announcements.Where(x => x.Status == false).Count();


			ViewBag.urunPazarlama = c.Teams.Where(x => x.Title == "Ürün Pazarlama").Select(y=>y.PersonelName).FirstOrDefault();
			ViewBag.bakliyatYonetimi = c.Teams.Where(x => x.Title == "Bakliyat Yönetimi").Select(y=>y.PersonelName).FirstOrDefault();
			ViewBag.sutUreticisi = c.Teams.Where(x => x.Title == "Süt Üreticisi").Select(y=>y.PersonelName).FirstOrDefault();
			ViewBag.GubreYonetimi = c.Teams.Where(x => x.Title == "Gübre Yönetimi").Select(y=>y.PersonelName).FirstOrDefault();
			return View("/Views/Shared/DashboardComponents/_DashboardOverviewView/Default.cshtml");
		}
	}
}
