using ToDoList.Domain.Entities;
using ToDoList.Domain.Repositories;

namespace ToDoList.Application.Services;

public class TarefaService
{
    private readonly ITarefaRepository _tarefaRepository;

    public TarefaService(ITarefaRepository tarefaRepository)
    {
        _tarefaRepository = tarefaRepository;
    }

    public async Task<IEnumerable<Tarefa>> ObterTodasAsync()
    {
        return await _tarefaRepository.ObterTodasAsync();
    }

    public async Task<Tarefa?> ObterPorIdAsync(int id)
    {
        return await _tarefaRepository.ObterPorIdAsync(id);
    }

    public async Task AdicionarAsync(Tarefa tarefa)
    {
        await _tarefaRepository.AdicionarAsync(tarefa);
    }

    public async Task AtualizarAsync(Tarefa tarefa)
    {
        await _tarefaRepository.AtualizarAsync(tarefa);
    }

    public async Task ExcluirAsync(int id)
    {
        await _tarefaRepository.ExcluirAsync(id);
    }
}