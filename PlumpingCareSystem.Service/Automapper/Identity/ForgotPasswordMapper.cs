using AutoMapper;
using PlumpingCareSystem.Entity.Identity.Entities;
using PlumpingCareSystem.Entity.Identity.ViewModels;


namespace PlumpingCareSystem.Service.Automapper.Identity
{
    public class ForgotPasswordMapper : Profile
	{
		public ForgotPasswordMapper()
		{
			CreateMap<AppUser, ForgotPasswordVM>().ReverseMap();
		}
	}
}
