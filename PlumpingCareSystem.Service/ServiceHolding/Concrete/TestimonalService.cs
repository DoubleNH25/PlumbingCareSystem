

using PlumpingCareSystem.Entity.WebApplication.ViewModels.Testimonal;
using PlumpingCareSystem.Service.ServiceHolding.Abstract;

namespace PlumpingCareSystem.Service.ServiceHolding.Concrete
{
	public class TestimonalService : ITestimonalService
	{
		public Task AddTestimonalAsync(TestimonalAddVM request)
		{
			throw new NotImplementedException();
		}

		public Task DeleteTestimonalAsync(int id)
		{
			throw new NotImplementedException();
		}

		public Task<List<TestimonalListVM>> GetAllListAsync()
		{
			throw new NotImplementedException();
		}

		public Task<TestimonalUpdateVM> GetTestimonalById(int id)
		{
			throw new NotImplementedException();
		}

		public Task UpdateTestimonalAsync(TestimonalUpdateVM request)
		{
			throw new NotImplementedException();
		}
	}
}
