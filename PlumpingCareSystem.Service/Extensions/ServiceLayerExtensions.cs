﻿using FluentValidation.AspNetCore;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using PlumpingCareSystem.Service.FluentValidation.WebApplication.HomePageValidation;
using System.Reflection;
using NToastNotify;
using PlumpingCareSystem.Service.Extensions.Identity;
using Microsoft.Extensions.Configuration;
using PlumpingCareSystem.Service.Helpers.Generic.Image;
using PlumpingCareSystem.Service.Extensions.WebApplication;

namespace PlumpingCareSystem.Service.Extensions
{
	public static class ServiceLayerExtensions
	{
		public static IServiceCollection LoadServiceLayerExtensions
			(this IServiceCollection services, IConfiguration config)
		{
			services.LoadIdentityExtensions(config);

			services.LoadWebApplicationExtensions();

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

			services.AddFluentValidationAutoValidation(opt =>
			{
				opt.DisableDataAnnotationsValidation = true;
			});

			services.AddValidatorsFromAssemblyContaining<HomePageAddValidation>();

			services.AddScoped<IImageHelper, ImageHelper>();




			return services;
		}
	}
}
