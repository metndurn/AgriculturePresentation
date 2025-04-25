using AgriculturePresentation.Models;
using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.Controllers
{
	public class ServiceController : Controller
	{
		private readonly IServiceService _serviceService;

		public ServiceController(IServiceService serviceService)
		{
			_serviceService = serviceService;
		}

		public IActionResult Index()
		{
			var values = _serviceService.GetListAll();
			return View(values);
		}
		[HttpGet]
		public IActionResult AddService()//modeldekı herseyı ıstedık
		{
			return View(new ServiceAddViewModel());//modeldeki hersey burada gorunur
		}
		[HttpPost]
		public IActionResult AddService(ServiceAddViewModel model)
		{
			if (ModelState.IsValid)//modeldeki herseyın dogru olup olmadıgını kontrol edıyoruz
			{
				_serviceService.Insert(new Service()//service classını kullanarak modelden gelen verileri service classına atıyoruz
				{
					Title = model.Title,
					Image = model.Image,
					Description = model.Description
				});
				return RedirectToAction("Index");
			}
			return View(model);
		}
		public IActionResult DeleteService(int id)
		{
			var value = _serviceService.GetById(id);//id ye gore servisi buluyoruz
			_serviceService.Delete(value);
			return RedirectToAction("Index");
		}
		[HttpGet]
		public IActionResult UpdateService(int id)
		{
			var value = _serviceService.GetById(id);
			return View(value);
		}
		[HttpPost]
		public IActionResult UpdateService(Service service)
		{
			_serviceService.Update(service);
			return RedirectToAction("Index");
		}
		public IActionResult Deneme()
		{
			return View();
		}
	}
}
