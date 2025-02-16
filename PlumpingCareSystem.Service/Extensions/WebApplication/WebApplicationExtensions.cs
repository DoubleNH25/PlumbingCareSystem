using Microsoft.Extensions.DependencyInjection;
using PlumpingCareSystem.Service.Filters.WebApplication;

namespace PlumpingCareSystem.Service.Extensions.WebApplication
{
	public static class WebApplicationExtensions
	{
		public static IServiceCollection LoadWebApplicationExtensions(this IServiceCollection services)
		{
			services.AddScoped(typeof(AddAboutPreventationFilter));
			return services;
		}
	}
}