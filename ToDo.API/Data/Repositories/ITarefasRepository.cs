

using ToDo.API.Models;

namespace ToDo.API.Data.Repositories
{
    public interface ITarefasRepository
    {
        void Add(Tarefa tarefa);

        IEnumerable<Tarefa> GetAll();

        Tarefa Del(string _id);


        void Remove(string _id);
    }
}
