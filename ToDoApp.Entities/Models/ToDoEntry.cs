using ToDoApp.Entities.Enums;

namespace ToDoApp.Entities.Models
{
    public class ToDoEntry
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateOnly Created { get; set; }
        public Status Status { get; set; }
    }
}
