﻿using Domain.ToDos.Commands.Abstractions;
using Domain.ToDos.Repositories;
using Domain.ValueObjects;
using MediatR;

namespace Domain.ToDos.Commands
{
    public sealed record TodoCreateCommand(TodoId AggregateId, string Title, string Body, DateTime DueDate) : BaseTodoCommand(AggregateId)
    {
        public override async Task<Todo> VisitAsync(Todo aggregate, CancellationToken cancellationToken)
        {
            return await aggregate.WithAsync(this, cancellationToken);
        }
    }

    sealed file class Handler : BaseTodoCommandHandler<TodoCreateCommand>
    {
        public Handler(IMediator mediator, ITodoRepository repository) : base(mediator, repository)
        {
        }

        protected override Task<Todo> GetAggregateAsync(TodoCreateCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new Todo());
        }
    }
}