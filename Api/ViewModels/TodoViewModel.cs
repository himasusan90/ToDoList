using Domain.ToDos;
using Domain.ValueObjects;

namespace Api.Todos.Models;

public class TodoViewModel
{
    public TodoId Id { get; }
    public string Title { get; }

    public string Body { get; }

    public DateTime DueDate { get; }

    public TodoViewModel(Todo todo) 
    {
        this.Id = todo.Id;
        this.Title = todo.Title;
        this.Body = todo.Body;
        this.DueDate = todo.DueDate;
    }
}
