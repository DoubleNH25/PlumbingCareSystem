using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
using PlumpingCareSystem.Entity.Identity.Entities;
using PlumpingCareSystem.Entity.Identity.ViewModels;
using PlumpingCareSystem.Service.ServiceHolding.Identity.Abstract;
using System.Security.Claims;

namespace PlumpingCareSystem.Service.ServiceHolding.Identity.Concrete
{
	public class AuthenticationAdminService : IAuthenticationAdminService
	{
		private readonly UserManager<AppUser> _userManager;
		private readonly IMapper _mapper;
		private readonly IToastNotification _toasty;

		public AuthenticationAdminService(UserManager<AppUser> userManager, IMapper mapper, IToastNotification toasty)
		{
			_userManager = userManager;
			_mapper = mapper;
			_toasty = toasty;
		}

		public async Task<IdentityResult> ExtendClaimAsync(string username)
		{
			var user = await _userManager.FindByNameAsync(username);
			var claims = await _userManager.GetClaimsAsync(user!);
			var existingClaim = claims.FirstOrDefault(x => x.Type.Contains("Observer"));

			var newExtendedClaim = new Claim("AdminObserverExpireDate", DateTime.Now.AddDays(5).ToString());

			return await _userManager.ReplaceClaimAsync(user!, existingClaim!, newExtendedClaim);

		}

		public async Task<List<UserVM>> GetUserListAsync()
		{
			var userList = await _userManager.Users.ToListAsync();
			var userListVM = _mapper.Map<List<UserVM>>(userList);

			for (int i = 0; i < userList.Count; i++)
			{
				var userRoles = await _userManager.GetRolesAsync(userList[i]);
				userListVM[i].UserRoles = userRoles;

				var userClaims = await _userManager.GetClaimsAsync(userList[i]);
				userListVM[i].UserClaims = userClaims;
			}

			return userListVM;
		}
	}
}