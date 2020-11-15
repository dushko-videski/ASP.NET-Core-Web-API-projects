using System.Collections.Generic;

namespace Services.Interfaces
{
    public interface IToDoService
    {
        void AddTask(ToDoDto toDoDto);
        void AddSubTask(SubTaskDto subTaskDto);


        void DeleteTask(int userId, int taskId);
        void DeleteSubTask(int taskId, int subTaskId);


        ToDoDto GetTask(int userId, int taskId);
        SubTaskDto GetSubTask(int taskId, int subTaskId);


        IEnumerable<ToDoDto> GetTasks(int userId);
        IEnumerable<SubTaskDto> GetSubTasks(int taskId);


        void UpdateTask(ToDoDto toDoDto);
        void UpdateSubTas(SubTaskDto subTaskDto);


    }
}
