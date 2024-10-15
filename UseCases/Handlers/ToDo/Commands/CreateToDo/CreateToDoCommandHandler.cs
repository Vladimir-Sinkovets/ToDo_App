using Infrastructure.Interfaces.DataAccess;
using MediatR;
using ToDoApp.Entities.Enums;
using ToDoApp.Entities.Models;

namespace UseCases.Handlers.ToDo.Commands.CreateToDo
{
    public class CreateToDoCommandHandler : IRequestHandler<CreateToDoCommand>
    {
        private readonly IDbContext _dbContext;

        public CreateToDoCommandHandler(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Handle(CreateToDoCommand request, CancellationToken cancellationToken)
        {
            var todoEntry = new ToDoEntry()
            {
                Created = DateOnly.FromDateTime(DateTime.Now),
                Status = Status.Active,
                Title = request.Title,
            };

            _dbContext.ToDos.Add(todoEntry);

            await _dbContext.SaveChangesAsync();
        }
    }
}
