namespace Queuservice.Model
{
    interface ITask
    {
       string Description { get;}
       bool IsDone { get; set; }
    }
}
