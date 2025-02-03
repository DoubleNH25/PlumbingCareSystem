﻿using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using PlumpingCareSystem.Entity.WebApplication.Entities;
using PlumpingCareSystem.Entity.WebApplication.ViewModels.HomePage;
using PlumpingCareSystem.Repository.Repositories.Abstract;
using PlumpingCareSystem.Repository.UnitOfWorks.Abstract;
using PlumpingCareSystem.Service.ServiceHolding.Abstract;

namespace PlumpingCareSystem.Service.ServiceHolding.Concrete
{
	public class HomePageService : IHomePageService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
		private readonly IGenericRepositories<HomePage> _repository;
		public HomePageService(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
			_repository = _unitOfWork.GetGenericRepository<HomePage>();
		}
		public async Task<List<HomePageListVM>> GetAllListAsync()
		{
			var homePageListVM = await _repository.GetAlltEntityList().ProjectTo<HomePageListVM>(_mapper.ConfigurationProvider).ToListAsync();
			return homePageListVM;
		}
		public async Task AddHomePageAsync(HomePageAddVM request)
		{
			var homePage = _mapper.Map<HomePage>(request);
			await _repository.AddEntityAsync(homePage);
			await _unitOfWork.CommitAsync();
		}
		public async Task DeleteHomePageAsync(int id)
		{
			var homePage = await _repository.GetEntityByIdAsync(id);
			_repository.DeletetEntity(homePage);
			await _unitOfWork.CommitAsync();
		}
		public async Task<HomePageUpdateVM> GetHomePageById(int id)
		{
			var homePage = await _repository.Where(x => x.Id == id).ProjectTo<HomePageUpdateVM>(_mapper.ConfigurationProvider).SingleAsync();
			return homePage;
		}
		public async Task UpdateHomePageAsync(HomePageUpdateVM request)
		{
			var homePage = _mapper.Map<HomePage>(request);
			_repository.UpdatetEntity(homePage);
			await _unitOfWork.CommitAsync();
		}
	}
}