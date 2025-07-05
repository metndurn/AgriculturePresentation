using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.ViewComponents
{
	public class _ServiceView : ViewComponent
	{
		private readonly IServiceService _serviceService; //tablolara buradan erısım saglandı

		public _ServiceView(IServiceService serviceService)//erisim saglandıgı yerden servisi alıyoruz
		{
			_serviceService = serviceService;
		}
		public IViewComponentResult Invoke() /*listeleme alanı oldu*/
		{
			var values = _serviceService.GetListAll();
			return View(values);
		}
	}
}
