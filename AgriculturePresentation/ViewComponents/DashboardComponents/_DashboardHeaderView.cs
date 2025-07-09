using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.ViewComponents.DashboardComponents
{
	public class _DashboardHeaderView : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View("/Views/Shared/DashboardComponents/_DashboardHeaderView/Default.cshtml");
		}
	}
}
