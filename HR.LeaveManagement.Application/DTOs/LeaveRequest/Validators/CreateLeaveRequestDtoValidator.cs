using FluentValidation;
using HR.LeaveManagement.Application.DTOs.LeaveRequest.Validators.CommonValidations;
using HR.LeaveManagement.Application.Persistence.Contracts;

namespace HR.LeaveManagement.Application.DTOs.LeaveRequest.Validators
{
    public class CreateLeaveRequestDtoValidator : AbstractValidator<CreateLeaveRequestDto>
    {
        public CreateLeaveRequestDtoValidator(ILeaveRequestRepository leaveRequestRepository)
        {
            Include(new LeaveRequestCommonDtoValidator(leaveRequestRepository));
        }
    }
}