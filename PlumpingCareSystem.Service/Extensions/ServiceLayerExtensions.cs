using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace PlumpingCareSystem.Service.Extensions
{
	public static class ServiceLayerExtensions
	{
		public static IServiceCollection LoadServiceLayerExtensions(this IServiceCollection services)
		{
			services.AddAutoMapper(Assembly.GetExecutingAssembly());
			return services;
		}
	}
}
