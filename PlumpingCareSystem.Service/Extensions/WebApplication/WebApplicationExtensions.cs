using Microsoft.Extensions.DependencyInjection;
using PlumpingCareSystem.Entity.WebApplication.Entities;
using PlumpingCareSystem.Service.Filters.WebApplication;

namespace PlumpingCareSystem.Service.Extensions.WebApplication
{
	public static class WebApplicationExtensions
	{
		public static IServiceCollection LoadWebApplicationExtensions(this IServiceCollection services)
		{
			services.AddScoped(typeof(GenericAddPreventationFilter<>));
			services.AddScoped(typeof(GenericNotFoundFilter<>));
			return services;
		}
	}
}