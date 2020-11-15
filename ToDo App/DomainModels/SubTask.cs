namespace DomainModels
{
    public class SubTask
    {
        public int Id { get; set; }
        public string SubTaskName { get; set; }
        public bool IsCompleted { get; set; }

        public int ToDoId { get; set; }
        public ToDo ToDo { get; set; }


    }
}