using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PlumpingCareSystem.Repository.Context;
using PlumpingCareSystem.Repository.Repositories.Abstract;
using PlumpingCareSystem.Repository.Repositories.Concrete;
using PlumpingCareSystem.Repository.UnitOfWorks.Abstract;
using PlumpingCareSystem.Repository.UnitOfWorks.Concrete;


namespace PlumpingCareSystem.Repository.Extensions
{
	public static class RepositoryLayerExtensions
	{
		public static IServiceCollection LoadRepositoryLayerExtensions(this IServiceCollection services, IConfiguration config)
		{
			services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(config.GetConnectionString("SqlConnection")));

			services.AddScoped(typeof(IGenericRepositories<>), typeof(GenericRepositories<>));

			services.AddScoped<IUnitOfWork, UnitOfWork>();

			return services;

		}
	}
}