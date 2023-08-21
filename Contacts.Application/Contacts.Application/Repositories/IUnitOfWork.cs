namespace Contacts.Application.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        Task CommitAsync(Func<Task> action);
        void Commit(Action action);
    }
}
