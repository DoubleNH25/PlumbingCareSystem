﻿

using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
using PlumpingCareSystem.Core.Enumerators;
using PlumpingCareSystem.Entity.WebApplication.Entities;
using PlumpingCareSystem.Entity.WebApplication.ViewModels.Team;
using PlumpingCareSystem.Repository.Repositories.Abstract;
using PlumpingCareSystem.Repository.UnitOfWorks.Abstract;
using PlumpingCareSystem.Service.Exception.WebApplication;
using PlumpingCareSystem.Service.Helpers.Generic.Image;
using PlumpingCareSystem.Service.Messages.WebApplication;
using PlumpingCareSystem.Service.ServiceHolding.WebApplication.Abstract;

namespace PlumpingCareSystem.Service.ServiceHolding.WebApplication.Concrete
{
	public class TeamService : ITeamService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
		private readonly IGenericRepositories<Team> _repository;
		private readonly IImageHelper _imageHelper;
		private readonly IToastNotification _toasty;
		private const string Section = "Team Member";
		public TeamService(IUnitOfWork unitOfWork, IMapper mapper, IImageHelper imageHelper, IToastNotification toasty)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
			_repository = _unitOfWork.GetGenericRepository<Team>();
			_imageHelper = imageHelper;
			_toasty = toasty;
		}
		public async Task<List<TeamListVM>> GetAllListAsync()
		{
			var teamListVM = await _repository.GetAlltEntityList().ProjectTo<TeamListVM>(_mapper.ConfigurationProvider).ToListAsync();
			return teamListVM;
		}
		public async Task AddTeamAsync(TeamAddVM request)
		{
			var imageResult = await _imageHelper.ImageUpload(request.Photo, ImageType.team, null);
			if (imageResult.Error != null)
			{
				_toasty.AddErrorToastMessage(imageResult.Error, new ToastrOptions { Title = NotificationMessagesWebApplication.FailedTitle });
				return;
			}
			request.FileName = imageResult.Filename!;
			request.FileType = imageResult.FileType!;

			var team = _mapper.Map<Team>(request);
			await _repository.AddEntityAsync(team);
			await _unitOfWork.CommitAsync();
			_toasty.AddSuccessToastMessage(NotificationMessagesWebApplication.AddMessage(Section), new ToastrOptions { Title = NotificationMessagesWebApplication.SuccessedTitle });
		}
		public async Task DeleteTeamAsync(int id)
		{
			var team = await _repository.GetEntityByIdAsync(id);
			_repository.DeletetEntity(team);
			await _unitOfWork.CommitAsync();
			_imageHelper.DeleteImage(team.FileName);
			_toasty.AddWarningToastMessage(NotificationMessagesWebApplication.DeleteMessage(Section), new ToastrOptions { Title = NotificationMessagesWebApplication.SuccessedTitle });

		}
		public async Task<TeamUpdateVM> GetTeamById(int id)
		{
			var team = await _repository.Where(x => x.Id == id).ProjectTo<TeamUpdateVM>(_mapper.ConfigurationProvider).SingleAsync();
			return team;
		}
		public async Task UpdateTeamAsync(TeamUpdateVM request)
		{
			var oldTeam = await _repository.Where(x => x.Id == request.Id).AsNoTracking().FirstAsync();
			if (request.Photo != null)
			{
				var imageResult = await _imageHelper.ImageUpload(request.Photo, ImageType.team, null);
				if (imageResult.Error != null)
				{
					_toasty.AddErrorToastMessage(imageResult.Error, new ToastrOptions { Title = NotificationMessagesWebApplication.FailedTitle });
					return;
				}
				request.FileName = imageResult.Filename!;
				request.FileType = imageResult.FileType!;
			}

			var team = _mapper.Map<Team>(request);
			_repository.UpdatetEntity(team);
			var result = await _unitOfWork.CommitAsync();
			if (!result)
			{
				_imageHelper.DeleteImage(request.FileName);
				throw new ClientSideExceptions(ExceptionMessages.ConcurencyException);
			}
			_toasty.AddInfoToastMessage(NotificationMessagesWebApplication.UpdateMessage(Section), new ToastrOptions { Title = NotificationMessagesWebApplication.SuccessedTitle });
		}
		//UI SIDE METHODS
		public async Task<List<TeamListForUI>> GetAllListForUIAsync()
		{
			var teamListForUI = await _repository.GetAlltEntityList().ProjectTo<TeamListForUI>(_mapper.ConfigurationProvider).ToListAsync();

			return teamListForUI;
		}
	}
}