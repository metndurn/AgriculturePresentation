using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.ViewComponents
{
	public class _GalleryView : ViewComponent/*gallery ve image aynıdır unutma*/
	{
		private readonly IImageService _imageService; //tablolara buradan erişim sağlandı

		public _GalleryView(IImageService imageService)
		{
			_imageService = imageService;
		}
		public IViewComponentResult Invoke() //listeleme alanı oldu
		{
			var values = _imageService.GetListAll();
			return View(values);
		}
	}
}
