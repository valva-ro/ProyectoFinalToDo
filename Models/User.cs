using System.ComponentModel.DataAnnotations;

namespace ProyectoFinalToDo.Models
{
    public class User
    {
        [Key]
        public int Id { get; }
        [Required(ErrorMessage = "First name is required")]
        [StringLength(50, ErrorMessage = "Error", MinimumLength = 3)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [StringLength(50, ErrorMessage = "Error", MinimumLength = 3)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [StringLength(50, ErrorMessage = "Error", MinimumLength = 3)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(50, ErrorMessage = "Error", MinimumLength = 3)]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Age is required")]
        [Range(12, 120)]
        public int Age { get; set; }
        public ICollection<ToDoTask> ToDoTasks { get; set; }
    }
}
