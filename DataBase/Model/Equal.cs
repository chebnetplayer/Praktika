using Queuservice.Model;

namespace Queueservice.Model
{
    public class Equal : ITask
    {
        public Equal(string description, string eq, bool isDone)
        {
            Description = description;
            Eq = eq;
            IsDone = isDone;
        }

        public string Description { get; }
        public string Eq { get; }
        public bool IsDone { get; set; }
    }
}
