

using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
using PlumpingCareSystem.Entity.WebApplication.Entities;
using PlumpingCareSystem.Entity.WebApplication.ViewModels.Category;
using PlumpingCareSystem.Repository.Repositories.Abstract;
using PlumpingCareSystem.Repository.UnitOfWorks.Abstract;
using PlumpingCareSystem.Service.Exception.WebApplication;
using PlumpingCareSystem.Service.Messages.WebApplication;
using PlumpingCareSystem.Service.ServiceHolding.WebApplication.Abstract;

namespace PlumpingCareSystem.Service.ServiceHolding.WebApplication.Concrete
{
	public class CategoryService : ICategoryService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
		private readonly IGenericRepositories<Category> _repository;
		private readonly IToastNotification _toasty;
		private const string Section = "Category";

		public CategoryService(IUnitOfWork unitOfWork, IMapper mapper, IToastNotification toasty)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
			_repository = _unitOfWork.GetGenericRepository<Category>();
			_toasty = toasty;
		}

		public async Task<List<CategoryListVM>> GetAllListAsync()
		{
			var categoryListVM = await _repository.GetAlltEntityList().ProjectTo<CategoryListVM>(_mapper.ConfigurationProvider).ToListAsync();
			return categoryListVM;
		}
		public async Task AddCategoryAsync(CategoryAddVM request)
		{
			var category = _mapper.Map<Category>(request);
			await _repository.AddEntityAsync(category);
			await _unitOfWork.CommitAsync();
			_toasty.AddSuccessToastMessage(NotificationMessagesWebApplication.AddMessage(Section), new ToastrOptions { Title = NotificationMessagesWebApplication.SuccessedTitle });
		}
		public async Task DeleteCategoryAsync(int id)
		{
			var category = await _repository.GetEntityByIdAsync(id);
			_repository.DeletetEntity(category);
			await _unitOfWork.CommitAsync();
			_toasty.AddWarningToastMessage(NotificationMessagesWebApplication.DeleteMessage(Section), new ToastrOptions { Title = NotificationMessagesWebApplication.SuccessedTitle });
		}
		public async Task<CategoryUpdateVM> GetCategoryById(int id)
		{
			var category = await _repository.Where(x => x.Id == id).ProjectTo<CategoryUpdateVM>(_mapper.ConfigurationProvider).SingleAsync();
			return category;
		}
		public async Task UpdateCategoryAsync(CategoryUpdateVM request)
		{
			var category = _mapper.Map<Category>(request);
			_repository.UpdatetEntity(category);
			var result = await _unitOfWork.CommitAsync();
			if (!result)
			{
				throw new ClientSideExceptions(ExceptionMessages.ConcurencyException);
			}
			_toasty.AddInfoToastMessage(NotificationMessagesWebApplication.UpdateMessage(Section), new ToastrOptions { Title = NotificationMessagesWebApplication.SuccessedTitle });
		}
		//UI SIDE METHODS
		public async Task<List<CategoryListForUI>> GetAllListForUIAsync()
		{
			var categoryListForUI = await _repository.GetAlltEntityList().ProjectTo<CategoryListForUI>(_mapper.ConfigurationProvider).ToListAsync();

			return categoryListForUI;
		}
	}
}
