using Api.Todos.Models;
using Api.ViewModels;
using Domain.ToDos.Commands;
using Domain.ToDos.Queries;
using Domain.ValueObjects;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ToDoController : Controller
    {

        private IMediator _mediator;
        public ToDoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ICollection<TodoViewModel>>> GetAllAsync(CancellationToken cancellationToken)
        {
            var command = new TodoGetAllQuery();

            var result = await _mediator.Send(command, cancellationToken);
            return result
                        .Select(todo => new TodoViewModel(todo))
                        .ToList();
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TodoViewModel>> GetById(TodoId id,CancellationToken cancellationToken)
        {
            var command = new TodoGetSingleQuery(id);

            var result = await _mediator.Send(command, cancellationToken);
            return result is not null
                ? new TodoViewModel(result)
                : NotFound();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<TodoViewModel>> PostAsync(TodoInputModel createModel, CancellationToken cancellationToken)
        {
            var command = new TodoCreateCommand(TodoId.New(), createModel.Title, createModel.Body, createModel.DueDate);

            var result = await _mediator.Send(command, cancellationToken);

            return new ObjectResult(new TodoViewModel(result))
            {
                StatusCode = 201
            };
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TodoViewModel>> UpdateAsync(TodoId id, TodoInputModel updateModel, CancellationToken cancellationToken)
        {
            var command = new TodoUpdateCommand(id, updateModel.Title, updateModel.Body, updateModel.DueDate);

            var result = await _mediator.Send(command, cancellationToken); // Will throw AggregateNotFoundException if Id does not exist, this should be converted into a 404 by Middleware
            return NoContent(); 
        }

        [HttpPatch("{id}/DueDate")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PatchDueDateAsync(TodoId id, TodoDueDateInputModel updateModel, CancellationToken cancellationToken)
        {
            var command = new TodoUpdateDueDateCommand(id, updateModel.DueDate);

            var result = await _mediator.Send(command, cancellationToken); 
            return NoContent(); 
        }

    }
}
