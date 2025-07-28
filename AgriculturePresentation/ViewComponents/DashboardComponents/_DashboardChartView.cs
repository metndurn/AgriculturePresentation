using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.ViewComponents.DashboardComponents
{
	public class _DashboardChartView : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			ViewBag.v1 = 90;
			ViewBag.v2 = 85;
			ViewBag.v3 = 75;
			ViewBag.v4 = 80;
			ViewBag.v5 = 95;
			return View("/Views/Shared/DashboardComponents/_DashboardChartView/Default.cshtml");
		}
	}
}
