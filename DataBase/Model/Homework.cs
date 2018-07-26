using Queuservice.DataBase.Model;

namespace Queueservice.Model
{
    public class Homework:ITask
    {
        public Homework(string name, string description, bool isDone)
        {
            Description = description;
            IsDone = isDone;
            Name = name;
        }
        public string Description { get; }
        public bool IsDone { get; set; }

        public string Name { get; }
    }
}
