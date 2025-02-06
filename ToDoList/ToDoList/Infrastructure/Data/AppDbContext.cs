using Microsoft.EntityFrameworkCore;
using ToDoList.Domain.Entities;
using ToDoList.Infrastructure.Data.Configuration;

namespace ToDoList.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Tarefa> Tarefas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Aplica todas as configurações de entidade encontradas no assembly
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TarefaConfiguration).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
