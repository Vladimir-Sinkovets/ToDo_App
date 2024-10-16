using ToDoApp.Entities.Enums;
using UseCases.Enums;

namespace UseCases.Extensions
{
    public static class StatusEnumExtensions
    {
        public static ToDoStatus ConvertFromEntry(this Status status)
        {
            return status switch
            {
                Status.Active => ToDoStatus.Active,
                Status.Completed => ToDoStatus.Completed,
                _ => throw new NotImplementedException(),
            };
        }
        public static Status ConvertToEntry(this ToDoStatus status)
        {
            return status switch
            {
                ToDoStatus.Active => Status.Active,
                ToDoStatus.Completed => Status.Completed,
                _ => throw new NotImplementedException(),
            };
        }
    }
}
