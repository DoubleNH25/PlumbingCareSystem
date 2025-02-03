using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using PlumpingCareSystem.Entity.WebApplication.Entities;
using PlumpingCareSystem.Entity.WebApplication.ViewModels.Contact;
using PlumpingCareSystem.Repository.Repositories.Abstract;
using PlumpingCareSystem.Repository.UnitOfWorks.Abstract;
using PlumpingCareSystem.Service.ServiceHolding.Abstract;

namespace PlumpingCareSystem.Service.ServiceHolding.Concrete
{
	public class ContactService : IContactService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
		private readonly IGenericRepositories<Contact> _repository;
		public ContactService(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
			_repository = _unitOfWork.GetGenericRepository<Contact>();
		}
		public async Task<List<ContactListVM>> GetAllListAsync()
		{
			var contactListVM = await _repository.GetAlltEntityList().ProjectTo<ContactListVM>(_mapper.ConfigurationProvider).ToListAsync();
			return contactListVM;
		}
		public async Task AddContactAsync(ContactAddVM request)
		{
			var contact = _mapper.Map<Contact>(request);
			await _repository.AddEntityAsync(contact);
			await _unitOfWork.CommitAsync();
		}
		public async Task DeleteContactAsync(int id)
		{
			var contact = await _repository.GetEntityByIdAsync(id);
			_repository.DeletetEntity(contact);
			await _unitOfWork.CommitAsync();
		}
		public async Task<ContactUpdateVM> GetContactById(int id)
		{
			var contact = await _repository.Where(x => x.Id == id).ProjectTo<ContactUpdateVM>(_mapper.ConfigurationProvider).SingleAsync();
			return contact;
		}
		public async Task UpdateContactAsync(ContactUpdateVM request)
		{
			var contact = _mapper.Map<Contact>(request);
			_repository.UpdatetEntity(contact);
			await _unitOfWork.CommitAsync();
		}
	}
}
