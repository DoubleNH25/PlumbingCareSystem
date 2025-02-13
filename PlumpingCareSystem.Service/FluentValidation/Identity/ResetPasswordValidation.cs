using FluentValidation;
using PlumpingCareSystem.Entity.Identity.ViewModels;
using PlumpingCareSystem.Service.Messages.Identity;
using PlumpingCareSystem.Service.Messages.WebApplication;


namespace PlumpingCareSystem.Service.FluentValidation.Identity
{
	public class ResetPasswordValidation : AbstractValidator<ResetPasswordVM>
	{
		public ResetPasswordValidation()
		{
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