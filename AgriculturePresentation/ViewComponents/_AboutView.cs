using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.ViewComponents
{
	public class _AboutView : ViewComponent
	{
		private readonly IAboutService _aboutService;//tablolara buradan erısım saglandı

		public _AboutView(IAboutService aboutService)//erisim saglandıgı yerden servisi alıyoruz
		{
			_aboutService = aboutService;
		}

		public IViewComponentResult Invoke()/*listeleme alanı oldu*/
		{
			var values = _aboutService.GetListAll();
			return View(values);
		}
	}
}
