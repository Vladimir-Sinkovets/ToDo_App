namespace UseCases.Exceptions
{
    public class ToDoNotFoundException : Exception
    {
        public ToDoNotFoundException(string message) : base(message) { }
    }
}
