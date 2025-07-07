using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.ViewComponents
{
	public class _AddressView : ViewComponent
	{
		private readonly IAddressService _addressService;

		public _AddressView(IAddressService addressService)//tablolara buradan erişim sağlandı
		{
			_addressService = addressService;
		}

		public IViewComponentResult Invoke() //listeleme alanı oldu
		{
			var values = _addressService.GetListAll();
			return View(values);
		}
	}
}
