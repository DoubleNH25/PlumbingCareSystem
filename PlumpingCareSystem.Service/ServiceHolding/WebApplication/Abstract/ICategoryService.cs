using PlumpingCareSystem.Entity.WebApplication.ViewModels.Category;

namespace PlumpingCareSystem.Service.ServiceHolding.WebApplication.Abstract
{
	public interface ICategoryService
	{
		Task<List<CategoryListVM>> GetAllListAsync();
		Task AddCategoryAsync(CategoryAddVM request);
		Task DeleteCategoryAsync(int id);
		Task<CategoryUpdateVM> GetCategoryById(int id);
		Task UpdateCategoryAsync(CategoryUpdateVM request);
		Task<List<CategoryListForUI>> GetAllListForUIAsync();
	}
}