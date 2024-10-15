using MediatR;

namespace UseCases.Handlers.ToDo.Queries.Dto
{
    public class ToDoCollectionDto
    {
        public IEnumerable<ToDoDto> ToDos { get; set; }
    }
}
