using PlumpingCareSystem.Entity.WebApplication.ViewModels.HomePage;
using PlumpingCareSystem.Service.ServiceHolding.Abstract;

namespace PlumpingCareSystem.Service.ServiceHolding.Concrete
{
	public class HomePageService : IHomePageService
	{
		public Task AddHomePageAsync(HomePageAddVM request)
		{
			throw new NotImplementedException();
		}

		public Task DeleteHomePageAsync(int id)
		{
			throw new NotImplementedException();
		}

		public Task<List<HomePageListVM>> GetAllListAsync()
		{
			throw new NotImplementedException();
		}

		public Task<HomePageUpdateVM> GetHomePageById(int id)
		{
			throw new NotImplementedException();
		}

		public Task UpdateHomePageAsync(HomePageUpdateVM request)
		{
			throw new NotImplementedException();
		}
	}
}
