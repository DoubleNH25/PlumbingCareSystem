using PlumpingCareSystem.Entity.WebApplication.ViewModels.HomePage;

namespace PlumpingCareSystem.Service.ServiceHolding.WebApplication.Abstract
{
	public interface IHomePageService
	{
		Task<List<HomePageListVM>> GetAllListAsync();
		Task AddHomePageAsync(HomePageAddVM request);
		Task DeleteHomePageAsync(int id);
		Task<HomePageUpdateVM> GetHomePageById(int id);
		Task UpdateHomePageAsync(HomePageUpdateVM request);
	}
}
