using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFinalToDo.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(50, ErrorMessage = "Error", MinimumLength = 3)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "El apellido es obligatorio")]
        [StringLength(50, ErrorMessage = "Error", MinimumLength = 3)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "El mail es obligatorio")]
        [StringLength(50, ErrorMessage = "Error", MinimumLength = 3)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "La contraseña es obligatoria")]
        [StringLength(50, ErrorMessage = "Error", MinimumLength = 3)]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "La edad es obligatoria")]
        [Range(12, 120)]
        public int Age { get; set; }
        public ICollection<ToDoTask> ToDoTasks { get; set; } = new List<ToDoTask>();
    }
}
