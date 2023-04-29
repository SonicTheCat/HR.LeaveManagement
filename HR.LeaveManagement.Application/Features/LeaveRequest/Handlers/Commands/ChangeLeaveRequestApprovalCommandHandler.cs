using AutoMapper;
using HR.LeaveManagement.Application.Features.LeaveRequest.Requests.Commands;
using HR.LeaveManagement.Application.Persistence.Contracts;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveRequest.Handlers.Commands
{
    public class ChangeLeaveRequestApprovalCommandHandler : IRequestHandler<ChangeLeaveRequestApprovalCommand, Unit>
    {
        private readonly ILeaveRequestRepository leaveRequestRepository;

        public ChangeLeaveRequestApprovalCommandHandler(ILeaveRequestRepository leaveRequestRepository)
        {
            this.leaveRequestRepository = leaveRequestRepository;
        }

        public async Task<Unit> Handle(ChangeLeaveRequestApprovalCommand request, CancellationToken cancellationToken)
        {
            if (request.LeaveRequestDto == null)
            {
                throw new Exception();
            }

            var leaveRequest = await leaveRequestRepository.Get(request.LeaveRequestDto.Id);

            if (leaveRequest == null)
            {
                throw new Exception();
            }

            if (leaveRequest.Approved != request.LeaveRequestDto.Approved)
            {
                leaveRequest.Approved = request.LeaveRequestDto.Approved;
                await this.leaveRequestRepository.Update(leaveRequest);
            }

            return Unit.Value;
        }
    }
}