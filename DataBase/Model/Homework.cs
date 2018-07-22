using Queuservice.Model;

namespace Queueservice.Model
{
    public class Homework:ITask
    {
        public Homework(string description, string subject, bool isDone)
        {
            Description = description;
            Subject = subject;
            IsDone = isDone;
        }
        public string Description { get; }
        public string Subject { get; }
        public bool IsDone { get; set; }


    }
}
