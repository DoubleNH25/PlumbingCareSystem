using PlumpingCareSystem.Entity.WebApplication.ViewModels.Team;

namespace PlumpingCareSystem.Service.ServiceHolding.WebApplication.Abstract
{
	public interface ITeamService
	{
		Task<List<TeamListVM>> GetAllListAsync();
		Task AddTeamAsync(TeamAddVM request);
		Task DeleteTeamAsync(int id);
		Task<TeamUpdateVM> GetTeamById(int id);
		Task UpdateTeamAsync(TeamUpdateVM request);
	}
}