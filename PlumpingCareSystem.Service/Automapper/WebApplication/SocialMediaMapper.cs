using AutoMapper;
using PlumpingCareSystem.Entity.WebApplication.Entities;
using PlumpingCareSystem.Entity.WebApplication.ViewModels.SocialMedia;

namespace PlumpingCareSystem.Service.Automapper.WebApplication
{
	public class SocialMediaMapper : Profile
	{
		public SocialMediaMapper()
		{
			CreateMap<SocialMedia, SocialMediaListVM>().ReverseMap();
			CreateMap<SocialMedia, SocialMediaAddVM>().ReverseMap();
			CreateMap<SocialMedia, SocialMediaUpdateVM>().ReverseMap();
		}
	}
}