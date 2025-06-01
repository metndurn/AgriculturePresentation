using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using EntityLayer.Concrete;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.Controllers
{
	public class ContactController : Controller
	{
		private readonly IContactService _contactService;
		public ContactController(IContactService contactService)
		{
			_contactService = contactService;
		}
		public IActionResult Index()
		{
			var values = _contactService.GetListAll();
			return View(values);
		}

		public IActionResult AddContact()
		{
			return View();
		}
		[HttpPost]
		public IActionResult AddContact(Contact contact)
		{
			ContactValidator validationRules = new ContactValidator();
			ValidationResult result = validationRules.Validate(contact);
			if (result.IsValid)
			{
				_contactService.Insert(contact);
				return RedirectToAction("Index");
			}
			else
			{
				foreach (var item in result.Errors)
				{
					ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
				}
			}
			return View();
		}
		public IActionResult DeleteMessage(int id)
		{
			var value = _contactService.GetById(id);
			_contactService.Delete(value);
			return RedirectToAction("Index");
		}
		[HttpGet]
		public IActionResult MessageDetails(int id)
		{
			var value = _contactService.GetById(id);
			return View(value);
		}
	}

}