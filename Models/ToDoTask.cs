using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFinalToDo.Models
{
    public class ToDoTask
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; } = null;
        public string Description { get; set; }
        public bool IsCompleted { get; set; } = false;
        public bool HasPomodoro { get; set; } = false;
        public int PomodoroCount { get; set; } = 0;
    }
}
