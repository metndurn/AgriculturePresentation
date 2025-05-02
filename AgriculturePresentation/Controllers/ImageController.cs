using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.Controllers
{
	public class ImageController : Controller
	{
		private readonly IImageService _imageService;

		public ImageController(IImageService imageService)
		{
			_imageService = imageService;
		}

		public IActionResult Index()
		{
			var values = _imageService.GetListAll();
			return View(values);
		}
		[HttpGet]
		public IActionResult AddImage()
		{
			return View();
		}
		[HttpPost]
		public IActionResult AddImage(Image image)
		{
			_imageService.Insert(image);
			return RedirectToAction("Index");
		}
		public IActionResult DeleteImage(int id)
		{
			var value = _imageService.GetById(id);
			_imageService.Delete(value);
			return RedirectToAction("Index");
		}
		[HttpGet]
		public IActionResult UpdateImage(int id)
		{
			var value = _imageService.GetById(id);
			return View(value);
		}
		[HttpPost]
		public IActionResult UpdateImage(Image image)
		{
			_imageService.Update(image);
			return RedirectToAction("Index");
		}
	}
}
