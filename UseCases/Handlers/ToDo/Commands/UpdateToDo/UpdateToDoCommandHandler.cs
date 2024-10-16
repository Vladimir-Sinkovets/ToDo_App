using Infrastructure.Interfaces.DataAccess;
using MediatR;
using UseCases.Exceptions;
using UseCases.Extensions;

namespace UseCases.Handlers.ToDo.Commands.UpdateToDo
{
    public class UpdateToDoCommandHandler : IRequestHandler<UpdateToDoCommand>
    {
        private readonly IDbContext _dbContext;

        public UpdateToDoCommandHandler(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Handle(UpdateToDoCommand request, CancellationToken cancellationToken)
        {
            var toDoEntry = _dbContext.ToDos.FirstOrDefault(t => t.Id == request.ToDoId);

            if (toDoEntry == null)
                throw new ToDoNotFoundException($"ToDo with id = {request.ToDoId} does not exist");

            toDoEntry.Title = request.Title;

            await _dbContext.SaveChangesAsync();
        }
    }
}
