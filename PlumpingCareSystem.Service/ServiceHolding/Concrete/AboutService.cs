﻿using AutoMapper.QueryableExtensions;
using AutoMapper;
using PlumpingCareSystem.Entity.WebApplication.Entities;
using PlumpingCareSystem.Entity.WebApplication.ViewModels.AboutVM;
using PlumpingCareSystem.Repository.Repositories.Abstract;
using PlumpingCareSystem.Repository.UnitOfWorks.Abstract;
using PlumpingCareSystem.Service.ServiceHolding.Abstract;
using Microsoft.EntityFrameworkCore;


namespace PlumpingCareSystem.Service.ServiceHolding.Concrete
{
	public class AboutService : IAboutService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
		private readonly IGenericRepositories<About> _repository;
		public AboutService(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
			_repository = _unitOfWork.GetGenericRepository<About>();
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
