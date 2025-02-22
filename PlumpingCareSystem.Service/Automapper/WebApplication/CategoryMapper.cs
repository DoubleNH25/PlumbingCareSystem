using AutoMapper;
using PlumpingCareSystem.Entity.WebApplication.Entities;
using PlumpingCareSystem.Entity.WebApplication.ViewModels.Category;


namespace PlumpingCareSystem.Service.Automapper.WebApplication
{
	public class CategoryMapper : Profile
	{
		public CategoryMapper()
		{
			CreateMap<Category, CategoryListVM>().ReverseMap();
			CreateMap<Category, CategoryAddVM>().ReverseMap();
			CreateMap<Category, CategoryUpdateVM>().ReverseMap();
			CreateMap<Category, CategoryListForUI>().ReverseMap();

		}
	}
}