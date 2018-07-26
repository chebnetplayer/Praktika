using Queuservice.DataBase.Model;

namespace Queueservice.Model
{
    public class Walking : ITask
    {
        public Walking(string name,string description, bool isDone)
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
