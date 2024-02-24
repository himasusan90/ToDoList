using Domain.Abstractions;
using Domain.ToDos.Repositories;
using MediatR;

namespace Domain.ToDos.Commands.Abstractions
{
    internal class BaseTodoUpdateCommandHandler<T>
    {
        private IMediator mediator;
        private ITodoRepository repository;

        public BaseTodoUpdateCommandHandler(IMediator mediator, ITodoRepository repository)
        {
            this.mediator = mediator;
            this.repository = repository;
        }
    }
}