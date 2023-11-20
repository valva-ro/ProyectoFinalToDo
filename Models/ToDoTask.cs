using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProyectoFinalToDo.Models
{
    public class ToDoTask
    {
        [Key]
        public int Id { get; set; }
        public User User { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public bool HasPomodoro { get; set; }
        public int PomodoroCount { get; set; }
    }
}
