﻿using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.ViewComponents
{
	public class _NavbarView : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
