

using FluentValidation;
using PlumpingCareSystem.Entity.WebApplication.ViewModels.Team;
using PlumpingCareSystem.Service.Messages.WebApplication;

namespace PlumpingCareSystem.Service.FluentValidation.WebApplication.TeamValidation
{
	public class TeamUpdateValidation : AbstractValidator<TeamUpdateVM>
	{
		public TeamUpdateValidation()
		{
			RuleFor(x => x.FullName)
			  .NotEmpty().WithMessage(ValidationMessages.NullEmptyMessage("FullName"))
			  .NotNull().WithMessage(ValidationMessages.NullEmptyMessage("FullName"))
			  .MaximumLength(100).WithMessage(ValidationMessages.MaximumCharachterAllowence("FullName", 100));
			RuleFor(x => x.Title)
			   .NotEmpty().WithMessage(ValidationMessages.NullEmptyMessage("Title"))
			   .NotNull().WithMessage(ValidationMessages.NullEmptyMessage("Title"))
			   .MaximumLength(100).WithMessage(ValidationMessages.MaximumCharachterAllowence("Title", 100));

		}
	}
}