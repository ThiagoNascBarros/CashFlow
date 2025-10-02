using AutoMapper;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories;
using CashFlow.Domain.Repositories.Expenses;
using CashFlow.Exception.ExceptionsBase;

namespace CashFlow.Application.UseCases.Expenses.Register
{
    public class RegisterExpenseUseCase : IRegisterExpenseUseCase
    {
        private readonly IExpensesRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RegisterExpenseUseCase(IExpensesRepository repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ResponseRegisterExpensesJson> Execute(RequestRegisterExpensesJson request)
        {
            // To do Validations
            Validate(request);

            var entity = _mapper.Map<Expense>(request);

            // Esperando os metodos abaixo acabar para continuar com a function
            await _repository.Add(entity);
            await _unitOfWork.Commit();

            return _mapper.Map<ResponseRegisterExpensesJson>(entity);
        }

        private void Validate(RequestRegisterExpensesJson request)
        {
            var validator = new RegisterExpenseValidation();

            var result = validator.Validate(request);

            if (!result.IsValid)
            {
                var erroMessages = result.Errors.Select(f => f.ErrorMessage).ToList();

                throw new ErrorOnValidationException(erroMessages);
            }
        }
    }
}
