using System.Collections.Generic;

namespace Services.Interfaces
{
    public class ToDoDto
    {
        public int Id { get; set; }
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public bool? IsCompleted { get; set; }

        public int UserId { get; set; }
        public IEnumerable<SubTaskDto> SubTasks { get; set; }


    }
}