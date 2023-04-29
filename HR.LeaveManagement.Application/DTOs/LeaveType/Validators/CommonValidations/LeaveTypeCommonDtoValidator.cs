using FluentValidation;

namespace HR.LeaveManagement.Application.DTOs.LeaveType.Validators.CommonValidations
{
    public class LeaveTypeCommonDtoValidator : AbstractValidator<ILeaveTypeDtoValidation>
    {
        private const int NameMaxLength = 50;
        private const int DefaultDaysMax = 100;

        public LeaveTypeCommonDtoValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(NameMaxLength)
                .WithMessage("{PropertyName} must not exceed {ComparsionValue} characters.");

            RuleFor(x => x.DefaultDays)
                .NotEmpty()
                .WithMessage("{PropertyName} is required.")
                .GreaterThan(0)
                .WithMessage("{PropertyName} must be at least 1.")
                .LessThan(DefaultDaysMax)
                .WithMessage("{PropertyName} must be less than {ComparsionValue}.");
        }
    }
}