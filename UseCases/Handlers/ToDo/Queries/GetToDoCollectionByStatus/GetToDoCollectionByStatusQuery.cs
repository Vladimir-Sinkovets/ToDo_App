using MediatR;
using UseCases.Enums;

namespace UseCases.Handlers.ToDo.Queries.GetToDoCollectionByStatus
{
    public class GetToDoCollectionByStatusQuery : IRequest<ToDoCollectionDto>
    {
        public ToDoStatus Status { get; set; }
    }
}
