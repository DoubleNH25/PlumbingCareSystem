﻿using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace PlumpingCareSystem.Service.Extensions
{
	public static class ServiceLayerExtensions
	{
		public static IServiceCollection LoadServiceLayerExtensions(this IServiceCollection services)
		{
			services.AddAutoMapper(Assembly.GetExecutingAssembly());
			
			var types = Assembly.GetExecutingAssembly().GetTypes()
				.Where(x => x.IsClass && !x.IsAbstract && x.Name.EndsWith("Service"));

			foreach (var serviceType in types)
			{
				var iServiceType = serviceType.GetInterfaces().FirstOrDefault(x => x.Name == $"I{serviceType.Name}");
				if (iServiceType != null)
				{
					services.AddScoped(iServiceType, serviceType);
				}
			}

			return services;
		}
	}
}
