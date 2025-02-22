using AutoMapper;
using PlumpingCareSystem.Entity.WebApplication.Entities;
using PlumpingCareSystem.Entity.WebApplication.ViewModels.Contact;

namespace PlumpingCareSystem.Service.Automapper.WebApplication
{
	public class ContactMapper : Profile
	{
		public ContactMapper()
		{
			CreateMap<Contact, ContactListVM>().ReverseMap();
			CreateMap<Contact, ContactAddVM>().ReverseMap();
			CreateMap<Contact, ContactUpdateVM>().ReverseMap();
			CreateMap<Contact, ContactListForUI>().ReverseMap();
		}
	}
}