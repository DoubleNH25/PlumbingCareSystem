using Microsoft.AspNetCore.Identity;
using PlumpingCareSystem.Entity.Identity.Entities;
using PlumpingCareSystem.Entity.WebApplication.Entities;
using PlumpingCareSystem.Repository.UnitOfWorks.Abstract;
using PlumpingCareSystem.Service.ServiceHolding.WebApplication.Abstract;

namespace PlumpingCareSystem.Service.ServiceHolding.WebApplication.Concrete
{
	public class DashboardService : IDashboardService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly UserManager<AppUser> _userManager;

		public DashboardService(IUnitOfWork unitOfWork, UserManager<AppUser> userManager)
		{
			_unitOfWork = unitOfWork;
			_userManager = userManager;
		}

		public async Task<int> GetAllCategoriesCountAsync()
		{
			var categoryCount = await _unitOfWork.GetGenericRepository<Category>().GetAllCount();
			return categoryCount;
		}

		public async Task<int> GetAllPortfoliosCountAsync()
		{
			var portfolioCount = await _unitOfWork.GetGenericRepository<Portfolio>().GetAllCount();
			return portfolioCount;
		}

		public async Task<int> GetAllServicesCountAsync()
		{
			var serviceCount = await _unitOfWork.GetGenericRepository<Services>().GetAllCount();
			return serviceCount;
		}

		public async Task<int> GetAllTeamsCountAsync()
		{
			var teamCount = await _unitOfWork.GetGenericRepository<Team>().GetAllCount();
			return teamCount;
		}

		public async Task<int> GetAllTestimonalsCountAsync()
		{
			var testimonalCount = await _unitOfWork.GetGenericRepository<Testimonal>().GetAllCount();
			return testimonalCount;
		}

		public int GetAllUsersCountAsync()
		{
			var userCount = _userManager.Users.Count();
			return userCount;
		}
	}
}