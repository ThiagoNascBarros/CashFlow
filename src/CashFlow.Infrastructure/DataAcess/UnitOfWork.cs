using CashFlow.Domain.Repositories;

namespace CashFlow.Infrastructure.DataAcess
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly CashFlowDbContext _context;

        public UnitOfWork(CashFlowDbContext _context)
        {
            this._context = _context;
        }

        public async Task Commit() => await _context.SaveChangesAsync();

    }
}
