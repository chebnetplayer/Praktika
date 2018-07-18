using Queuservice.Model;

namespace Queueservice.Model
{
    public class Walking : ITask
    {
        public Walking(string description, string where, bool isDone)
        {
            Description = description;
            Where = where;
            IsDone = isDone;
        }

        public string Description { get; }
        public string Where { get; }
        public bool IsDone { get; set; }

    }
}
