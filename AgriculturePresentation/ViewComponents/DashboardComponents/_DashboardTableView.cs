using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.ViewComponents.DashboardComponents
{
	public class _DashboardTableView :  ViewComponent
	{
		private readonly IContactService _contactService;

		public _DashboardTableView(IContactService contactService)
		{
			_contactService = contactService;
		}

		public IViewComponentResult Invoke()//veriler listelenirken view kısmına virgul ile degısken tanımlanıp gidebilir
		{
			var contacts = _contactService.GetListAll();
			return View("/Views/Shared/DashboardComponents/_DashboardTableView/Default.cshtml",contacts);
		}
	}
}
