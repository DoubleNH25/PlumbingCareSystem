using PlumpingCareSystem.Entity.WebApplication.ViewModels.Portfolio;

namespace PlumpingCareSystem.Service.ServiceHolding.WebApplication.Abstract
{
	public interface IPortfolioService
	{
		Task<List<PortfolioListVM>> GetAllListAsync();
		Task AddPortfolioAsync(PortfolioAddVM request);
		Task DeletePortfolioAsync(int id);
		Task<PortfolioUpdateVM> GetPortfolioById(int id);
		Task UpdatePortfolioAsync(PortfolioUpdateVM request);
	}
}
