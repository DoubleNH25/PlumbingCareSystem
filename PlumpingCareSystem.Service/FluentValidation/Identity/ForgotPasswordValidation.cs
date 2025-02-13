using FluentValidation;
using PlumpingCareSystem.Entity.Identity.ViewModels;
using PlumpingCareSystem.Service.Messages.Identity;
using PlumpingCareSystem.Service.Messages.WebApplication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlumpingCareSystem.Service.FluentValidation.Identity
{
	public class ForgotPasswordValidation : AbstractValidator<ForgotPasswordVM>
	{
		public ForgotPasswordValidation()
		{
			RuleFor(x => x.Email)
			  .NotEmpty().WithMessage(ValidationMessages.NullEmptyMessage("Email"))
			  .NotNull().WithMessage(ValidationMessages.NullEmptyMessage("Email"))
			  .EmailAddress().WithMessage(IdentityMessages.CheckEmailAddress());
		}
	}
}