using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.ViewComponents
{
	public class _ContactView : ViewComponent
	{
		private readonly IContactService _contactService;//tablolara buradan erısım saglandı
		public _ContactView(IContactService contactService)//erisim saglandıgı yerden servisi alıyoruz
		{
			_contactService = contactService;
		}
		public IViewComponentResult Invoke()/*listeleme alanı oldu*/
		{
			var values = _contactService.GetListAll();
			return View(values);
		}
	}
}
