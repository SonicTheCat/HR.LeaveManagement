namespace HR.LeaveManagement.Application.DTOs.LeaveType.Validators.CommonValidations
{
    public interface ILeaveTypeDtoValidation
    {
        public string? Name { get; set; }

        public int DefaultDays { get; set; }
    }
}