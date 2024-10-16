using System.ComponentModel.DataAnnotations;

namespace ToDoApp.ViewModels
{
    public class AddViewModel
    {
        [Required]
        public string Title { get; set; }
    }
}
