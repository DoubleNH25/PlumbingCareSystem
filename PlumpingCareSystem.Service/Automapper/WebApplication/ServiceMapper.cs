using AutoMapper;
using PlumpingCareSystem.Entity.WebApplication.Entities;
using PlumpingCareSystem.Entity.WebApplication.ViewModels.Service;

namespace PlumpingCareSystem.Service.Automapper.WebApplication
{
	public class ServiceMapper : Profile
	{
		public ServiceMapper()
		{
			CreateMap<Services, ServiceListVM>().ReverseMap();
			CreateMap<Services, ServiceAddVM>().ReverseMap();
			CreateMap<Services, ServiceUpdateVM>().ReverseMap();
		}
	}
}