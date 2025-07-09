using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.ViewComponents.DashboardComponents
{
	public class _DashboardTableView :  ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View("/Views/Shared/DashboardComponents/_DashboardTableView/Default.cshtml");
		}
	}
}
