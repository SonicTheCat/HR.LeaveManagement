using FluentValidation;
using HR.LeaveManagement.Application.DTOs.LeaveRequest.Validators.CommonValidations;
using HR.LeaveManagement.Application.Persistence.Contracts;

namespace HR.LeaveManagement.Application.DTOs.LeaveRequest.Validators
{
    public class UpdateLeaveRequestDtoValidator : AbstractValidator<UpdateLeaveRequestDto>
    {
        public UpdateLeaveRequestDtoValidator(ILeaveRequestRepository leaveRequestRepository)
        {
            Include(new LeaveRequestCommonDtoValidator(leaveRequestRepository));

            RuleFor(x => x.Id).NotEmpty().WithMessage("{PropertyName} must be provided!");
        }
    }
}