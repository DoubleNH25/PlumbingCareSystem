using AutoMapper;
using PlumpingCareSystem.Entity.Identity.Entities;
using PlumpingCareSystem.Entity.Identity.ViewModels;

namespace PlumpingCareSystem.Service.Automapper.Identity
{
	public class UserEditMapper : Profile
	{
		public UserEditMapper()
		{
			CreateMap<AppUser, UserEditVM>().ReverseMap();
		}
	}
}
