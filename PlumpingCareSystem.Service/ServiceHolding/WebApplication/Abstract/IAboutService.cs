using PlumpingCareSystem.Entity.WebApplication.ViewModels.AboutVM;

namespace PlumpingCareSystem.Service.ServiceHolding.WebApplication.Abstract
{
	public interface IAboutService
	{
		Task<List<AboutListVM>> GetAllListAsync();
		Task AddAboutAsync(AboutAddVM request);
		Task DeleteAboutAsync(int id);
		Task<AboutUpdateVM> GetAboutById(int id);
		Task UpdateAboutAsync(AboutUpdateVM request);
	}
}