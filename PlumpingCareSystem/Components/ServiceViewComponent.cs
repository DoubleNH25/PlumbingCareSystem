using Microsoft.AspNetCore.Mvc;
using PlumpingCareSystem.Service.ServiceHolding.WebApplication.Abstract;

namespace PlumpingCareSystem.Components
{
	public class ServiceViewComponent : ViewComponent
	{
		private readonly IServiceService _serviceService;

		public ServiceViewComponent(IServiceService serviceService)
		{
			_serviceService = serviceService;
		}
		public async Task<IViewComponentResult> InvokeAsync()
		{
			var serviceListForUI = await _serviceService.GetAllListForUIAsync();
			return View(serviceListForUI);
		}
	}
}