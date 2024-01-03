using Microsoft.AspNetCore.Mvc;
using ToDo.API.Data.Repositories;
using ToDo.API.Models;
using ToDo.API.Models.InputModels;


namespace ToDo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefasController : ControllerBase
    {

        private ITarefasRepository _tarefasRepository;

        public TarefasController(ITarefasRepository tarefasRepository)
        {
            _tarefasRepository = tarefasRepository;
        }

        // GET: api/Exercices
        [HttpGet]
        public IActionResult Get()
        {
           var responnse = _tarefasRepository.GetAll();

            return Ok(responnse);
        }


        // POST api/Exercices   
        [HttpPost]
        public IActionResult Post([FromBody] TarefaInputModel newTarefa)
        {
            var tarefa = new Tarefa(newTarefa.Title, newTarefa.Description);

            _tarefasRepository.Add(tarefa);

            return Created("", tarefa);
        }


        // DELETE api/Exercices/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(string _id)
        {
            var tarefa = _tarefasRepository.Del(_id);

            if(tarefa == null)
                return NotFound();

            _tarefasRepository.Remove(_id);

            return NoContent();
        }
    }
}
