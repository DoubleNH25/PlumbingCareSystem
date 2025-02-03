using PlumpingCareSystem.Entity.WebApplication.ViewModels.Contact;
using PlumpingCareSystem.Service.ServiceHolding.Abstract;

namespace PlumpingCareSystem.Service.ServiceHolding.Concrete
{
	public class ContactService : IContactService
	{
		public Task AddContactAsync(ContactAddVM request)
		{
			throw new NotImplementedException();
		}

		public Task DeleteContactAsync(int id)
		{
			throw new NotImplementedException();
		}

		public Task<List<ContactListVM>> GetAllListAsync()
		{
			throw new NotImplementedException();
		}

		public Task<ContactUpdateVM> GetContactById(int id)
		{
			throw new NotImplementedException();
		}

		public Task UpdateContactAsync(ContactUpdateVM request)
		{
			throw new NotImplementedException();
		}
	}
}
