using ToDoList.Domain.Entities;

namespace ToDoList.Domain.Repositories;

public interface ITarefaRepository
{
    Task<IEnumerable<Tarefa>> ObterTodasAsync();
    Task<Tarefa?> ObterPorIdAsync(int id);
    Task AdicionarAsync(Tarefa tarefa);
    Task AtualizarAsync(Tarefa tarefa);
    Task ExcluirAsync(int id);
}