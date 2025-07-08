using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.DashboardComponents
{
	public class _DashboardHeaderView : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
