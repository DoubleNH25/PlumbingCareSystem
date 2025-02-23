using Microsoft.AspNetCore.Mvc;
using PlumpingCareSystem.Service.ServiceHolding.WebApplication.Abstract;

namespace PlumpingCareSystem.Components
{
	public class TeamViewComponent : ViewComponent
	{
		private readonly ITeamService _teamService;

		public TeamViewComponent(ITeamService teamService)
		{
			_teamService = teamService;
		}
		public async Task<IViewComponentResult> InvokeAsync()
		{
			var teamList = await _teamService.GetAllListForUIAsync();
			return View(teamList);
		}
	}
}