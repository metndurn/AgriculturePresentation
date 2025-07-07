using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.ViewComponents
{
	public class _AnnouncementView : ViewComponent
	{
		private readonly IAnnouncementService _announcementService; //tablolara buradan erişim sağlandı

		public _AnnouncementView(IAnnouncementService announcementService)
		{
			_announcementService = announcementService;
		}
		public IViewComponentResult Invoke() //listeleme alanı oldu
		{
			var values = _announcementService.GetListAll();
			return View(values);
		}
	}
}
