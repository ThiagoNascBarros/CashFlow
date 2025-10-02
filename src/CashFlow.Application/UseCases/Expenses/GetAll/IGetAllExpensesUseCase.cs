using CashFlow.Communication.Responses;

namespace CashFlow.Api.Controllers
{
    public interface IGetAllExpensesUseCase
    {
        Task<ResponseExpensesJson> Execute();
    }
}