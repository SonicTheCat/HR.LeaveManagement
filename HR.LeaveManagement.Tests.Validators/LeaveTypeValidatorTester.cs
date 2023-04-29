using FluentValidation;
using FluentValidation.TestHelper;
using HR.LeaveManagement.Application.DTOs.LeaveType;
using HR.LeaveManagement.Application.DTOs.LeaveType.Validators;

namespace HR.LeaveManagement.Tests.Validators
{
    [TestFixture]
    public class LeaveTypeValidatorTester
    {
        private CreateLeaveTypeDtoValidator validator;

        [SetUp]
        public void Setup()
        {
            this.validator = new CreateLeaveTypeDtoValidator();
        }

        [Test]
        public void Shoud_have_error_when_Name_is_null()
        {
            // Arrange
            var model = new CreateLeaveTypeDto();

            // Act
            var result = validator.TestValidate(model);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Name);
        }

        [Test]
        public void Should_have_error_with_specific_message_when_Name_is_null()
        {
            // Arrange
            var model = new CreateLeaveTypeDto();

            // Act
            var result = validator.TestValidate(model);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Name)
                .WithErrorMessage("Name is required.")
                .WithSeverity(Severity.Error)
                .WithErrorCode("NotNullValidator"); ;
        }

        [Test]
        public void Should_have_error_when_Name_is_empty()
        {
            // Arrange
            var model = new CreateLeaveTypeDto() { Name = string.Empty };

            // Act
            var result = validator.TestValidate(model);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Name);
        }

        [TestCase(51)]
        [TestCase(100)]
        public void Should_have_error_when_Name_is_over_max_lenght(int count)
        {
            // Arrange
            var model = new CreateLeaveTypeDto() { Name = new string('a', count) };

            // Act
            var result = validator.TestValidate(model);

            // Assert
            result.ShouldHaveValidationErrorFor(x => x.Name);
        }

        [Test]
        public void Should_not_have_error_when_Name_is_provided()
        {
            // Arrange
            var model = new CreateLeaveTypeDto() { Name = "Tester" };

            // Act
            var result = validator.TestValidate(model);

            // Assert
            result.ShouldNotHaveValidationErrorFor(x => x.Name);
        }
    }
}