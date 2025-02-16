using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using PlumpingCareSystem.Core.Enumerators;
using PlumpingCareSystem.Entity.WebApplication.Entities;
using PlumpingCareSystem.Entity.WebApplication.ViewModels.Portfolio;
using PlumpingCareSystem.Repository.Repositories.Abstract;
using PlumpingCareSystem.Repository.UnitOfWorks.Abstract;
using PlumpingCareSystem.Service.Helpers.Generic.Image;
using PlumpingCareSystem.Service.ServiceHolding.WebApplication.Abstract;

namespace PlumpingCareSystem.Service.ServiceHolding.WebApplication.Concrete
{
	public class PortfolioService : IPortfolioService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
		private readonly IGenericRepositories<Portfolio> _repository;
		private readonly IImageHelper _imageHelper;
		public PortfolioService(IUnitOfWork unitOfWork, IMapper mapper, IImageHelper imageHelper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
			_repository = _unitOfWork.GetGenericRepository<Portfolio>();
			_imageHelper = imageHelper;
		}
		public async Task<List<PortfolioListVM>> GetAllListAsync()
		{
			var portfolioListVM = await _repository.GetAlltEntityList().ProjectTo<PortfolioListVM>(_mapper.ConfigurationProvider).ToListAsync();
			return portfolioListVM;
		}
		public async Task AddPortfolioAsync(PortfolioAddVM request)
		{
			var imageResult = await _imageHelper.ImageUpload(request.Photo, ImageType.portfolio, null);
			if (imageResult.Error != null)
			{
				return;
			}
			request.FileName = imageResult.Filename!;
			request.FileType = imageResult.FileType!;

			var portfolio = _mapper.Map<Portfolio>(request);
			await _repository.AddEntityAsync(portfolio);
			await _unitOfWork.CommitAsync();
		}
		public async Task DeletePortfolioAsync(int id)
		{
			var portfolio = await _repository.GetEntityByIdAsync(id);
			_repository.DeletetEntity(portfolio);
			await _unitOfWork.CommitAsync();
			_imageHelper.DeleteImage(portfolio.FileName);
		}
		public async Task<PortfolioUpdateVM> GetPortfolioById(int id)
		{
			var portfolio = await _repository.Where(x => x.Id == id).ProjectTo<PortfolioUpdateVM>(_mapper.ConfigurationProvider).SingleAsync();
			return portfolio;
		}
		public async Task UpdatePortfolioAsync(PortfolioUpdateVM request)
		{
			var oldPortfolio = await _repository.Where(x => x.Id == request.Id).AsNoTracking().FirstAsync();
			if (request.Photo != null)
			{
				var imageResult = await _imageHelper.ImageUpload(request.Photo, ImageType.portfolio, null);
				if (imageResult.Error != null)
				{
					return;
				}
				request.FileName = imageResult.Filename!;
				request.FileType = imageResult.FileType!;
			}
			var portfolio = _mapper.Map<Portfolio>(request);
			_repository.UpdatetEntity(portfolio);
			await _unitOfWork.CommitAsync();
			if (request.Photo != null)
			{
				_imageHelper.DeleteImage(oldPortfolio.FileName);
			}
		}
	}
}
