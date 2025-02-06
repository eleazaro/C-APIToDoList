using Microsoft.EntityFrameworkCore;
using ToDoList.Domain.Entities;
using ToDoList.Domain.Repositories;
using ToDoList.Infrastructure.Data;

namespace ToDoList.Infrastructure.Repositories;

public class TarefaRepository : ITarefaRepository
{
    private readonly AppDbContext _context;

    public TarefaRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Tarefa>> ObterTodasAsync()
    {
        return await _context.Tarefas.ToListAsync();
    }

    public async Task<Tarefa?> ObterPorIdAsync(int id)
    {
        return await _context.Tarefas.FindAsync(id);
    }

    public async Task AdicionarAsync(Tarefa tarefa)
    {
        _context.Tarefas.Add(tarefa);
        await _context.SaveChangesAsync();
    }

    public async Task AtualizarAsync(Tarefa tarefa)
    {
        _context.Tarefas.Update(tarefa);
        await _context.SaveChangesAsync();
    }

    public async Task ExcluirAsync(int id)
    {
        var tarefa = await _context.Tarefas.FindAsync(id);
        if (tarefa != null)
        {
            _context.Tarefas.Remove(tarefa);
            await _context.SaveChangesAsync();
        }
    }
}