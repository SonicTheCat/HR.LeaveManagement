using AutoMapper;
using HR.LeaveManagement.Application.DTOs.LeaveRequest.Validators.CommonValidations;
using HR.LeaveManagement.Application.Features.LeaveRequest.Requests.Commands;
using HR.LeaveManagement.Application.Persistence.Contracts;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveRequest.Handlers.Commands
{
    public class UpdateLeaveRequestCommandHandler : IRequestHandler<UpdateLeaveRequestCommand, Unit>
    {
        private readonly IMapper mapper;
        private readonly ILeaveRequestRepository leaveRequestRepository;

        public UpdateLeaveRequestCommandHandler(IMapper mapper, ILeaveRequestRepository leaveRequestRepository)
        {
            this.mapper = mapper;
            this.leaveRequestRepository = leaveRequestRepository;
        }

        public async Task<Unit> Handle(UpdateLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            if (request.LeaveRequestDto == null)
            {
                throw new Exception();
            }

            var validator = new LeaveRequestCommonDtoValidator(this.leaveRequestRepository);
            var validationResult = await validator.ValidateAsync(request.LeaveRequestDto, cancellationToken);
            if (validationResult.IsValid)
            {
                throw new Exception();
            }

            var leaveRequest = await this.leaveRequestRepository.Get(request.LeaveRequestDto.Id);

            if (leaveRequest == null)
            {
                throw new Exception();
            }

            this.mapper.Map(request.LeaveRequestDto, leaveRequest);

            await this.leaveRequestRepository.Update(leaveRequest);

            return Unit.Value;
        }
    }
}