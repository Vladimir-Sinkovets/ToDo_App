using MediatR;
using UseCases.Handlers.ToDo.Queries.Dto;

namespace UseCases.Handlers.ToDo.Queries.GetToDoById
{
    public class GetToDoByIdQuery : IRequest<ToDoDto>
    {
        public Guid ToDoId { get; set; }
    }
}
