

using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
using PlumpingCareSystem.Entity.WebApplication.Entities;
using PlumpingCareSystem.Entity.WebApplication.ViewModels.SocialMedia;
using PlumpingCareSystem.Repository.Repositories.Abstract;
using PlumpingCareSystem.Repository.UnitOfWorks.Abstract;
using PlumpingCareSystem.Service.Exception.WebApplication;
using PlumpingCareSystem.Service.Messages.WebApplication;
using PlumpingCareSystem.Service.ServiceHolding.WebApplication.Abstract;

namespace PlumpingCareSystem.Service.ServiceHolding.WebApplication.Concrete
{
	public class SocialMediaService : ISocialMediaService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
		private readonly IGenericRepositories<SocialMedia> _repository;
		private readonly IToastNotification _toasty;
		private const string Section = "Social Media Section";
		public SocialMediaService(IUnitOfWork unitOfWork, IMapper mapper, IToastNotification toasty)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
			_repository = _unitOfWork.GetGenericRepository<SocialMedia>();
			_toasty = toasty;
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
			_toasty.AddSuccessToastMessage(NotificationMessagesWebApplication.AddMessage(Section), new ToastrOptions { Title = NotificationMessagesWebApplication.SuccessedTitle });
		}
		public async Task DeleteSocialMediaAsync(int id)
		{
			var socialMedia = await _repository.GetEntityByIdAsync(id);
			_repository.DeletetEntity(socialMedia);
			await _unitOfWork.CommitAsync();
			_toasty.AddWarningToastMessage(NotificationMessagesWebApplication.DeleteMessage(Section), new ToastrOptions { Title = NotificationMessagesWebApplication.SuccessedTitle });
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
			var result = await _unitOfWork.CommitAsync();

			if (!result)
			{
				throw new ClientSideExceptions(ExceptionMessages.ConcurencyException);
			}
			_toasty.AddInfoToastMessage(NotificationMessagesWebApplication.UpdateMessage(Section), new ToastrOptions { Title = NotificationMessagesWebApplication.SuccessedTitle });
		}
	}
}