using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PlumpingCareSystem.Entity.Identity.Entities;
using PlumpingCareSystem.Entity.Identity.ViewModels;

namespace PlumpingCareSystem.Service.ServiceHolding.Identity.Abstract
{
	public interface IAuthenticationMainService
	{
		Task CreateResetCredentialsAndSend(AppUser user, HttpContext context, IUrlHelper url, ForgotPasswordVM request);
	}
}