using MongoDB.Driver;
using ToDo.API.Data.Configurations;
using ToDo.API.Models;

namespace ToDo.API.Data.Repositories
{
    public class TarefasRepository : ITarefasRepository
    {
        private readonly IMongoCollection<Tarefa> _tarefas;

        public TarefasRepository(IDatabaseConfig databaseConfig)
        {
            var client = new MongoClient(databaseConfig.ConnectionString);
            var database = client.GetDatabase(databaseConfig.DatabaseName);

            _tarefas = database.GetCollection<Tarefa>("Exercices");
        }
        public void Add(Tarefa tarefa)
        {
           _tarefas.InsertOne(tarefa);

        }

        public Tarefa Del(string _id)
        {
            return _tarefas.Find(tarefa => tarefa._Id == _id).FirstOrDefault();
           
        }

        public IEnumerable<Tarefa> GetAll()
        {
            return _tarefas.Find(tarefa => true).ToList();
        }

        public void Remove(string _id)
        {
            _tarefas.DeleteOne(tarefa => tarefa._Id == _id);
        }
    }
}
