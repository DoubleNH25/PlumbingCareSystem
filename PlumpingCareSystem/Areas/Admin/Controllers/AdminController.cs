using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using PlumpingCareSystem.Service.Messages.Identity;
using PlumpingCareSystem.Service.ServiceHolding.Identity.Abstract;

namespace PlumpingCareSystem.Areas.Admin.Controllers
{
	[Authorize(Policy = "AdminObserver")]
	[Area("Admin")]
	public class AdminController : Controller
	{
		private readonly IAuthenticationAdminService _admin;
		private readonly IToastNotification _toasty;

		public AdminController(IToastNotification toasty, IAuthenticationAdminService admin)
		{
			_toasty = toasty;
			_admin = admin;
		}

		public async Task<IActionResult> GetUserList()
		{
			var userListVM = await _admin.GetUserListAsync();
			return View(userListVM);
		}

		public async Task<IActionResult> ExtendClaim(string username)
		{

			var renewClaim = await _admin.ExtendClaimAsync(username);
			if (!renewClaim.Succeeded)
			{
				_toasty.AddErrorToastMessage(NotificationMessagesIdentity.ExtendClaimFailed, new ToastrOptions { Title = "I am sorry!!" });
				return RedirectToAction("GetUserList", "Admin", new { Area = "Admin" });
			}
			_toasty.AddSuccessToastMessage(NotificationMessagesIdentity.ExtendClaimSuccess, new ToastrOptions { Title = "Congratulations" });
			return RedirectToAction("GetUserList", "Admin", new { Area = "Admin" });
		}
	}
}