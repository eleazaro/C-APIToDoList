using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoList.Domain.Entities;

namespace ToDoList.Infrastructure.Data.Configuration
{
    public class TarefaConfiguration : IEntityTypeConfiguration<Tarefa>
    {
        public void Configure(EntityTypeBuilder<Tarefa> builder)
        {
            builder.Property(t => t.Titulo)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(t => t.CriadoEm)
                .HasDefaultValueSql("GETUTCDATE()");
        }
    }
}
