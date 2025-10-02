using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;

namespace CashFlow.Application.UseCases.Expenses.Get
{
    public interface IGetExpenseByIdUseCase
    {
        Task<ResponseShortExpenseJson> Execute(int id);
    }
}
