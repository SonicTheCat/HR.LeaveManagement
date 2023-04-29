using HR.LeaveManagement.Application.DTOs.Common;
using HR.LeaveManagement.Application.DTOs.LeaveType.Validators.CommonValidations;

namespace HR.LeaveManagement.Application.DTOs.LeaveType
{
    public class LeaveTypeDto : BaseDto, ILeaveTypeDtoValidation
    {
        public string? Name { get; set; }
        public int DefaultDays { get; set; }
    }
}