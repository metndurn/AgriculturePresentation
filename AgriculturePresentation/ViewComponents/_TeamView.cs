using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.ViewComponents
{
	public class _TeamView : ViewComponent
	{
		private readonly ITeamService _teamService; //tablolara buradan erısım saglandı
		public _TeamView(ITeamService teamService) //erisim saglandıgı yerden servisi alıyoruz
		{
			_teamService = teamService;
		}
		public IViewComponentResult Invoke() /*listeleme alanı oldu*/
		{
			var values = _teamService.GetListAll();
			return View(values);
		}
	}
}
