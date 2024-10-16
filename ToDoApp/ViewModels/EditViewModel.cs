using System.ComponentModel.DataAnnotations;

namespace ToDoApp.ViewModels
{
    public class EditViewModel
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string RedirectUrl { get; set; }
    }
}
