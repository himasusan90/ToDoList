using Domain.ToDos;
using Domain.ToDos.Repositories;
using Domain.ValueObjects;
using System.Collections.Concurrent;

namespace Infrastructure
{
    internal sealed class TodoRepository : ITodoRepository
    {
        private readonly static IDictionary<TodoId, Todo> _data = new ConcurrentDictionary<TodoId, Todo>(); // We use a static dictionary to mimic an actual data store, like e.g. a SQL server

        public Task<IEnumerable<Todo>> GetAllAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult((IEnumerable<Todo>)_data.Values);
        }

        public Task<Todo?> GetAsync(TodoId id, CancellationToken cancellationToken)
        {
            if (_data.TryGetValue(id, out var result))
                return Task.FromResult((Todo?)result);

            return Task.FromResult((Todo?)null);
        }

        public Task PersistAggregateAsync(Todo aggregate, CancellationToken cancellationToken)
        {
            if (aggregate.Deleted)
                _data.Remove(aggregate.Id);
            else
                _data[aggregate.Id] = aggregate;
            return Task.CompletedTask;
        }
    }
}