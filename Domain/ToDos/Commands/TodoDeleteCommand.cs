using Domain.Abstractions;
using Domain.ToDos.Commands.Abstractions;
using Domain.ToDos.Repositories;
using Domain.ValueObjects;
using MediatR;

namespace Domain.ToDos.Commands
{

    public sealed record TodoDeleteCommand(TodoId AggregateId) : BaseTodoCommand(AggregateId)
    {
        public override async Task<Todo> VisitAsync(Todo aggregate, CancellationToken cancellationToken)
        {
            return await aggregate.WithAsync(this, cancellationToken);
        }
    }



    sealed file class Handler : BaseTodoUpdateCommandHandler<TodoDeleteCommand>
    {
        public Handler(IMediator mediator, ITodoRepository repository) : base(mediator, repository)
        {
        }
    }
}