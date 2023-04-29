using FluentValidation;
using HR.LeaveManagement.Application.Persistence.Contracts;

namespace HR.LeaveManagement.Application.DTOs.LeaveRequest.Validators.CommonValidations
{
    public class LeaveRequestCommonDtoValidator : AbstractValidator<ILeaveRequestDtoValidation>
    {
        private readonly ILeaveRequestRepository leaveRequestRepository;

        public LeaveRequestCommonDtoValidator(ILeaveRequestRepository leaveRequestRepository)
        {
            this.leaveRequestRepository = leaveRequestRepository;

            RuleFor(x => x.StartDate)
                .NotEmpty()
                .WithMessage("{PropertyName} can not be empty");

            RuleFor(x => x.EndDate)
                .NotEmpty()
                .WithMessage("{PropertyName} can not be empty")
                .GreaterThan(x => x.StartDate)
                .WithMessage("{PropertyName} must be greater than {ComparsionValue}")
                .When(x => x.StartDate != default);

            RuleFor(x => x.LeaveTypeId)
                .NotEmpty()
                .WithMessage("{PropertyName} can not be empty")
                .MustAsync(async (id, token) =>
                {
                    var leaveTypeExists = await this.leaveRequestRepository.Exists(id);
                    return !leaveTypeExists;
                });
        }
    }
}