using Infrastructure.Interfaces.DataAccess;
using MediatR;
using Microsoft.EntityFrameworkCore;
using UseCases.Exceptions;
using UseCases.Extensions;
using UseCases.Handlers.ToDo.Queries.Dto;

namespace UseCases.Handlers.ToDo.Queries.GetToDoById
{
    public class GetToDoByIdQueryHandler : IRequestHandler<GetToDoByIdQuery, ToDoDto>
    {
        private readonly IDbContext _dbContext;

        public GetToDoByIdQueryHandler(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ToDoDto> Handle(GetToDoByIdQuery request, CancellationToken cancellationToken)
        {
            var toDoEntry = await _dbContext.ToDos.FirstOrDefaultAsync(t => t.Id == request.ToDoId);

            if (toDoEntry == null)
                throw new ToDoNotFoundException($"ToDo with id = {request.ToDoId} does not exist");

            var dto = new ToDoDto()
            {
                Id = request.ToDoId,
                Created = toDoEntry.Created,
                Status = toDoEntry.Status.ConvertFromEntry(),
                Title = toDoEntry.Title,
            };

            return dto;
        }
    }
}
