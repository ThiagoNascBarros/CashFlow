using CashFlow.Communication.Requests;
using FluentValidation;

namespace CashFlow.Application.UseCases.Expenses.Register
{
    public class RegisterExpenseValidation : AbstractValidator<RequestRegisterExpensesJson>
    {
        public RegisterExpenseValidation()
        {
            RuleFor(expenses => expenses.Title).NotEmpty().WithMessage("The title is required!");
            RuleFor(expenses => expenses.Amount).GreaterThan(0).WithMessage("The Amount must be greater than zero");
            RuleFor(expenses => expenses.Date).LessThanOrEqualTo(DateTime.UtcNow).WithMessage("Expanses cannot be for the future");
            RuleFor(expenses => expenses.PaymentType).IsInEnum().WithMessage("Payment Type is not valid.");
        }
    }
}
