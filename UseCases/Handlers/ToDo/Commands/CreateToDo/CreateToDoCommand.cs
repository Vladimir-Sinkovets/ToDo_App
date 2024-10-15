using MediatR;

namespace UseCases.Handlers.ToDo.Commands.CreateToDo
{
    public class CreateToDoCommand : IRequest
    {
        public string Title {  get; set; }
    }
}
