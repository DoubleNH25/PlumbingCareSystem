using PlumpingCareSystem.Entity.WebApplication.ViewModels.Testimonal;

namespace PlumpingCareSystem.Service.ServiceHolding.WebApplication.Abstract
{
	public interface ITestimonalService
	{
		Task<List<TestimonalListVM>> GetAllListAsync();
		Task AddTestimonalAsync(TestimonalAddVM request);
		Task DeleteTestimonalAsync(int id);
		Task<TestimonalUpdateVM> GetTestimonalById(int id);
		Task UpdateTestimonalAsync(TestimonalUpdateVM request);
	}
}
