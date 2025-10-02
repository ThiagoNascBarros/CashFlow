using CashFlow.Application.UseCases.Expenses.Register;
using CashFlow.Communication.Enums;
using CashFlow.Communication.Requests;
using CashFlow.Exception;
using CommonTestUtilities.Requests;
using FluentAssertions;

namespace Validators.Tests.Expanses.Register
{
    public class RegisterExpansesValidatorTests
    {
        [Fact]
        public void Sucess()
        {
            // Arrange 
            var validator = new RegisterExpenseValidation();
            var request = RequestRegisterExpensesJsonBuilder.Build();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.IsValid.Should().BeTrue();
        }

        [Theory]
        [InlineData("")]
        [InlineData("     ")]
        [InlineData(null)]
        public void Error_Title_Empty(string title) 
        {
            // Arrange 
            var validator = new RegisterExpenseValidation();
            var request = RequestRegisterExpensesJsonBuilder.Build();
            request.Title = title;

            // Act
            var result = validator.Validate(request);

            // Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals(ResourceErrorMessages.TITLE_REQUIRED));
        }

        [Fact]
        public void Error_Date_Future()
        {
            var validator = new RegisterExpenseValidation();
            var request = RequestRegisterExpensesJsonBuilder.Build();
            request.Date = DateTime.Now.AddDays(3);
            var result = validator.Validate(request);
            result.IsValid.Should().BeFalse();
            result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals(ResourceErrorMessages.EXPENSES_CANNOT_FOR_THE_FUTURE));
        }

        [Fact]
        public void Error_PaymentType_IsValid()
        {
            var validator = new RegisterExpenseValidation();
            var request = RequestRegisterExpensesJsonBuilder.Build();
            request.PaymentType = (PaymentType)900;
            var result = validator.Validate(request);
            result.IsValid.Should().BeFalse();
            result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals(ResourceErrorMessages.PAYMENT_TYPE_INVALID));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-7)]
        [InlineData(-10)]
        [InlineData(-1910)]
        public void Error_Amount_Invalid(decimal amount)
        {
            var validator = new RegisterExpenseValidation();
            var request = RequestRegisterExpensesJsonBuilder.Build();
            request.Amount = amount;
            var result = validator.Validate(request);
            result.IsValid.Should().BeFalse();
            result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage.Equals(ResourceErrorMessages.AMOUNT_MUST_BE_GREATER_THAN_ZERO));
        }
    }
}
