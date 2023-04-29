using FluentValidation;
using HR.LeaveManagement.Application.DTOs.LeaveType.Validators.CommonValidations;

namespace HR.LeaveManagement.Application.DTOs.LeaveType.Validators
{
    public class UpdateLeaveTypeDtoValidator : AbstractValidator<UpdateLeaveTypeDto>
    {
        public UpdateLeaveTypeDtoValidator()
        {
            Include(new LeaveTypeCommonDtoValidator());

            RuleFor(x => x.Id).NotEmpty().WithMessage("{PropertyName} must be provided!");
        }
    }
}