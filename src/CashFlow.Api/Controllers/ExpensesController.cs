using CashFlow.Application.UseCases.Expenses.Get;
using CashFlow.Application.UseCases.Expenses.Register;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using Microsoft.AspNetCore.Mvc;

namespace CashFlow.Api.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseRegisterExpensesJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErroJson), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Register(
            [FromServices] IRegisterExpenseUseCase useCase,
            [FromBody] RequestRegisterExpensesJson request)
        {
            var response = await useCase.Execute(request);

            return Created(string.Empty, response);
        }


        [HttpGet]
        [ProducesResponseType(typeof(ResponseExpensesJson), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetAllExpenses([FromServices] IGetAllExpensesUseCase useCase)
        {
            var response = await useCase.Execute();

            if (response.Expenses.Count != 0)
                return Ok(response);

            return NoContent();
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetExpense(
            [FromServices] IGetExpenseByIdUseCase useCase, 
            int id)
        {
            var response = await useCase.Execute(id);

            if (response == null) return NoContent();

            return Ok(response);
        }
    }
}