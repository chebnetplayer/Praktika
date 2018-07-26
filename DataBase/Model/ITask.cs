namespace Queuservice.DataBase.Model
{
    public interface ITask
    {
       string Name { get; }
       string Description { get;}
       bool IsDone { get; set; }
    }
}
