using Microsoft.AspNetCore.Identity;
using PlumpingCareSystem.Entity.Identity.ViewModels;

namespace PlumpingCareSystem.Service.ServiceHolding.Identity.Abstract
{
	public interface IAuthenticationAdminService
	{
		Task<List<UserVM>> GetUserListAsync();
		Task<IdentityResult> ExtendClaimAsync(string username);
	}
}