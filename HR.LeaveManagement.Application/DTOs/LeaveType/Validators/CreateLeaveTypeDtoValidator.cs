using FluentValidation;
using HR.LeaveManagement.Application.DTOs.LeaveType.Validators.CommonValidations;

namespace HR.LeaveManagement.Application.DTOs.LeaveType.Validators
{
    public class CreateLeaveTypeDtoValidator : AbstractValidator<CreateLeaveTypeDto>
    {
        public CreateLeaveTypeDtoValidator()
        {
            Include(new LeaveTypeCommonDtoValidator());
        }
    }
}