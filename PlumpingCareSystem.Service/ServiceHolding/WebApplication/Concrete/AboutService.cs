using AutoMapper.QueryableExtensions;
using AutoMapper;
using PlumpingCareSystem.Entity.WebApplication.Entities;
using PlumpingCareSystem.Entity.WebApplication.ViewModels.AboutVM;
using PlumpingCareSystem.Repository.Repositories.Abstract;
using PlumpingCareSystem.Repository.UnitOfWorks.Abstract;
using Microsoft.EntityFrameworkCore;
using PlumpingCareSystem.Service.ServiceHolding.WebApplication.Abstract;
using PlumpingCareSystem.Service.Helpers.Generic.Image;
using PlumpingCareSystem.Core.Enumerators;
using NToastNotify;
using PlumpingCareSystem.Service.Messages.WebApplication;
using PlumpingCareSystem.Service.Exception.WebApplication;


namespace PlumpingCareSystem.Service.ServiceHolding.WebApplication.Concrete
{
	public class AboutService : IAboutService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
		private readonly IGenericRepositories<About> _repository;
		private readonly IImageHelper _imageHelper;
		private readonly IToastNotification _toasty;
		private const string Section = "About section";
		public AboutService(IUnitOfWork unitOfWork, IMapper mapper, IImageHelper imageHelper, IToastNotification toasty)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
			_repository = _unitOfWork.GetGenericRepository<About>();
			_imageHelper = imageHelper;
			_toasty = toasty;
		}
		public async Task<List<AboutListVM>> GetAllListAsync()
		{
			var aboutListVM = await _repository.GetAlltEntityList().ProjectTo<AboutListVM>(_mapper.ConfigurationProvider).ToListAsync();
			return aboutListVM;
		}
		public async Task AddAboutAsync(AboutAddVM request)
		{
			var imageResult = await _imageHelper.ImageUpload(request.Photo, ImageType.about, null);
			if (imageResult.Error != null)
			{
				_toasty.AddErrorToastMessage(imageResult.Error, new ToastrOptions { Title = NotificationMessagesWebApplication.FailedTitle });
				return;
			}
			request.FileName = imageResult.Filename!;
			request.FileType = imageResult.FileType!;
			var about = _mapper.Map<About>(request);
			await _repository.AddEntityAsync(about);
			await _unitOfWork.CommitAsync();
			_toasty.AddSuccessToastMessage(NotificationMessagesWebApplication.AddMessage(Section), new ToastrOptions { Title = NotificationMessagesWebApplication.SuccessedTitle });
		}
		public async Task DeleteAboutAsync(int id)
		{
			var about = await _repository.GetEntityByIdAsync(id);
			_repository.DeletetEntity(about);
			await _unitOfWork.CommitAsync();
			_imageHelper.DeleteImage(about.FileName);
			_toasty.AddWarningToastMessage(NotificationMessagesWebApplication.DeleteMessage(Section), new ToastrOptions { Title = NotificationMessagesWebApplication.SuccessedTitle });
		}
		public async Task<AboutUpdateVM> GetAboutById(int id)
		{
			var about = await _repository.Where(x => x.Id == id).ProjectTo<AboutUpdateVM>(_mapper.ConfigurationProvider).SingleAsync();
			return about;
		}
		public async Task UpdateAboutAsync(AboutUpdateVM request)
		{
			var oldAbout = await _repository.Where(x => x.Id == request.Id).AsNoTracking().FirstAsync();
			if (request.Photo != null)
			{
				var imageResult = await _imageHelper.ImageUpload(request.Photo, ImageType.about, null);
				if (imageResult.Error != null)
				{
					_toasty.AddErrorToastMessage(imageResult.Error, new ToastrOptions { Title = NotificationMessagesWebApplication.FailedTitle });
					return;
				}
				request.FileName = imageResult.Filename!;
				request.FileType = imageResult.FileType!;
			}
			var about = _mapper.Map<About>(request);
			_repository.UpdatetEntity(about);
			var result = await _unitOfWork.CommitAsync();
			if (!result)
			{
				_imageHelper.DeleteImage(request.FileName);
				throw new ClientSideExceptions(ExceptionMessages.ConcurencyException);
			}
			if (request.Photo != null)
			{
				_imageHelper.DeleteImage(oldAbout.FileName);
			}
			_toasty.AddInfoToastMessage(NotificationMessagesWebApplication.UpdateMessage(Section), new ToastrOptions { Title = NotificationMessagesWebApplication.SuccessedTitle });
		}

		//UI SIDE METHODS
		public async Task<List<AboutListForUI>> GetAllListForUIAsync()
		{
			var aboutListForUI = await _repository.GetAlltEntityList().ProjectTo<AboutListForUI>(_mapper.ConfigurationProvider).ToListAsync();

			return aboutListForUI;
		}
	}
}
