using AutoMapper;
using PlumpingCareSystem.Entity.WebApplication.Entities;
using PlumpingCareSystem.Entity.WebApplication.ViewModels.Portfolio;

namespace PlumpingCareSystem.Service.Automapper.WebApplication
{
	public class PortfolioMapper : Profile
	{
		public PortfolioMapper()
		{
			CreateMap<Portfolio, PortfolioListVM>().ReverseMap();
			CreateMap<Portfolio, PortfolioAddVM>().ReverseMap();
			CreateMap<Portfolio, PortfolioUpdateVM>().ReverseMap();
		}
	}
}
