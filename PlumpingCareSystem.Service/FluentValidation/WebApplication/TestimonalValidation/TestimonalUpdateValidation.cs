

using FluentValidation;
using PlumpingCareSystem.Entity.WebApplication.ViewModels.Testimonal;
using PlumpingCareSystem.Service.Messages.WebApplication;

namespace PlumpingCareSystem.Service.FluentValidation.WebApplication.TestimonalValidation
{
	public class TestimonalUpdateValidation : AbstractValidator<TestimonalUpdateVM>
	{
		public TestimonalUpdateValidation()
		{
			RuleFor(x => x.FullName)
				.NotEmpty().WithMessage(ValidationMessages.NullEmptyMessage("FullName"))
				.NotNull().WithMessage(ValidationMessages.NullEmptyMessage("FullName"))
				.MaximumLength(100).WithMessage(ValidationMessages.MaximumCharachterAllowence("FullName", 100));
			RuleFor(x => x.Title)
			   .NotEmpty().WithMessage(ValidationMessages.NullEmptyMessage("Title"))
			   .NotNull().WithMessage(ValidationMessages.NullEmptyMessage("Title"))
			   .MaximumLength(100).WithMessage(ValidationMessages.MaximumCharachterAllowence("Title", 100));
			RuleFor(x => x.Comment)
			   .NotEmpty().WithMessage(ValidationMessages.NullEmptyMessage("Comment"))
			   .NotNull().WithMessage(ValidationMessages.NullEmptyMessage("Comment"))
			   .MaximumLength(2000).WithMessage(ValidationMessages.MaximumCharachterAllowence("Comment", 2000)); ;

		}
	}
}