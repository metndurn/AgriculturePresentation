using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.ViewComponents.DashboardComponents
{
	public class _DashboardScriptView : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View("/Views/Shared/DashboardComponents/_DashboardScriptView/Default.cshtml");
		}
	}
}
