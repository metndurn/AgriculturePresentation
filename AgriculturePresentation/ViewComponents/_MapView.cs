using DataAccesLayer.Contexts;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.ViewComponents
{
	public class _MapView : ViewComponent
	{
		public IViewComponentResult Invoke()/*listeleme alanı oldu*/
		{
			AgricultureContext agricultureContext = new AgricultureContext();
			var values = agricultureContext.Addresses.Select(x=>x.Mapinfo).FirstOrDefault();
			ViewBag.map = values;
			return View();
		}
	}
}
