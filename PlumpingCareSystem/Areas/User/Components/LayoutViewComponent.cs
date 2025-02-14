using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PlumpingCareSystem.Entity.Identity.Entities;
using PlumpingCareSystem.Entity.Identity.ViewModels;

namespace PlumpingCareSystem.Areas.User.Components
{
	[Authorize]
	[Area("User")]
	public class LayoutViewComponent : ViewComponent
	{
		private readonly UserManager<AppUser> _userManager;
		public LayoutViewComponent(UserManager<AppUser> userManager)
		{
			_userManager = userManager;
		}
		public async Task<IViewComponentResult> InvokeAsync(string Username)
		{

			if (Username == null)
			{
				Username = User.Identity!.Name!;
			}
			var user = await _userManager.FindByNameAsync(Username);
			if (user!.FileName == null)
			{
				return View(new UserPictureVM { FileName = "Default" });
			}
			return View(new UserPictureVM { FileName = user.FileName });
		}
	}
}