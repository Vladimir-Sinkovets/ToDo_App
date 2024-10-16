using MediatR;

namespace UseCases.Handlers.ToDo.Commands.DeleteToDo
{
    public class DeleteToDoCommand : IRequest
    {
        public Guid ToDoId { get; set; }
    }
}
