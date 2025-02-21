using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PlumpingCareSystem.Entity.Identity.Entities;
using PlumpingCareSystem.Entity.Identity.ViewModels;
using PlumpingCareSystem.Repository.Context;
using PlumpingCareSystem.Service.Customization.Identity.ErrorDescriber;
using PlumpingCareSystem.Service.Customization.Identity.Validators;
using PlumpingCareSystem.Service.Helpers.Identity.EmailHelper;

namespace PlumpingCareSystem.Service.Extensions.Identity
{
	public static class IdentityExtensions
	{
		public static IServiceCollection LoadIdentityExtensions
			(this IServiceCollection services, IConfiguration config)
		{
			services.AddIdentity<AppUser, AppRole>(opt =>
			{
				opt.Password.RequiredLength = 10;
				opt.Password.RequireNonAlphanumeric = true;
				opt.Password.RequiredUniqueChars = 2;
				opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromSeconds(60);
				opt.Lockout.MaxFailedAccessAttempts = 3;
				opt.User.RequireUniqueEmail = true;

			})
				.AddRoleManager<RoleManager<AppRole>>()
				.AddEntityFrameworkStores<AppDbContext>()
				.AddDefaultTokenProviders()
				.AddErrorDescriber<LocalizationErrorDescriber>()
				.AddPasswordValidator<CustomPasswordValidator>()
				.AddUserValidator<CustomUserValidator>();

			services.ConfigureApplicationCookie(opt =>
			{
				var newCookie = new CookieBuilder();
				newCookie.Name = "PlumbingCompany";
				opt.LoginPath = new PathString("/Authentication/LogIn");
				opt.LogoutPath = new PathString("/Authentication/LogOut");
				opt.AccessDeniedPath = new PathString("/Authentication/AccessDenied");
				opt.Cookie = newCookie;
				opt.ExpireTimeSpan = TimeSpan.FromMinutes(60);
			});

			services.Configure<DataProtectionTokenProviderOptions>(opt =>
			{
				opt.TokenLifespan = TimeSpan.FromMinutes(10);
			});
			services.AddScoped<IEmailSendMethod, EmailSendMethod>();

			services.Configure<GmailInformationVM>(config.GetSection("EmailSettings"));

			return services;
		}
	}
}
