﻿using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlumpingCareSystem.Entity.WebApplication.Entities;
using PlumpingCareSystem.Entity.WebApplication.ViewModels.AboutVM;
using PlumpingCareSystem.Service.Filters.WebApplication;
using PlumpingCareSystem.Service.ServiceHolding.WebApplication.Abstract;

namespace PlumpingCareSystem.Areas.Admin.Controllers
{
	[Authorize(Policy = "AdminObserver")]
	[Area("Admin")]
	public class AboutController : Controller
	{
		private readonly IAboutService _aboutService;
		private readonly IValidator<AboutAddVM> _addValidator;
		private readonly IValidator<AboutUpdateVM> _updateValidator;
		public AboutController(IAboutService aboutService, 
			IValidator<AboutAddVM> addValidator, IValidator<AboutUpdateVM> updateValidator)
		{
			_aboutService = aboutService;
			_addValidator = addValidator;
			_updateValidator = updateValidator;
		}

		public async Task<IActionResult> GetAboutList()
		{
			var aboutList = await _aboutService.GetAllListAsync();
			return View(aboutList);
		}

		[ServiceFilter(typeof(GenericAddPreventationFilter<About>))]
		[HttpGet]
		public IActionResult AddAbout()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> AddAbout(AboutAddVM request)
		{
			var validation = await _addValidator.ValidateAsync(request);
			if (validation.IsValid)
			{
				await _aboutService.AddAboutAsync(request);
				return RedirectToAction("GetAboutList", "About", new { Area = ("Admin") });
			}
			validation.AddToModelState(this.ModelState);
			return View();
		}

		[ServiceFilter(typeof(GenericNotFoundFilter<About>))]
		[HttpGet]
		public async Task<IActionResult> UpdateAbout(int id)
		{
			var about = await _aboutService.GetAboutById(id);
			return View(about);
		}

		[HttpPost]
		public async Task<IActionResult> UpdateAbout(AboutUpdateVM request)
		{
			var validation = await _updateValidator.ValidateAsync(request);
			if (validation.IsValid)
			{
				await _aboutService.UpdateAboutAsync(request);
				return RedirectToAction("GetAboutList", "About", new { Area = ("Admin") });
			}
			validation.AddToModelState(this.ModelState);
			return View();
		}

		[Authorize(Roles = "SuperAdmin")]
		public async Task<IActionResult> DeleteAbout(int id)
		{
			await _aboutService.DeleteAboutAsync(id);
			return RedirectToAction("GetAboutList", "About", new { Area = ("Admin") });
		}
	}
}
