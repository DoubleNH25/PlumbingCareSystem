

using FluentValidation;
using PlumpingCareSystem.Entity.WebApplication.ViewModels.Portfolio;
using PlumpingCareSystem.Service.Messages.WebApplication;

namespace PlumpingCareSystem.Service.FluentValidation.WebApplication.PortfolioValidation
{
	public class PortfolioAddValidation : AbstractValidator<PortfolioAddVM>
	{
		public PortfolioAddValidation()
		{
			RuleFor(x => x.Title)
			   .NotEmpty().WithMessage(ValidationMessages.NullEmptyMessage("Title"))
			   .NotNull().WithMessage(ValidationMessages.NullEmptyMessage("Title"))
			   .MaximumLength(200).WithMessage(ValidationMessages.MaximumCharachterAllowence("Title", 200));

			RuleFor(x => x.Photo)
				.NotEmpty().WithMessage(ValidationMessages.NullEmptyMessage("Photo"))
				.NotNull().WithMessage(ValidationMessages.NullEmptyMessage("Photo"));
		}
	}
}