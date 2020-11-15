using System.Collections.Generic;

namespace DomainModels
{
    public class ToDo
    {
        public int Id { get; set; }
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public bool IsCompleted { get; set; }


        public int UserId { get; set; } //FK
        public User User { get; set; }
        public IEnumerable<SubTask> SubTasks { get; set; }

    }
}