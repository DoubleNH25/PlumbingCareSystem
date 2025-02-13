using FluentValidation;
using PlumpingCareSystem.Entity.Identity.ViewModels;
using PlumpingCareSystem.Service.Messages.Identity;
using PlumpingCareSystem.Service.Messages.WebApplication;


namespace PlumpingCareSystem.Service.FluentValidation.Identity
{
	public class LogInValidation : AbstractValidator<LogInVM>
	{
		public LogInValidation()
		{
			RuleFor(x => x.Email)
			   .NotEmpty().WithMessage(ValidationMessages.NullEmptyMessage("Email"))
			   .NotNull().WithMessage(ValidationMessages.NullEmptyMessage("Email"))
			   .EmailAddress().WithMessage(IdentityMessages.CheckEmailAddress());
			RuleFor(x => x.Password)
				.NotEmpty().WithMessage(ValidationMessages.NullEmptyMessage("Password"))
				.NotNull().WithMessage(ValidationMessages.NullEmptyMessage("Password"));

		}
	}
}