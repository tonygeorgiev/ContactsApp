using Contacts.Application.Repositories;

namespace Contacts.Infrastructure.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _dbContext;
        private bool _disposed = false;

        public UnitOfWork(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task CommitAsync(Func<Task> action)
        {
            await using var transaction = await _dbContext.Database.BeginTransactionAsync();

            try
            {
                await action();
                await _dbContext.SaveChangesAsync();
                await transaction.CommitAsync();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public void Commit(Action action)
        {
            using var transaction = _dbContext.Database.BeginTransaction();

            try
            {
                action();
                _dbContext.SaveChanges();
                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }

                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}