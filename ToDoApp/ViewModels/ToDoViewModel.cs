using ToDoApp.Entities.Enums;

namespace ToDoApp.ViewModels
{
    public class ToDoViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateOnly Created { get; set; }
    }
}
