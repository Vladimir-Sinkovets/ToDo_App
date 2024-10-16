using MediatR;
using UseCases.Enums;
using UseCases.Handlers.ToDo.Queries.Dto;

namespace UseCases.Handlers.ToDo.Queries.GetToDoCollectionByStatus
{
    public class GetToDoCollectionByStatusQuery : IRequest<ToDoCollectionDto>
    {
        public ToDoStatus Status { get; set; }
    }
}
