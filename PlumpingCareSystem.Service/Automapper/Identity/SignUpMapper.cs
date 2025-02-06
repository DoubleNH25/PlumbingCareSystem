using AutoMapper;
using PlumpingCareSystem.Entity.Identity.Entities;
using PlumpingCareSystem.Entity.Identity.ViewModels;

namespace PlumpingCareSystem.Service.Automapper.Identity
{
	public class SignUpMapper : Profile
	{
		public SignUpMapper()
		{
			CreateMap<AppUser, SignUpVM>().ReverseMap();
		}
	}
}
