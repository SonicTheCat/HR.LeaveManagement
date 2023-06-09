﻿using HR.LeaveManagement.Application.DTOs.LeaveRequest;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveRequest.Requests.Commands
{
    public class UpdateLeaveRequestCommand : IRequest<Unit>
    {
        public UpdateLeaveRequestDto? LeaveRequestDto { get; set; }
    }
}