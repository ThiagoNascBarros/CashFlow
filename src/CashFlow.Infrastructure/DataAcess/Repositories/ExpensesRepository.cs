using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories.Expenses;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace CashFlow.Infrastructure.DataAcess.Repositories
{
    internal class ExpensesRepository : IExpensesRepository
    {
        private readonly CashFlowDbContext _context;

        public ExpensesRepository(CashFlowDbContext _context)
        {
            this._context = _context;
        }

        public async Task Add(Expense expense)
        {
            await _context.Expenses.AddAsync(expense);
        }

        public async Task<List<Expense>> GetAll()
        {
            return await _context.Expenses.ToListAsync();
        }

        public async Task<Expense> GetById(int id)
        {
            return await _context.Expenses.FindAsync(id);
        }
    }
}
