﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PlumpingCareSystem.Repository.Context;


namespace PlumpingCareSystem.Repository.Extensions
{
	public static class RepositoryLayerExtensions
	{
		public static IServiceCollection LoadRepositoryLayerExtensions(this IServiceCollection services, IConfiguration config)
		{
			services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(config.GetConnectionString("SqlConnection")));

			return services;

		}
	}
}