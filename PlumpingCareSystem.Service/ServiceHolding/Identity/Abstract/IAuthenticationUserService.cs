using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using PlumpingCareSystem.Entity.Identity.Entities;
using PlumpingCareSystem.Entity.Identity.ViewModels;
namespace PlumpingCareSystem.Service.ServiceHolding.Identity.Abstract
{
	public interface IAuthenticationUserService
	{
		Task<UserEditVM> FindUserAsync(HttpContext httpContext);
		Task<IdentityResult> UserEditAsync(UserEditVM request, AppUser user);
	}
}
