using MediatR;

namespace UseCases.Handlers.ToDo.Commands.CompleteToDo
{
    public class CompleteToDoCommand : IRequest
    {
        public Guid ToDoId { get; set; }
    }
}
