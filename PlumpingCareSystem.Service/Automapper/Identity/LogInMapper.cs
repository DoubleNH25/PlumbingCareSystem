using AutoMapper;
using PlumpingCareSystem.Entity.Identity.Entities;
using PlumpingCareSystem.Entity.Identity.ViewModels;


namespace PlumpingCareSystem.Service.Automapper.Identity
{
	public class LogInMapper : Profile
	{
		public LogInMapper()
		{
			CreateMap<AppUser, LogInVM>().ReverseMap();
		}
	}
}
