﻿using HR.LeaveManagement.Application.DTOs.LeaveRequest.Validators.CommonValidations;

namespace HR.LeaveManagement.Application.DTOs.LeaveRequest
{
    public class CreateLeaveRequestDto : ILeaveRequestDtoValidation
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int LeaveTypeId { get; set; }

        public DateTime DateRequested { get; set; }

        public string RequestComments { get; set; } = string.Empty;
    }
}