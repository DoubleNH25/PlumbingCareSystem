using AutoMapper;
using PlumpingCareSystem.Entity.Identity.Entities;
using PlumpingCareSystem.Entity.Identity.ViewModels;

namespace PlumpingCareSystem.Service.Automapper.Identity
{
	public class ResetPasswordMapper : Profile
	{
		public ResetPasswordMapper()
		{
			CreateMap<AppUser, ResetPasswordVM>().ReverseMap();
		}
	}
}