using AutoMapper;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using CashFlow.Domain.Repositories.Expenses;

namespace CashFlow.Application.UseCases.Expenses.Get
{
    public class GetExpenseByIdUseCase : IGetExpenseByIdUseCase
    {
        private readonly IExpensesRepository _repository;
        private readonly IMapper _mapper;

        public GetExpenseByIdUseCase(IExpensesRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ResponseShortExpenseJson?> Execute(int id)
        {
            var result = await _repository.GetById(id);

            if (result == null) return null;

            return new ResponseShortExpenseJson
            {
                Id = result.Id,
                Title = result.Title,
                Amount = result.Amount,
            };
        }
    }
}
