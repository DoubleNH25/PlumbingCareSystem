

using PlumpingCareSystem.Entity.WebApplication.ViewModels.Category;
using PlumpingCareSystem.Service.ServiceHolding.Abstract;

namespace PlumpingCareSystem.Service.ServiceHolding.Concrete
{
	public class CategoryService : ICategoryService
	{
		public Task AddCategoryAsync(CategoryAddVM request)
		{
			throw new NotImplementedException();
		}

		public Task DeleteCategoryAsync(int id)
		{
			throw new NotImplementedException();
		}

		public Task<List<CategoryListVM>> GetAllListAsync()
		{
			throw new NotImplementedException();
		}

		public Task<CategoryUpdateVM> GetCategoryById(int id)
		{
			throw new NotImplementedException();
		}

		public Task UpdateCategoryAsync(CategoryUpdateVM request)
		{
			throw new NotImplementedException();
		}
	}
}
