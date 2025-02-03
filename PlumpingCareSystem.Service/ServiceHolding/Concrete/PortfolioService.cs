using PlumpingCareSystem.Entity.WebApplication.ViewModels.Portfolio;
using PlumpingCareSystem.Service.ServiceHolding.Abstract;

namespace PlumpingCareSystem.Service.ServiceHolding.Concrete
{
	public class PortfolioService : IPortfolioService
	{
		public Task AddPortfolioAsync(PortfolioAddVM request)
		{
			throw new NotImplementedException();
		}

		public Task DeletePortfolioAsync(int id)
		{
			throw new NotImplementedException();
		}

		public Task<List<PortfolioListVM>> GetAllListAsync()
		{
			throw new NotImplementedException();
		}

		public Task<PortfolioUpdateVM> GetPortfolioById(int id)
		{
			throw new NotImplementedException();
		}

		public Task UpdatePortfolioAsync(PortfolioUpdateVM request)
		{
			throw new NotImplementedException();
		}
	}
}
