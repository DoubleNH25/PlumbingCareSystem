﻿

using FluentValidation;
using PlumpingCareSystem.Entity.WebApplication.ViewModels.Contact;
using PlumpingCareSystem.Service.Messages.WebApplication;

namespace PlumpingCareSystem.Service.FluentValidation.WebApplication.ContactValidation
{
	public class ContactAddValidation : AbstractValidator<ContactAddVM>
	{
		public ContactAddValidation()
		{
			RuleFor(x => x.Location)
			   .NotEmpty().WithMessage(ValidationMessages.NullEmptyMessage("Location"))
			   .NotNull().WithMessage(ValidationMessages.NullEmptyMessage("Location"))
			   .MaximumLength(200).WithMessage(ValidationMessages.MaximumCharachterAllowence("Location", 200));
			RuleFor(x => x.Email)
			   .NotEmpty().WithMessage(ValidationMessages.NullEmptyMessage("Email"))
			   .NotNull().WithMessage(ValidationMessages.NullEmptyMessage("Email"))
			   .MaximumLength(100).WithMessage(ValidationMessages.MaximumCharachterAllowence("Email", 100));
			RuleFor(x => x.Call)
			   .NotEmpty().WithMessage(ValidationMessages.NullEmptyMessage("Call"))
			   .NotNull().WithMessage(ValidationMessages.NullEmptyMessage("Call"))
			   .MaximumLength(17).WithMessage(ValidationMessages.MaximumCharachterAllowence("Call", 17));
			RuleFor(x => x.Map)
			   .NotEmpty().WithMessage(ValidationMessages.NullEmptyMessage("Map"))
			   .NotNull().WithMessage(ValidationMessages.NullEmptyMessage("Map"));
		}
	}
}
