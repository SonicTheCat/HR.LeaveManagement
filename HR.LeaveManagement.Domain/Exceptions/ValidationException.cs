namespace HR.LeaveManagement.Domain.Exceptions
{
    public class ValidationException : ApplicationException
    {
        // TODO PI: Custom Error class can be created, which will store 
        // exception message, error code, severity and other things 
        // that seem logical for the app. 
        public ValidationException(List<string> validationExceptions)
        {
            foreach (var exception in validationExceptions)
            {
                this.Errors.Add(exception);
            }
        }

        public List<string> Errors { get; init; } = new List<string>();
    }
}
