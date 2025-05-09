﻿

using Microsoft.AspNetCore.Identity;
using PlumpingCareSystem.Entity.Identity.Entities;

namespace PlumpingCareSystem.Service.Customization.Identity.Validators
{
	internal class CustomPasswordValidator : IPasswordValidator<AppUser>
	{
		public Task<IdentityResult> ValidateAsync(UserManager<AppUser> manager, AppUser user, string? password)
		{
			var errors = new List<IdentityError>();
			if (password!.ToLower().Contains(user.UserName!.ToLower()))
			{
				errors.Add(new() { Code = "UsernameContainError", Description = "Password can not contain username!!" });
			}
			if (password.StartsWith("1234"))
			{
				errors.Add(new() { Code = "PasswordStartDigitError", Description = "Password can not start with 1234!!" });
			}
			if (errors.Any())
			{
				return Task.FromResult(IdentityResult.Failed(errors.ToArray()));
			}
			return Task.FromResult(IdentityResult.Success);
		}
	}
}
