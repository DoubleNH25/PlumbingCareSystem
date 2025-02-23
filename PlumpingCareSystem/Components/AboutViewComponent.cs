using Microsoft.AspNetCore.Mvc;
using PlumpingCareSystem.Service.ServiceHolding.WebApplication.Abstract;

namespace PlumpingCareSystem.Components
{
	public class AboutViewComponent : ViewComponent
	{
		private readonly IAboutService _aboutService;

		public AboutViewComponent(IAboutService aboutService)
		{
			_aboutService = aboutService;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var aboutListForUI = await _aboutService.GetAllListForUIAsync();
			return View(aboutListForUI);
		}
	}
}