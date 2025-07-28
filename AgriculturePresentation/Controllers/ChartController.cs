using AgriculturePresentation.Models;
using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AgriculturePresentation.Controllers
{
	public class ChartController : Controller
	{
		private readonly IProductService _productService;
		public ChartController(IProductService productService)
		{
			_productService = productService;
		}
		public IActionResult Index()
		{
			return View();
		}
		public IActionResult ProductChart()// bu metod grafik verilerini döndürecek
		{
			List<ProductClass> productClasses = new List<ProductClass>();// grafik verilerini tutacak liste
			productClasses.Add(new ProductClass
			{
				productname = "Buğday",
				productvalue = 750
			});// ürün adı ve değeri ekliyoruz
			productClasses.Add(new ProductClass
			{
				productname = "Mercimek",
				productvalue = 480
			}); productClasses.Add(new ProductClass
			{
				productname = "Pirinç",
				productvalue = 350
			});
			productClasses.Add(new ProductClass
			{
				productname = "Arpa",
				productvalue = 500
			}); productClasses.Add(new ProductClass
			{
				productname = "Domates",
				productvalue = 960
			});
			return Json(new { jsonlist = productClasses });//json ile grafik verisi gönderiyoruz
		}
	}
}
