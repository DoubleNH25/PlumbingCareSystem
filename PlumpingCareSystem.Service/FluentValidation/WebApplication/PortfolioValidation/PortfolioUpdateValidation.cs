

using FluentValidation;
using PlumpingCareSystem.Entity.WebApplication.ViewModels.Portfolio;
using PlumpingCareSystem.Service.Messages.WebApplication;

namespace PlumpingCareSystem.Service.FluentValidation.WebApplication.PortfolioValidation
{
	public class PortfolioUpdateValidation : AbstractValidator<PortfolioUpdateVM>
	{
		public PortfolioUpdateValidation()
		{

			RuleFor(x => x.Title)
			   .NotEmpty().WithMessage(ValidationMessages.NullEmptyMessage("Title"))
			   .NotNull().WithMessage(ValidationMessages.NullEmptyMessage("Title"))
			   .MaximumLength(200).WithMessage(ValidationMessages.MaximumCharachterAllowence("Title", 200));

		}
	}
}