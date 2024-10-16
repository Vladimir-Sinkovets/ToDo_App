using MediatR;
using UseCases.Enums;

namespace UseCases.Handlers.ToDo.Commands.UpdateToDo
{
    public class UpdateToDoCommand : IRequest
    {
        public Guid ToDoId { get; set; }
        public string Title { get; set; }
    }
}
