using AutoMapper.QueryableExtensions;
using AutoMapper;
using PlumpingCareSystem.Entity.WebApplication.Entities;
using PlumpingCareSystem.Entity.WebApplication.ViewModels.AboutVM;
using PlumpingCareSystem.Repository.Repositories.Abstract;
using PlumpingCareSystem.Repository.UnitOfWorks.Abstract;
using Microsoft.EntityFrameworkCore;
using PlumpingCareSystem.Service.ServiceHolding.WebApplication.Abstract;
using PlumpingCareSystem.Service.Helpers.Generic.Image;


namespace PlumpingCareSystem.Service.ServiceHolding.WebApplication.Concrete
{
	public class AboutService : IAboutService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
		private readonly IGenericRepositories<About> _repository;
		private readonly IImageHelper _imageHelper;
		public AboutService(IUnitOfWork unitOfWork, IMapper mapper, IImageHelper imageHelper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
			_repository = _unitOfWork.GetGenericRepository<About>();
			_imageHelper = imageHelper;
		}
		public async Task<List<AboutListVM>> GetAllListAsync()
		{
			var aboutListVM = await _repository.GetAlltEntityList().ProjectTo<AboutListVM>(_mapper.ConfigurationProvider).ToListAsync();
			return aboutListVM;
		}
		public async Task AddAboutAsync(AboutAddVM request)
		{
			var about = _mapper.Map<About>(request);
			await _repository.AddEntityAsync(about);
			await _unitOfWork.CommitAsync();
		}
		public async Task DeleteAboutAsync(int id)
		{
			var about = await _repository.GetEntityByIdAsync(id);
			_repository.DeletetEntity(about);
			await _unitOfWork.CommitAsync();
		}
		public async Task<AboutUpdateVM> GetAboutById(int id)
		{
			var about = await _repository.Where(x => x.Id == id).ProjectTo<AboutUpdateVM>(_mapper.ConfigurationProvider).SingleAsync();
			return about;
		}
		public async Task UpdateAboutAsync(AboutUpdateVM request)
		{
			var about = _mapper.Map<About>(request);
			_repository.UpdatetEntity(about);
			await _unitOfWork.CommitAsync();
		}
	}
}
