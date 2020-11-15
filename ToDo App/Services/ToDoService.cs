using DataAccess;
using DomainModels;
using Services.Helper;
using Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class ToDoService : IToDoService
    {
        private readonly IRepository<ToDo> _toDoRepository;
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<SubTask> _subTaskRepository;

        public ToDoService(IRepository<ToDo> toDoRepository, IRepository<User> userRepository, IRepository<SubTask> subTaskRepository)
        {
            _toDoRepository = toDoRepository;
            _userRepository = userRepository;
            _subTaskRepository = subTaskRepository;
        }


        public void AddTask(ToDoDto toDoDto)
        {
            User user = _userRepository.GetAll().FirstOrDefault(u => u.Id == toDoDto.UserId);


            if (user == null)
            {
                throw new ToDoException($"User with Id:{toDoDto.UserId} does not exist!");
            }

            if (string.IsNullOrWhiteSpace(toDoDto.TaskName) || toDoDto.IsCompleted == null)
            {
                throw new ToDoException($"Both TaskName and IsCompleted are required!");

            }

            ToDo toDo = Maper.MapToDo(toDoDto);

            _toDoRepository.Insert(toDo);

        }


        public void AddSubTask(SubTaskDto subTaskDto)
        {
            ToDo toDo = _toDoRepository.GetAll().FirstOrDefault(t => t.Id == subTaskDto.ToDoId);

            if (toDo == null)
            {
                throw new ToDoException($"Task with Id:{subTaskDto.ToDoId} does not exist!");
            }

            if (string.IsNullOrWhiteSpace(subTaskDto.SubTaskName) || subTaskDto.IsCompleted == null)
            {
                throw new ToDoException($"Both SubTaskName and IsCompleted are required!");
            }

            SubTask subTask = Maper.MapSubTask(subTaskDto);

            _subTaskRepository.Insert(subTask);

        }


        public void DeleteTask(int userId, int taskId)
        {

            ToDo task = _toDoRepository.GetAll().FirstOrDefault(t => t.Id == taskId && t.UserId == userId);

            if (task == null)
            {
                throw new ToDoException($"Task with Id:{taskId} deos not exist");
            }

            _toDoRepository.Remove(task);

        }


        public void DeleteSubTask(int taskId, int subTaskId)
        {
            SubTask subTask = _subTaskRepository.GetAll().FirstOrDefault(s => s.Id == subTaskId && s.ToDoId == taskId);

            if (subTask == null)
            {
                throw new ToDoException($"Subtask with Id:{subTaskId} deos not exist");
            }

            _subTaskRepository.Remove(subTask);

        }


        public ToDoDto GetTask(int userId, int taskId)
        {
            ToDo task = _toDoRepository.GetAll().FirstOrDefault(t => t.Id == taskId && t.UserId == userId);

            if (task == null)
            {
                throw new ToDoException($"Task with Id:{taskId} deos not exist");
            }

            ToDoDto toDoDto = new ToDoDto()
            {
                Id = task.Id,
                TaskName = task.TaskName,
                TaskDescription = task.TaskDescription,
                IsCompleted = task.IsCompleted,
                UserId = task.UserId,
                SubTasks = _subTaskRepository.GetAll()
                        .Where(s => s.ToDoId == task.Id)
                        .Select(s => new SubTaskDto()
                        {
                            Id = s.Id,
                            SubTaskName = s.SubTaskName,
                            IsCompleted = s.IsCompleted,
                            ToDoId = s.ToDoId
                        })
            };
            return toDoDto;
        }


        public SubTaskDto GetSubTask(int taskId, int subTaskId)
        {
            SubTask subTask = _subTaskRepository.GetAll().FirstOrDefault(s => s.Id == subTaskId && s.ToDoId == taskId);

            if (subTask == null)
            {
                throw new ToDoException($"Subtask with Id:{subTaskId} deos not exist");
            }

            return Maper.MapSubTaskDto(subTask);
        }


        public IEnumerable<ToDoDto> GetTasks(int userId)
        {

            return _toDoRepository.GetAll()
                .Where(t => t.UserId == userId)
                .Select(t => new ToDoDto()
                {
                    Id = t.Id,
                    TaskName = t.TaskName,
                    TaskDescription = t.TaskDescription,
                    IsCompleted = t.IsCompleted,
                    UserId = t.UserId,
                    SubTasks = _subTaskRepository.GetAll()
                        .Where(s => s.ToDoId == t.Id)
                        .Select(s => new SubTaskDto()
                        {
                            Id = s.Id,
                            SubTaskName = s.SubTaskName,
                            IsCompleted = s.IsCompleted,
                            ToDoId = s.ToDoId
                        })
                });
        }

        public IEnumerable<SubTaskDto> GetSubTasks(int taskId)
        {
            return _subTaskRepository.GetAll()
                .Where(s => s.ToDoId == taskId)
                .Select(s => new SubTaskDto()
                {
                    Id = s.Id,
                    SubTaskName = s.SubTaskName,
                    IsCompleted = s.IsCompleted,
                    ToDoId = s.ToDoId
                });
        }


        public void UpdateTask(ToDoDto toDoDto)
        {
            User user = _userRepository.GetAll().FirstOrDefault(u => u.Id == toDoDto.UserId);

            if (user == null)
            {
                throw new ToDoException($"User with Id: {toDoDto.UserId} does not exist!");
            }

            ToDo toDo = new ToDo()
            {
                Id = toDoDto.Id,
                TaskName = toDoDto.TaskName,
                TaskDescription = toDoDto.TaskDescription,
                IsCompleted = (bool)toDoDto.IsCompleted,
                UserId = toDoDto.UserId
            };

            _toDoRepository.Update(toDo);

        }

        public void UpdateSubTas(SubTaskDto subTaskDto)
        {
            ToDo toDo = _toDoRepository.GetAll().FirstOrDefault(t => t.Id == subTaskDto.ToDoId);

            if (toDo == null)
            {
                throw new ToDoException($"Task with Id:{subTaskDto.ToDoId} does not exist!");
            }

            SubTask subTask = Maper.MapSubTask(subTaskDto);

            _subTaskRepository.Update(subTask);

        }



    }
}
