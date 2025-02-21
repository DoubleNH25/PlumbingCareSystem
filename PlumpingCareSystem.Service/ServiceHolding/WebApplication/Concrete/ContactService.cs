using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
using PlumpingCareSystem.Entity.WebApplication.Entities;
using PlumpingCareSystem.Entity.WebApplication.ViewModels.Contact;
using PlumpingCareSystem.Repository.Repositories.Abstract;
using PlumpingCareSystem.Repository.UnitOfWorks.Abstract;
using PlumpingCareSystem.Service.Exception.WebApplication;
using PlumpingCareSystem.Service.Messages.WebApplication;
using PlumpingCareSystem.Service.ServiceHolding.WebApplication.Abstract;

namespace PlumpingCareSystem.Service.ServiceHolding.WebApplication.Concrete
{
	public class ContactService : IContactService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;
		private readonly IGenericRepositories<Contact> _repository;
		private readonly IToastNotification _toasty;
		private const string Section = "Contact section";
		public ContactService(IUnitOfWork unitOfWork, IMapper mapper, IToastNotification toasty)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
			_repository = _unitOfWork.GetGenericRepository<Contact>();
			_toasty = toasty;
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
			_toasty.AddSuccessToastMessage(NotificationMessagesWebApplication.AddMessage(Section), new ToastrOptions { Title = NotificationMessagesWebApplication.SuccessedTitle });
		}
		public async Task DeleteContactAsync(int id)
		{
			var contact = await _repository.GetEntityByIdAsync(id);
			_repository.DeletetEntity(contact);
			await _unitOfWork.CommitAsync();
			_toasty.AddWarningToastMessage(NotificationMessagesWebApplication.DeleteMessage(Section), new ToastrOptions { Title = NotificationMessagesWebApplication.SuccessedTitle });
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
			var result = await _unitOfWork.CommitAsync();

			if (!result)
			{
				throw new ClientSideExceptions(ExceptionMessages.ConcurencyException);
			}
			_toasty.AddInfoToastMessage(NotificationMessagesWebApplication.UpdateMessage(Section), new ToastrOptions { Title = NotificationMessagesWebApplication.SuccessedTitle });
		}
	}
}
