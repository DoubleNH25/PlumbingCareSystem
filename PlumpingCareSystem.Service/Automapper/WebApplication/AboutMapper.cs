using AutoMapper;
using PlumpingCareSystem.Entity.WebApplication.Entities;
using PlumpingCareSystem.Entity.WebApplication.ViewModels.AboutVM;

namespace PlumpingCareSystem.Service.Automapper.WebApplication
{
	public class AboutMapper : Profile
	{
		public AboutMapper()
		{
			CreateMap<About, AboutListVM>().ReverseMap();
			CreateMap<About, AboutAddVM>().ReverseMap();
			CreateMap<About, AboutUpdateVM>().ReverseMap();
		}
	}
}