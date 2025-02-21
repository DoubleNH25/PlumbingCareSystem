﻿using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using PlumpingCareSystem.Entity.WebApplication.Entities;
using PlumpingCareSystem.Entity.WebApplication.ViewModels.Portfolio;
using PlumpingCareSystem.Service.Filters.WebApplication;
using PlumpingCareSystem.Service.ServiceHolding.WebApplication.Abstract;

namespace PlumpingCareSystem.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class PortfolioController : Controller
	{
		private readonly IPortfolioService _portfolioService;
		private readonly IValidator<PortfolioAddVM> _addValidator;
		private readonly IValidator<PortfolioUpdateVM> _updateValidator;

		public PortfolioController(IPortfolioService portfolioService, 
			IValidator<PortfolioAddVM> addValidator, IValidator<PortfolioUpdateVM> updateValidator)
		{
			_portfolioService = portfolioService;
			_addValidator = addValidator;
			_updateValidator = updateValidator;
		}
		public async Task<IActionResult> GetPortfolioList()
		{
			var portfolioList = await _portfolioService.GetAllListAsync();
			return View(portfolioList);
		}
		[HttpGet]
		public IActionResult AddPortfolio()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> AddPortfolio(PortfolioAddVM request)
		{
			var validation = await _addValidator.ValidateAsync(request);
			if (validation.IsValid)
			{
				await _portfolioService.AddPortfolioAsync(request);
				return RedirectToAction("GetPortfolioList", "Portfolio", new { Area = ("Admin") });
			}
			validation.AddToModelState(this.ModelState);
			return View();
		}

		[ServiceFilter(typeof(GenericNotFoundFilter<Portfolio>))]
		[HttpGet]
		public async Task<IActionResult> UpdatePortfolio(int id)
		{
			var portfolio = await _portfolioService.GetPortfolioById(id);
			return View(portfolio);
		}
		[HttpPost]
		public async Task<IActionResult> UpdatePortfolio(PortfolioUpdateVM request)
		{
			var validation = await _updateValidator.ValidateAsync(request);
			if (validation.IsValid)
			{
				await _portfolioService.UpdatePortfolioAsync(request);
				return RedirectToAction("GetPortfolioList", "Portfolio", new { Area = ("Admin") });
			}
			validation.AddToModelState(this.ModelState);
			return View();
		}
		public async Task<IActionResult> DeletePortfolio(int id)
		{
			await _portfolioService.DeletePortfolioAsync(id);
			return RedirectToAction("GetPortfolioList", "Portfolio", new { Area = ("Admin") });
		}
	}
}