using MediatR;
using UseCases.Handlers.ToDo.Queries.Dto;

namespace UseCases.Handlers.ToDo.Queries.GetToDoById
{
    public class GetToDoByIdCommand : IRequest<ToDoDto>
    {
        public Guid ToDoId { get; set; }
    }
}
