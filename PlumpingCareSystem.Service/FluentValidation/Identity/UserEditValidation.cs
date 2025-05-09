﻿using FluentValidation;
using PlumpingCareSystem.Entity.Identity.ViewModels;
using PlumpingCareSystem.Service.Messages.Identity;
using PlumpingCareSystem.Service.Messages.WebApplication;

namespace PlumpingCareSystem.Service.FluentValidation.Identity
{
	public class UserEditValidation : AbstractValidator<UserEditVM>
	{
		public UserEditValidation()
		{
			RuleFor(x => x.Username)
				.NotEmpty().WithMessage(ValidationMessages.NullEmptyMessage("Username"))
				.NotNull().WithMessage(ValidationMessages.NullEmptyMessage("username"));
			RuleFor(x => x.Email)
				.NotEmpty().WithMessage(ValidationMessages.NullEmptyMessage("Email"))
				.NotNull().WithMessage(ValidationMessages.NullEmptyMessage("Email"))
				.EmailAddress().WithMessage(IdentityMessages.CheckEmailAddress());
			RuleFor(x => x.Password)
				.NotEmpty().WithMessage(ValidationMessages.NullEmptyMessage("Password"))
				.NotNull().WithMessage(ValidationMessages.NullEmptyMessage("Password"));
			RuleFor(x => x.ConfirmNewPassword)
				.Equal(x => x.NewPassword).WithMessage(IdentityMessages.ComparePassword());
		}
	}
}