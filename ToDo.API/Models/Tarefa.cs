using System;

namespace ToDo.API.Models
{
    public class Tarefa 
    {
        public Tarefa(string title, string description)
        {
            _Id = Guid.NewGuid().ToString();
            Title = title;
            Description = description;
        }

        public string _Id { get; private set; }
      
        public string Title { get; private set; }

        public string Description { get; private set; }

    }
}
