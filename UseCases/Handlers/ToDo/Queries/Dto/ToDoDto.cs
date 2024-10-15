using UseCases.Enums;

namespace UseCases.Handlers.ToDo.Queries.Dto
{
    public class ToDoDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateOnly Created { get; set; }
        public ToDoStatus Status { get; set; }
    }
}