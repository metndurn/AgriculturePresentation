using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.ViewComponents.DashboardComponents
{
	public class _DashboardChartView : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View("/Views/Shared/DashboardComponents/_DashboardChartView/Default.cshtml");
		}
	}
}
