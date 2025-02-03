using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using PlumpingCareSystem.Entity.WebApplication.Entities;
using PlumpingCareSystem.Entity.WebApplication.ViewModels.Service;
using PlumpingCareSystem.Repository.Repositories.Abstract;
using PlumpingCareSystem.Repository.UnitOfWorks.Abstract;
using PlumpingCareSystem.Service.ServiceHolding.Abstract;

namespace PlumpingCareSystem.Service.ServiceHolding.Concrete
{
	public class ServiceService : IServiceService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
		private readonly IGenericRepositories<Services> _repository;
		public ServiceService(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
			_repository = _unitOfWork.GetGenericRepository<Services>();
		}
		public async Task<List<ServiceListVM>> GetAllListAsync()
		{
			var serviceListVM = await _repository.GetAlltEntityList().ProjectTo<ServiceListVM>(_mapper.ConfigurationProvider).ToListAsync();
			return serviceListVM;
		}
		public async Task AddServiceAsync(ServiceAddVM request)
		{
			var service = _mapper.Map<Services>(request);
			await _repository.AddEntityAsync(service);
			await _unitOfWork.CommitAsync();
		}
		public async Task DeleteServiceAsync(int id)
		{
			var service = await _repository.GetEntityByIdAsync(id);
			_repository.DeletetEntity(service);
			await _unitOfWork.CommitAsync();
		}
		public async Task<ServiceUpdateVM> GetServiceById(int id)
		{
			var service = await _repository.Where(x => x.Id == id).ProjectTo<ServiceUpdateVM>(_mapper.ConfigurationProvider).SingleAsync();
			return service;
		}
		public async Task UpdateServiceAsync(ServiceUpdateVM request)
		{
			var service = _mapper.Map<Services>(request);
			_repository.UpdatetEntity(service);
			await _unitOfWork.CommitAsync();
		}
	}
}
