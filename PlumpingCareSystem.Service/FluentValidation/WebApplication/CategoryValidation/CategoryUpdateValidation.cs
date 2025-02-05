

using FluentValidation;
using PlumpingCareSystem.Entity.WebApplication.ViewModels.Category;
using PlumpingCareSystem.Service.Messages.WebApplication;

namespace PlumpingCareSystem.Service.FluentValidation.WebApplication.CategoryValidation
{
	public class CategoryUpdateValidation : AbstractValidator<CategoryUpdateVM>
	{
		public CategoryUpdateValidation()
		{
			RuleFor(x => x.Name)
			   .NotEmpty().WithMessage(ValidationMessages.NullEmptyMessage("Name"))
			   .NotNull().WithMessage(ValidationMessages.NullEmptyMessage("Name"))
			   .MaximumLength(50).WithMessage(ValidationMessages.MaximumCharachterAllowence("Name", 50));
		}
	}
}