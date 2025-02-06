using Microsoft.AspNetCore.Mvc;
using ToDoList.Application.Services;
using ToDoList.Domain.Entities;

namespace ToDoList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefaController : ControllerBase
    {
        private readonly TarefaService _tarefaService;

        public TarefaController(TarefaService tarefaService)
        {
            _tarefaService = tarefaService;
        }

        // Obter todas as tarefas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tarefa>>> ObterTodasAsync()
        {
            var tarefas = await _tarefaService.ObterTodasAsync();
            return Ok(tarefas); // Retorna 200 com a lista de tarefas
        }

        // Obter tarefa por ID
        [HttpGet("{id}", Name = "ObterTarefaPorId")]
        public async Task<ActionResult<Tarefa>> ObterPorIdAsync(int id)
        {
            var tarefa = await _tarefaService.ObterPorIdAsync(id);
            if (tarefa == null)
            {
                return NotFound(); // Retorna 404 se não encontrar a tarefa
            }
            return Ok(tarefa); // Retorna 200 com a tarefa encontrada
        }

        // Adicionar uma nova tarefa
        [HttpPost]
        public async Task<ActionResult> AdicionarAsync([FromBody] Tarefa tarefa)
        {
            if (tarefa == null)
            {
                return BadRequest(); // Retorna 400 se o corpo da requisição for inválido
            }

            await _tarefaService.AdicionarAsync(tarefa);

            // Verifica se o ID foi atribuído corretamente
            if (tarefa.Id == 0)
            {
                return StatusCode(500, "Erro ao atribuir o ID da tarefa.");
            }

            // Após salvar, o ID já deve estar atribuído no objeto `tarefa`
            return CreatedAtRoute("ObterTarefaPorId", new { id = tarefa.Id }, tarefa);

        }

        // Atualizar uma tarefa
        [HttpPut("{id}")]
        public async Task<ActionResult> AtualizarAsync(int id, [FromBody] Tarefa tarefa)
        {
            if (tarefa == null || tarefa.Id != id)
            {
                return BadRequest(); // Retorna 400 se os dados estiverem inconsistentes
            }

            // Atualiza a tarefa
            await _tarefaService.AtualizarAsync(tarefa);

            return NoContent(); // Retorna 204 se a atualização for bem-sucedida
        }

        // Excluir uma tarefa
        [HttpDelete("{id}")]
        public async Task<ActionResult> ExcluirAsync(int id)
        {
            var tarefa = await _tarefaService.ObterPorIdAsync(id);
            if (tarefa == null)
            {
                return NotFound(); // Retorna 404 se não encontrar a tarefa
            }

            // Exclui a tarefa
            await _tarefaService.ExcluirAsync(id);

            return NoContent(); // Retorna 204 para indicar que a exclusão foi bem-sucedida
        }
    }
}
