using Microsoft.AspNetCore.Mvc;
using PlumpingCareSystem.Service.ServiceHolding.WebApplication.Abstract;

namespace PlumpingCareSystem.Components
{
	public class PortfolioViewComponent : ViewComponent
	{
		private readonly IPortfolioService _portfolioService;

		public PortfolioViewComponent(IPortfolioService portfolioService)
		{
			_portfolioService = portfolioService;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var portfolioList = await _portfolioService.GetAllListForUIAsync();
			return View(portfolioList);
		}
	}
}