using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services;
using Services.Interfaces;
using System;

namespace App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        /// <summary>
        /// logs in existing user
        /// </summary>
        /// <param name="loginModel"></param>
        /// <returns></returns>
        [HttpPost("login")]
        [ProducesResponseType(typeof(UserModel), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<UserModel> Login([FromBody] LoginModel loginModel)
        {
            try
            {
                UserModel userModel = _userService.Login(loginModel.Username, loginModel.Password);
                return Ok(userModel);
            }
            catch (UserException ex)
            {
                return BadRequest($"User exception: {ex.Message}");
            }
            catch (Exception ex)
            {
                return BadRequest($"Something went wrong: {ex.Message}");
            }
        }

        /// <summary>
        /// registeres new user
        /// </summary>
        /// <param name="registerModel"></param>
        /// <returns></returns>
        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Register([FromBody] RegisterModel registerModel)
        {
            try
            {
                _userService.Register(registerModel);
                return Ok("Successfully registered user!");
            }
            catch (UserException ex)
            {
                return BadRequest($"User exception: {ex.Message}");
            }
            catch (Exception ex)
            {
                return BadRequest($"Something went wrong: {ex.Message}");
            }
        }


















    }
}
