

using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using PlumpingCareSystem.Entity.WebApplication.Entities;
using PlumpingCareSystem.Entity.WebApplication.ViewModels.SocialMedia;
using PlumpingCareSystem.Repository.Repositories.Abstract;
using PlumpingCareSystem.Repository.UnitOfWorks.Abstract;
using PlumpingCareSystem.Service.ServiceHolding.Abstract;

namespace PlumpingCareSystem.Service.ServiceHolding.Concrete
{
	public class SocialMediaService : ISocialMediaService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
		private readonly IGenericRepositories<SocialMedia> _repository;
		public SocialMediaService(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
			_repository = _unitOfWork.GetGenericRepository<SocialMedia>();
		}
		public async Task<List<SocialMediaListVM>> GetAllListAsync()
		{
			var socialMediaListVM = await _repository.GetAlltEntityList().ProjectTo<SocialMediaListVM>(_mapper.ConfigurationProvider).ToListAsync();
			return socialMediaListVM;
		}
		public async Task AddSocialMediaAsync(SocialMediaAddVM request)
		{
			var socialMedia = _mapper.Map<SocialMedia>(request);
			await _repository.AddEntityAsync(socialMedia);
			await _unitOfWork.CommitAsync();
		}
		public async Task DeleteSocialMediaAsync(int id)
		{
			var socialMedia = await _repository.GetEntityByIdAsync(id);
			_repository.DeletetEntity(socialMedia);
			await _unitOfWork.CommitAsync();
		}
		public async Task<SocialMediaUpdateVM> GetSocialMediaById(int id)
		{
			var socialMedia = await _repository.Where(x => x.Id == id).ProjectTo<SocialMediaUpdateVM>(_mapper.ConfigurationProvider).SingleAsync();
			return socialMedia;
		}
		public async Task UpdateSocialMediaAsync(SocialMediaUpdateVM request)
		{
			var socialMedia = _mapper.Map<SocialMedia>(request);
			_repository.UpdatetEntity(socialMedia);
			await _unitOfWork.CommitAsync();
		}
	}
}