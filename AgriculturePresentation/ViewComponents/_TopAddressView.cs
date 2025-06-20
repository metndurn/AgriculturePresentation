using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.ViewComponents
{
	public class _TopAddressView : ViewComponent
	{
		/*dinamik isler yapabilmek için bunlar yazılması lazım unutma*/
		private readonly IAddressService _addressService;

		public _TopAddressView(IAddressService addressService)
		{
			_addressService = addressService;
		}

		public IViewComponentResult Invoke()//listeleme yapıyoruz
		{
			var values = _addressService.GetListAll();
			return View(values);
		}
	}
}
