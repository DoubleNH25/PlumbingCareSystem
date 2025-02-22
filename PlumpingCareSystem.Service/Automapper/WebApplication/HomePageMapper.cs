using AutoMapper;
using PlumpingCareSystem.Entity.WebApplication.Entities;
using PlumpingCareSystem.Entity.WebApplication.ViewModels.HomePage;

namespace PlumpingCareSystem.Service.Automapper.WebApplication
{
	public class HomePageMapper : Profile
	{
		public HomePageMapper()
		{
			CreateMap<HomePage, HomePageListVM>().ReverseMap();
			CreateMap<HomePage, HomePageAddVM>().ReverseMap();
			CreateMap<HomePage, HomePageUpdateVM>().ReverseMap();
			CreateMap<HomePage, HomePageVMForUI>().ReverseMap();
		}
	}
}