﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PlumpingCareSystem.Entity.Identity.Entities;
using PlumpingCareSystem.Entity.Identity.ViewModels;
using PlumpingCareSystem.Service.Helpers.Identity.EmailHelper;
using PlumpingCareSystem.Service.ServiceHolding.Identity.Abstract;

namespace PlumpingCareSystem.Service.ServiceHolding.Identity.Concrete
{
	public class AuthenticationMainService : IAuthenticationMainService
	{
		private readonly IEmailSendMethod _email;
		private readonly UserManager<AppUser> _userManager;
		public AuthenticationMainService(IEmailSendMethod email, UserManager<AppUser> userManager)
		{
			_email = email;
			_userManager = userManager;
		}
		public async Task CreateResetCredentialsAndSend(AppUser user, HttpContext context, IUrlHelper url, ForgotPasswordVM request)
		{
			string resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
			var passwordResetLink = url.Action("ResetPassword", "Authentication", new { userId = user.Id, token = resetToken }, context.Request.Scheme);
			await _email.SendPasswordResetLinkWithToken(passwordResetLink!, request.Email);
		}
	}
}
