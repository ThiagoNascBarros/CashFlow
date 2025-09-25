﻿using CashFlow.Application.UseCases.Expenses.Register;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using CashFlow.Exception.ExceptionsBase;
using Microsoft.AspNetCore.Mvc;

namespace CashFlow.Api.Controllers

{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {
        [HttpPost]
        public IActionResult Register([FromBody] RequestRegisterExpensesJson request)
        {
            try
            {
                var useCase = new RegisterExpenseUseCase();

                var response = useCase.Execute(request);

                return Created(string.Empty, response);
            } 
            catch (ErrorOnValidationException e)
            {
                var erroResponse = new ResponseErroJson(e.Errors);
                return BadRequest(erroResponse);
            }
            catch
            {
                var erroResponse = new ResponseErroJson("unknown error");
                return StatusCode(StatusCodes.Status500InternalServerError, erroResponse);
            }
        }
    }
}
