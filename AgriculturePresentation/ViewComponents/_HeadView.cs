using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.ViewComponents
{
	/*bız bu yapıyı aynı partial view gibi kullanırız ama burada metod uzerınden bagımsız kullanabılıyoruz*/
	public class _HeadView : ViewComponent
	{
		// ViewComponent, Controller gibi çalışır ama ViewComponent içinde metodlar tanımlayabiliriz.
		public IViewComponentResult Invoke()//burada sag tık yapıp addview eklenmez
		{
			return View();
		}
	}
}
