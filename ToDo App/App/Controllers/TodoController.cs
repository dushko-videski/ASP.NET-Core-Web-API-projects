using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Interfaces;
using System;
using System.Collections.Generic;

namespace App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly IToDoService _toDoService;

        public TodoController(IToDoService toDoService)
        {
            _toDoService = toDoService;
        }

        [HttpPost("add-task")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult AddTask([FromBody] ToDoDto toDoDto)
        {
            try
            {
                _toDoService.AddTask(toDoDto);
                return Ok("Successfully added task");
            }
            catch (ToDoException ex)
            {
                return BadRequest($"ToDoDto Exception:{ex.Message}");
            }
            catch (Exception ex)
            {
                return BadRequest($"Something went wrong:{ex.Message}");
            }
        }
        /// <summary>
        /// adds sub task
        /// </summary>
        /// <param name="subTaskDto"></param>
        /// <returns></returns>
        [HttpPost("add-subtask")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult AddSubTask([FromBody] SubTaskDto subTaskDto)
        {
            try
            {
                _toDoService.AddSubTask(subTaskDto);
                return Ok("Successfully added sub-task");
            }
            catch (ToDoException ex)
            {
                return BadRequest($"ToDo Exception:{ex.Message}");
            }
            catch (Exception ex)
            {
                return BadRequest($"Something went wrong:{ex.Message}");
            }
        }
        [HttpDelete("{userId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult DeleteTask(int userId, [FromQuery] int taskId)
        {
            try
            {
                _toDoService.DeleteTask(userId, taskId);
                return Ok("Successfully deleted task!");
            }
            catch (ToDoException ex)
            {
                return BadRequest($"ToDo Exception:{ex.Message}");
            }
            catch (Exception ex)
            {
                return BadRequest($"Something went wrong:{ex.Message}");

            }
        }
        [HttpDelete("delete-subtask/{taskId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult DeleteSubTask(int taskId, [FromQuery] int subTaskId)
        {
            try
            {
                _toDoService.DeleteSubTask(taskId, subTaskId);
                return Ok("Successfully deleted sub-task!");
            }
            catch (ToDoException ex)
            {
                return BadRequest($"ToDo Exception:{ex.Message}");
            }
            catch (Exception ex)
            {
                return BadRequest($"Something went wrong:{ex.Message}");

            }
        }
        /// <summary>
        /// gets one task
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="taskId"></param>
        /// <returns></returns>
        [HttpGet("get/{userId}")]
        [ProducesResponseType(typeof(ToDoDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<ToDoDto> GetTask(int userId, [FromQuery] int taskId)
        {
            try
            {
                return Ok(_toDoService.GetTask(userId, taskId));
            }
            catch (ToDoException ex)
            {
                return BadRequest($"ToDo Exception:{ex.Message}");
            }
            catch (Exception ex)
            {
                return BadRequest($"Something went wrong:{ex.Message}");

            }
        }

        /// <summary>
        /// gets one sub task
        /// </summary>
        /// <param name="taskId"></param>
        /// <param name="subTaskId"></param>
        /// <returns></returns>
        [HttpGet("get-subtask/{taskId}")]
        [ProducesResponseType(typeof(SubTaskDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<SubTaskDto> GetSubTask(int taskId, [FromQuery] int subTaskId)
        {
            try
            {
                return Ok(_toDoService.GetSubTask(taskId, subTaskId));
            }
            catch (ToDoException ex)
            {
                return BadRequest($"ToDo Exception:{ex.Message}");
            }
            catch (Exception ex)
            {
                return BadRequest($"Something went wrong:{ex.Message}");

            }
        }
        /// <summary>
        /// gets all the tasks
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet("get-all-tasks")]
        [ProducesResponseType(typeof(IEnumerable<ToDoDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<IEnumerable<ToDoDto>> GetAllTasks([FromQuery] int userId)
        {
            try
            {
                return Ok(_toDoService.GetTasks(userId));
            }
            catch (ToDoException ex)
            {
                return BadRequest($"ToDo Exception:{ex.Message}");
            }
            catch (Exception ex)
            {
                return BadRequest($"Something went wrong:{ex.Message}");

            }
        }
        /// <summary>
        /// gets all the sub tasks
        /// </summary>
        /// <param name="taskId"></param>
        /// <returns></returns>
        [HttpGet("get-all-subtasks")]
        [ProducesResponseType(typeof(IEnumerable<SubTaskDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<IEnumerable<SubTaskDto>> GetAllSubTasks([FromQuery] int taskId)
        {
            try
            {
                return Ok(_toDoService.GetSubTasks(taskId));
            }
            catch (ToDoException ex)
            {
                return BadRequest($"ToDo Exception:{ex.Message}");
            }
            catch (Exception ex)
            {
                return BadRequest($"Something went wrong:{ex.Message}");

            }
        }

        /// <summary>
        /// updates only the task
        /// </summary>
        /// <param name="toDoDto"></param>
        /// <returns></returns>
        [HttpPut("update")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult UpdateTask([FromBody] ToDoDto toDoDto)
        {
            try
            {
                _toDoService.UpdateTask(toDoDto);
                return Ok($"Successfully updated task with id:{toDoDto.Id}");
            }
            catch (ToDoException ex)
            {
                return BadRequest($"ToDo Exception:{ex.Message}");
            }
            catch (Exception ex)
            {
                return BadRequest($"Something went wrong:{ex.Message}");

            }
        }

        /// <summary>
        /// updates only the sub task
        /// </summary>
        /// <param name="subTaskDto"></param>
        /// <returns></returns>
        [HttpPut("update-subtask")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult UpdateSubTask([FromBody] SubTaskDto subTaskDto)
        {
            try
            {
                _toDoService.UpdateSubTas(subTaskDto);
                return Ok($"Successfully updated sub-task with id:{subTaskDto.Id}");
            }
            catch (ToDoException ex)
            {
                return BadRequest($"ToDo Exception:{ex.Message}");
            }
            catch (Exception ex)
            {
                return BadRequest($"Something went wrong:{ex.Message}");

            }
        }











    }
}
