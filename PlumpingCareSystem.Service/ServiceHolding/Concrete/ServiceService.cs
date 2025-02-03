using PlumpingCareSystem.Entity.WebApplication.ViewModels.Service;
using PlumpingCareSystem.Service.ServiceHolding.Abstract;

namespace PlumpingCareSystem.Service.ServiceHolding.Concrete
{
	public class ServiceService : IServiceService
	{
		public Task AddServiceAsync(ServiceAddVM request)
		{
			throw new NotImplementedException();
		}

		public Task DeleteServiceAsync(int id)
		{
			throw new NotImplementedException();
		}

		public Task<List<ServiceListVM>> GetAllListAsync()
		{
			throw new NotImplementedException();
		}

		public Task<ServiceUpdateVM> GetServiceById(int id)
		{
			throw new NotImplementedException();
		}

		public Task UpdateServiceAsync(ServiceUpdateVM request)
		{
			throw new NotImplementedException();
		}
	}
}
