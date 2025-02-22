using AutoMapper;
using PlumpingCareSystem.Entity.WebApplication.Entities;
using PlumpingCareSystem.Entity.WebApplication.ViewModels.Team;

namespace PlumpingCareSystem.Service.Automapper.WebApplication
{
	public class TeamMapper : Profile
	{
		public TeamMapper()
		{
			CreateMap<Team, TeamListVM>().ReverseMap();
			CreateMap<Team, TeamAddVM>().ReverseMap();
			CreateMap<Team, TeamUpdateVM>().ReverseMap();
			CreateMap<Team, TeamListForUI>().ReverseMap();

		}
	}
}