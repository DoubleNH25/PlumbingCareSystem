using AutoMapper;
using PlumpingCareSystem.Entity.WebApplication.Entities;
using PlumpingCareSystem.Entity.WebApplication.ViewModels.Testimonal;

namespace PlumpingCareSystem.Service.Automapper.WebApplication
{
	public class TestimonalMaper : Profile
	{
		public TestimonalMaper()
		{
			CreateMap<Testimonal, TestimonalListVM>().ReverseMap();
			CreateMap<Testimonal, TestimonalAddVM>().ReverseMap();
			CreateMap<Testimonal, TestimonalUpdateVM>().ReverseMap();
		}
	}
}