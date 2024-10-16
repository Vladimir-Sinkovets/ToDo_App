using Infrastructure.Interfaces.DataAccess;
using MediatR;
using UseCases.Exceptions;

namespace UseCases.Handlers.ToDo.Commands.DeleteToDo
{
    public class DeleteToDoCommandHandler : IRequestHandler<DeleteToDoCommand>
    {
        private readonly IDbContext _dbContext;

        public DeleteToDoCommandHandler(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Handle(DeleteToDoCommand request, CancellationToken cancellationToken)
        {
            var toDoEntry = _dbContext.ToDos.FirstOrDefault(t => t.Id == request.ToDoId);

            if (toDoEntry == null)
                throw new ToDoNotFoundException($"ToDo with id = {request.ToDoId} does not exist");

            _dbContext.ToDos.Remove(toDoEntry);

            await _dbContext.SaveChangesAsync();
        }
    }
}
