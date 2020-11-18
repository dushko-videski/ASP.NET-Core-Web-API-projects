using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimplifiedCollageSystem.Models;
using SimplifiedCollageSystem.Services.Exceptions;
using SimplifiedCollageSystem.Services.Interfaces;
using System;

namespace SimplifiedCollageSystem.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentControler : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentControler(IStudentService studentService)
        {
            _studentService = studentService;
        }


        /// <summary>
        /// adds new student
        /// </summary>
        /// <param name="studentModel"></param>
        /// <returns></returns>
        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Reegister([FromBody] StudentModel studentModel)
        {
            try
            {
                _studentService.RegisterStudent(studentModel);
                return Ok("Successfully registered user!");
            }
            catch (StudentException ex)
            {
                return BadRequest($"Student exception: {ex.Message}");
            }
            catch (Exception ex)
            {
                return BadRequest($"Something went wrong: {ex.Message}");
            }

        }











    }
}
