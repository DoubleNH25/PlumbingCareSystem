

using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using PlumpingCareSystem.Entity.WebApplication.Entities;
using PlumpingCareSystem.Entity.WebApplication.ViewModels.Testimonal;
using PlumpingCareSystem.Repository.Repositories.Abstract;
using PlumpingCareSystem.Repository.UnitOfWorks.Abstract;
using PlumpingCareSystem.Service.ServiceHolding.WebApplication.Abstract;

namespace PlumpingCareSystem.Service.ServiceHolding.WebApplication.Concrete
{
	public class TestimonalService : ITestimonalService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
		private readonly IGenericRepositories<Testimonal> _repository;
		public TestimonalService(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
			_repository = _unitOfWork.GetGenericRepository<Testimonal>();
		}
		public async Task<List<TestimonalListVM>> GetAllListAsync()
		{
			var testimonalListVM = await _repository.GetAlltEntityList().ProjectTo<TestimonalListVM>(_mapper.ConfigurationProvider).ToListAsync();
			return testimonalListVM;
		}
		public async Task AddTestimonalAsync(TestimonalAddVM request)
		{
			var testimonal = _mapper.Map<Testimonal>(request);
			await _repository.AddEntityAsync(testimonal);
			await _unitOfWork.CommitAsync();
		}
		public async Task DeleteTestimonalAsync(int id)
		{
			var testimonal = await _repository.GetEntityByIdAsync(id);
			_repository.DeletetEntity(testimonal);
			await _unitOfWork.CommitAsync();
		}
		public async Task<TestimonalUpdateVM> GetTestimonalById(int id)
		{
			var testimonal = await _repository.Where(x => x.Id == id).ProjectTo<TestimonalUpdateVM>(_mapper.ConfigurationProvider).SingleAsync();
			return testimonal;
		}
		public async Task UpdateTestimonalAsync(TestimonalUpdateVM request)
		{
			var testimonal = _mapper.Map<Testimonal>(request);
			_repository.UpdatetEntity(testimonal);
			await _unitOfWork.CommitAsync();
		}
	}
}
