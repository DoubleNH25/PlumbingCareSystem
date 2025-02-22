using Microsoft.AspNetCore.Mvc;
using PlumpingCareSystem.Service.ServiceHolding.WebApplication.Abstract;

namespace PlumpingCareSystem.Components
{
	public class HomePageViewComponent : ViewComponent
	{
		private readonly IHomePageService _homePageService;

		public HomePageViewComponent(IHomePageService homePageService)
		{
			_homePageService = homePageService;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var homePageList = await _homePageService.GetAllListForUI();
			return View(homePageList);
		}

	}
}