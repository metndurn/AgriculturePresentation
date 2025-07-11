﻿using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using EntityLayer.Concrete;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.Controllers
{
	public class AddressController : Controller
	{
		private readonly IAddressService _addressService;
		public AddressController(IAddressService addressService)
		{
			_addressService = addressService;
		}
		public IActionResult Index()
		{
			var values = _addressService.GetListAll();
			return View(values);
		}

		public IActionResult AddAddress()
		{
			return View();
		}
		[HttpPost]
		public IActionResult AddAddress(Address address)
		{
			ModelState.Clear();
			AddressValidator validationRules = new AddressValidator();
			ValidationResult result = validationRules.Validate(address);
			if (result.IsValid)
			{
				_addressService.Insert(address);
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

		[HttpGet]
		public IActionResult UpdateAddress(int id)
		{
			var value = _addressService.GetById(id);
			return View(value);
		}
		[HttpPost]
		public IActionResult UpdateAddress(Address address)
		{
			ModelState.Clear();
			AddressValidator validationRules = new AddressValidator();
			ValidationResult result = validationRules.Validate(address);
			if (result.IsValid)
			{
				_addressService.Update(address);
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
	}
}
