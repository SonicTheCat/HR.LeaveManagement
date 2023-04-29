using AutoMapper;
using HR.LeaveManagement.Application.Features.LeaveRequest.Requests.Commands;
using HR.LeaveManagement.Application.Persistence.Contracts;
using MediatR;
using HR.LeaveManagement.Application.DTOs.LeaveRequest.Validators;

namespace HR.LeaveManagement.Application.Features.LeaveRequest.Handlers.Commands
{
    public class CreateLeaveRequestCommandHandler : IRequestHandler<CreateLeaveRequestCommand, int>
    {
        private readonly IMapper mapper;
        private readonly ILeaveRequestRepository leaveRequestRepository;

        public CreateLeaveRequestCommandHandler(IMapper mapper, ILeaveRequestRepository leaveRequestRepository)
        {
            this.mapper = mapper;
            this.leaveRequestRepository = leaveRequestRepository;
        }

        public async Task<int> Handle(CreateLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            if (request.LeaveRequestDto == null)
            {
                throw new Exception();
            }

            var validator = new CreateLeaveRequestDtoValidator(this.leaveRequestRepository);
            var validationResult = await validator.ValidateAsync(request.LeaveRequestDto, cancellationToken);

            if (!validationResult.IsValid)
            {
                throw new Exception();
            }


            var leaveRequest = this.mapper.Map<Domain.LeaveRequest>(request.LeaveRequestDto);

            leaveRequest = await this.leaveRequestRepository.Add(leaveRequest);

            return leaveRequest.Id;
        }
    }
}