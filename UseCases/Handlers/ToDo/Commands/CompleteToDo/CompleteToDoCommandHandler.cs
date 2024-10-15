using Infrastructure.Interfaces.DataAccess;
using MediatR;
using ToDoApp.Entities.Enums;
using UseCases.Exceptions;

namespace UseCases.Handlers.ToDo.Commands.CompleteToDo
{
    public class CompleteToDoCommandHandler : IRequestHandler<CompleteToDoCommand>
    {
        private readonly IDbContext _dbContext;

        public CompleteToDoCommandHandler(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Handle(CompleteToDoCommand request, CancellationToken cancellationToken)
        {
            var toDoEntry = _dbContext.ToDos.FirstOrDefault(t => t.Id == request.ToDoId);

            if (toDoEntry == null)
                throw new ToDoNotFoundException($"ToDo with id = {request.ToDoId} does not exist");

            toDoEntry.Status = Status.Completed;

            await _dbContext.SaveChangesAsync();
        }
    }
}
