using Domain.Queries;
using Domain.ToDos.Repositories;
using Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ToDos.Queries
{
   
    public sealed record TodoGetSingleQuery(TodoId AggregateId) : IQuery<Todo?>;

    file sealed class Handler : BaseTodoQueryHandler<TodoGetSingleQuery, Todo?>
    {
        public Handler(ITodoRepository repository) : base(repository)
        {
        }

        public override async Task<Todo?> Handle(TodoGetSingleQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAsync(request.AggregateId,cancellationToken);
        }
    }
}
