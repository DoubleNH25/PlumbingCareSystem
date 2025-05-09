﻿using FluentValidation;
using PlumpingCareSystem.Entity.Identity.ViewModels;
using PlumpingCareSystem.Service.Messages.Identity;
using PlumpingCareSystem.Service.Messages.WebApplication;

namespace PlumpingCareSystem.Service.FluentValidation.Identity
{
	public class SignUpValidation : AbstractValidator<SignUpVM>
	{
		public SignUpValidation()
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
			RuleFor(x => x.ConfirmPassword)
				.NotEmpty().WithMessage(ValidationMessages.NullEmptyMessage("Confirm Password"))
				.NotNull().WithMessage(ValidationMessages.NullEmptyMessage("Confirm Password"))
				.Equal(x => x.Password).WithMessage(IdentityMessages.ComparePassword());

		}
	}
}
