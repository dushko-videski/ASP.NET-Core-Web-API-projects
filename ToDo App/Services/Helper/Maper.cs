using DomainModels;
using Services.Interfaces;
using System.Collections.Generic;

namespace Services.Helper
{
    public static class Maper
    {


        public static ToDo MapToDo(ToDoDto toDoDto)
        {
            ToDo toDo = new ToDo()
            {
                Id = toDoDto.Id,
                TaskName = toDoDto.TaskName,
                TaskDescription = toDoDto.TaskDescription,
                IsCompleted = (bool)toDoDto.IsCompleted,
                UserId = toDoDto.UserId
            };

            List<SubTask> listOfSubTask = new List<SubTask>();

            foreach (SubTaskDto subTaskDto in toDoDto.SubTasks)
            {
                SubTask subTask = new SubTask()
                {
                    Id = subTaskDto.Id,
                    SubTaskName = subTaskDto.SubTaskName,
                    IsCompleted = (bool)subTaskDto.IsCompleted,
                    ToDoId = subTaskDto.ToDoId
                };
                listOfSubTask.Add(subTask);
            }
            toDo.SubTasks = listOfSubTask;

            return toDo;

        }


        public static SubTask MapSubTask(SubTaskDto subTaskDto)
        {
            return new SubTask()
            {
                Id = subTaskDto.Id,
                SubTaskName = subTaskDto.SubTaskName,
                IsCompleted = (bool)subTaskDto.IsCompleted,
                ToDoId = subTaskDto.ToDoId
            };
        }


        public static SubTaskDto MapSubTaskDto(SubTask subTask)
        {
            return new SubTaskDto()
            {
                Id = subTask.Id,
                SubTaskName = subTask.SubTaskName,
                IsCompleted = subTask.IsCompleted,
                ToDoId = subTask.ToDoId
            };
        }

    }
}
