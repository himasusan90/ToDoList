using Domain.ToDos;
using Domain.ValueObjects;

namespace Api.Todos.Models;

public class TodoInputModel
{
    public string Title { get; init; } = default!;
    public string Body { get; init; } = default!;

    public DateTime DueDate { get; init; }
}
