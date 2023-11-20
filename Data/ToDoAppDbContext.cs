
using Microsoft.EntityFrameworkCore;
using ProyectoFinalToDo.Models;

namespace ProyectoFinalToDo.Data
{
    public class ToDoAppDbContext : DbContext
    {
        public ToDoAppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
            .HasMany(u => u.ToDoTasks)
            .WithOne(t => t.User)
            .HasForeignKey(t => t.UserId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<User> ToDoTasks { get; set; }
        public DbSet<ProyectoFinalToDo.Models.ToDoTask>? ToDoTask { get; set; }
    }
}
