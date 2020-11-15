namespace Services.Interfaces
{
    public class SubTaskDto
    {
        public int Id { get; set; }
        public string SubTaskName { get; set; }
        public bool? IsCompleted { get; set; }

        public int ToDoId { get; set; }
    }
}