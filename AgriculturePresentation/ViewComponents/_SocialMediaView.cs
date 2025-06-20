using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.ViewComponents
{
	public class _SocialMediaView : ViewComponent
	{
		private readonly ISocialMediaService _socialMediaService;
		public _SocialMediaView(ISocialMediaService socialMediaService)
		{
			_socialMediaService = socialMediaService;
		}
		public IViewComponentResult Invoke() // listeleme yapıyoruz
		{
			var values = _socialMediaService.GetListAll();
			return View(values);
		}
	}
}
