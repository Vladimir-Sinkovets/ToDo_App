using MediatR;

namespace UseCases.Handlers.ToDo.Queries.GetToDoCollectionByStatus
{
    public class ToDoCollectionDto
    {
        public IEnumerable<ToDoDto> ToDos { get; set; }
    }
}
