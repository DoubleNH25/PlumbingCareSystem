using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlumpingCareSystem.Entity.WebApplication.Entities;
using PlumpingCareSystem.Entity.WebApplication.ViewModels.Service;
using PlumpingCareSystem.Service.Filters.WebApplication;
using PlumpingCareSystem.Service.ServiceHolding.WebApplication.Abstract;

namespace PlumpingCareSystem.Areas.Admin.Controllers
{
	[Authorize(Policy = "AdminObserver")]
	[Area("Admin")]
	public class ServiceController : Controller
	{
		private readonly IServiceService _serviceService;
		private readonly IValidator<ServiceAddVM> _addValidator;
		private readonly IValidator<ServiceUpdateVM> _updateValidator;
		public ServiceController(IServiceService serviceService, 
			IValidator<ServiceAddVM> addValidator, IValidator<ServiceUpdateVM> updateValidator)
		{
			_serviceService = serviceService;
			_addValidator = addValidator;
			_updateValidator = updateValidator;
		}

		public async Task<IActionResult> GetServiceList()
		{
			var serviceList = await _serviceService.GetAllListAsync();
			return View(serviceList);
		}
		[HttpGet]
		public IActionResult AddService()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> AddService(ServiceAddVM request)
		{
			var validation = await _addValidator.ValidateAsync(request);
			if (validation.IsValid)
			{
				await _serviceService.AddServiceAsync(request);
				return RedirectToAction("GetServiceList", "Service", new { Area = ("Admin") });
			}
			validation.AddToModelState(this.ModelState);
			return View();

		}

		[ServiceFilter(typeof(GenericNotFoundFilter<Services>))]
		[HttpGet]
		public async Task<IActionResult> UpdateService(int id)
		{
			var service = await _serviceService.GetServiceById(id);
			return View(service);
		}
		[HttpPost]
		public async Task<IActionResult> UpdateService(ServiceUpdateVM request)
		{
			var validation = await _updateValidator.ValidateAsync(request);
			if (validation.IsValid)
			{
				await _serviceService.UpdateServiceAsync(request);
				return RedirectToAction("GetServiceList", "Service", new { Area = ("Admin") });
			}
			validation.AddToModelState(this.ModelState);
			return View();
		}

		[Authorize(Roles = "SuperAdmin")]
		public async Task<IActionResult> DeleteService(int id)
		{
			await _serviceService.DeleteServiceAsync(id);
			return RedirectToAction("GetServiceList", "Service", new { Area = ("Admin") });
		}
	}
}