using Domain.Abstractions.Repositories;
using Domain.ValueObjects;

namespace Domain.ToDos.Repositories
{
    public interface ITodoRepository : IRepository<Todo, TodoId>
    {
    }
}