﻿using Infrastructure.Interfaces.DataAccess;
using MediatR;
using ToDoApp.Entities.Enums;
using UseCases.Enums;
using UseCases.Extensions;

namespace UseCases.Handlers.ToDo.Queries.GetToDoCollectionByStatus
{
    public class GetToDoCollectionByStatusQueryHandler : IRequestHandler<GetToDoCollectionByStatusQuery, ToDoCollectionDto>
    {
        private readonly IDbContext _dbContext;

        public GetToDoCollectionByStatusQueryHandler(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<ToDoCollectionDto> Handle(GetToDoCollectionByStatusQuery request, CancellationToken cancellationToken)
        {
            var toDos = _dbContext.ToDos
                .Where(t => t.Status == Status.Completed)
                .Select(t => new ToDoDto()
                {
                    Id = t.Id,
                    Created = t.Created,
                    Title = t.Title,
                    Status = t.Status.ConvertFromEntry(),
                });

            var dtoCollection = new ToDoCollectionDto()
            {
                ToDos = toDos,
            };

            return Task.FromResult(dtoCollection);
        }
    }
}
