using Queuservice.DataBase.Model;

namespace Queueservice.DataBase.Model
{
    public class Equal : ITask
    {
        public Equal(string name, string description, bool isDone)
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
