using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.ViewComponents.DashboardComponents
{
	public class _DashboardOverviewView : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View("/Views/Shared/DashboardComponents/_DashboardOverviewView/Default.cshtml");
		}
	}
}
