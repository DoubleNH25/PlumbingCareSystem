using Microsoft.AspNetCore.Mvc;
using PlumpingCareSystem.Service.ServiceHolding.WebApplication.Abstract;

namespace PlumpingCareSystem.Components
{
	public class TestimonalViewComponent : ViewComponent
	{
		private readonly ITestimonalService _testimonalService;

		public TestimonalViewComponent(ITestimonalService testimonalService)
		{
			_testimonalService = testimonalService;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var testimonalList = await _testimonalService.GetAllListForUIAsync();
			return View(testimonalList);
		}
	}
}