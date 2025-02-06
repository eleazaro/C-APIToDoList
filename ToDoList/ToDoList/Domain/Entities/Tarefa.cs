namespace ToDoList.Domain.Entities;

public class Tarefa
{
    public int Id { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public string? Descricao { get; set; }
    public DateTime CriadoEm { get; set; } = DateTime.UtcNow;
    public DateTime? ConcluidoEm { get; set; }
    public StatusTarefa Status { get; set; } = StatusTarefa.Pendente;
}

public enum StatusTarefa
{
    Pendente,
    EmProgresso,
    Concluida
}