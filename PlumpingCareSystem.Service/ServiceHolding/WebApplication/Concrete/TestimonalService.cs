﻿

using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
using PlumpingCareSystem.Core.Enumerators;
using PlumpingCareSystem.Entity.WebApplication.Entities;
using PlumpingCareSystem.Entity.WebApplication.ViewModels.Testimonal;
using PlumpingCareSystem.Repository.Repositories.Abstract;
using PlumpingCareSystem.Repository.UnitOfWorks.Abstract;
using PlumpingCareSystem.Service.Exception.WebApplication;
using PlumpingCareSystem.Service.Helpers.Generic.Image;
using PlumpingCareSystem.Service.Messages.WebApplication;
using PlumpingCareSystem.Service.ServiceHolding.WebApplication.Abstract;

namespace PlumpingCareSystem.Service.ServiceHolding.WebApplication.Concrete
{
	public class TestimonalService : ITestimonalService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
		private readonly IGenericRepositories<Testimonal> _repository;
		private readonly IImageHelper _imageHelper;
		private readonly IToastNotification _toasty;
		private const string Section = "Testimonal";
		public TestimonalService(IUnitOfWork unitOfWork, IMapper mapper, IImageHelper imageHelper, IToastNotification toasty)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
			_repository = _unitOfWork.GetGenericRepository<Testimonal>();
			_imageHelper = imageHelper;
			_toasty = toasty;
		}
		public async Task<List<TestimonalListVM>> GetAllListAsync()
		{
			var testimonalListVM = await _repository.GetAlltEntityList().ProjectTo<TestimonalListVM>(_mapper.ConfigurationProvider).ToListAsync();
			return testimonalListVM;
		}
		public async Task AddTestimonalAsync(TestimonalAddVM request)
		{
			var imageResult = await _imageHelper.ImageUpload(request.Photo, ImageType.testimonal, null);
			if (imageResult.Error != null)
			{
				_toasty.AddErrorToastMessage(imageResult.Error, new ToastrOptions { Title = NotificationMessagesWebApplication.FailedTitle });
				return;
			}
			request.FileName = imageResult.Filename!;
			request.FileType = imageResult.FileType!;
			var testimonal = _mapper.Map<Testimonal>(request);
			await _repository.AddEntityAsync(testimonal);
			await _unitOfWork.CommitAsync();
			_toasty.AddSuccessToastMessage(NotificationMessagesWebApplication.AddMessage(Section), new ToastrOptions { Title = NotificationMessagesWebApplication.SuccessedTitle });
		}
		public async Task DeleteTestimonalAsync(int id)
		{
			var testimonal = await _repository.GetEntityByIdAsync(id);
			_repository.DeletetEntity(testimonal);
			await _unitOfWork.CommitAsync();
			_imageHelper.DeleteImage(testimonal.FileName);
			_toasty.AddWarningToastMessage(NotificationMessagesWebApplication.DeleteMessage(Section), new ToastrOptions { Title = NotificationMessagesWebApplication.SuccessedTitle });

		}
		public async Task<TestimonalUpdateVM> GetTestimonalById(int id)
		{
			var testimonal = await _repository.Where(x => x.Id == id).ProjectTo<TestimonalUpdateVM>(_mapper.ConfigurationProvider).SingleAsync();
			return testimonal;
		}
		public async Task UpdateTestimonalAsync(TestimonalUpdateVM request)
		{
			var oldTestimonal = await _repository.Where(x => x.Id == request.Id).AsNoTracking().FirstAsync();
			if (request.Photo != null)
			{
				var imageResult = await _imageHelper.ImageUpload(request.Photo, ImageType.testimonal, null);
				if (imageResult.Error != null)
				{
					_toasty.AddErrorToastMessage(imageResult.Error, new ToastrOptions { Title = NotificationMessagesWebApplication.FailedTitle });
					return;
				}
				request.FileName = imageResult.Filename!;
				request.FileType = imageResult.FileType!;
			}
			var testimonal = _mapper.Map<Testimonal>(request);
			_repository.UpdatetEntity(testimonal);
			var result = await _unitOfWork.CommitAsync();
			if (!result)
			{
				_imageHelper.DeleteImage(request.FileName);
				throw new ClientSideExceptions(ExceptionMessages.ConcurencyException);
			}
			_toasty.AddInfoToastMessage(NotificationMessagesWebApplication.UpdateMessage(Section), new ToastrOptions { Title = NotificationMessagesWebApplication.SuccessedTitle });
		}
		//UI SIDE METHODS
		public async Task<List<TestimonalListForUI>> GetAllListForUIAsync()
		{
			var testimonalListForUI = await _repository.GetAlltEntityList().ProjectTo<TestimonalListForUI>(_mapper.ConfigurationProvider).ToListAsync();

			return testimonalListForUI;
		}
	}
}
