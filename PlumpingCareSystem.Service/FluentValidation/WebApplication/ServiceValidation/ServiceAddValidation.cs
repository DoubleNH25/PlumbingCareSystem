﻿

using FluentValidation;
using PlumpingCareSystem.Entity.WebApplication.ViewModels.Service;
using PlumpingCareSystem.Service.Messages.WebApplication;

namespace PlumpingCareSystem.Service.FluentValidation.WebApplication.ServiceValidation
{
	public class ServiceAddValidation : AbstractValidator<ServiceAddVM>
	{
		public ServiceAddValidation()
		{
			RuleFor(x => x.Name)
			   .NotEmpty().WithMessage(ValidationMessages.NullEmptyMessage("Name"))
			   .NotNull().WithMessage(ValidationMessages.NullEmptyMessage("Name"))
			   .MaximumLength(200).WithMessage(ValidationMessages.MaximumCharachterAllowence("Name", 200));
			RuleFor(x => x.Description)
			   .NotEmpty().WithMessage(ValidationMessages.NullEmptyMessage("Description"))
			   .NotNull().WithMessage(ValidationMessages.NullEmptyMessage("Description"))
			   .MaximumLength(2000).WithMessage(ValidationMessages.MaximumCharachterAllowence("Description", 2000));
			RuleFor(x => x.Icon)
			   .NotEmpty().WithMessage(ValidationMessages.NullEmptyMessage("Icon"))
			   .NotNull().WithMessage(ValidationMessages.NullEmptyMessage("Icon"))
			   .MaximumLength(100).WithMessage(ValidationMessages.MaximumCharachterAllowence("Icon", 100));
		}
	}
}