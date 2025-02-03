

using PlumpingCareSystem.Entity.WebApplication.ViewModels.Team;
using PlumpingCareSystem.Service.ServiceHolding.Abstract;

namespace PlumpingCareSystem.Service.ServiceHolding.Concrete
{
	public class TeamService : ITeamService
	{
		public Task AddTeamAsync(TeamAddVM request)
		{
			throw new NotImplementedException();
		}

		public Task DeleteTeamAsync(int id)
		{
			throw new NotImplementedException();
		}

		public Task<List<TeamListVM>> GetAllListAsync()
		{
			throw new NotImplementedException();
		}

		public Task<TeamUpdateVM> GetTeamById(int id)
		{
			throw new NotImplementedException();
		}

		public Task UpdateTeamAsync(TeamUpdateVM request)
		{
			throw new NotImplementedException();
		}
	}
}
