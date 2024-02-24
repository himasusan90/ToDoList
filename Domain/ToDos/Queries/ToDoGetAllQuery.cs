using Domain.Queries;
using Domain.ToDos.Repositories;

namespace Domain.ToDos.Queries
{
    public sealed record TodoGetAllQuery() : IQuery<IEnumerable<Todo>>;

    file sealed class Handler : BaseTodoQueryHandler<TodoGetAllQuery, IEnumerable<Todo>>
    {
        public Handler(ITodoRepository repository) : base(repository)
        {
        }

        public override async Task<IEnumerable<Todo>> Handle(TodoGetAllQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllAsync(cancellationToken);
        }
    }

}
