using DataBaseService.Data;
using DataBaseService.Logger;
using Microsoft.AspNetCore.Mvc;

namespace DataBaseService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ILoggerManager _logger;
        private readonly IAuthRepo _authRepo;

        public AuthController(ILoggerManager logger, IAuthRepo authRepo)
        {
            _logger = logger;
            _authRepo = authRepo;
        }


        [HttpPost]
        [ProducesResponseType(400)]
        [ProducesResponseType(200)]
        public IActionResult CreateUser(string username, string password)
        {
            try
            {
                _authRepo.CreateUser(username, password);
                _authRepo.SaveChanges();
                _logger.Write(NLog.LogLevel.Trace, $"{ToString()}.Create User: {username}");
                return Ok();
            }
            catch (Exception e)
            {
                _logger.Write(NLog.LogLevel.Trace, $"{ToString()}.CreateUser {username} {e.Message}");
                return BadRequest();
            }
        }

        [HttpPut]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult UpdatePassword(string username, string oldPassword, string newPassword)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(oldPassword) || string.IsNullOrEmpty(newPassword))
            {
                _logger.Write(NLog.LogLevel.Trace, $"{ToString()}.UpdatePassword \"{username}\" one of the string is empty");
                return BadRequest();
            }
            try
            {
                _authRepo.ChangePassword(username, oldPassword, newPassword);
                _authRepo.SaveChanges();

                _logger.Write(NLog.LogLevel.Trace, $"{ToString()}.UpdatePassword: {username}.");
                return Ok();
            }
            catch (Exception e)
            {

                _logger.Write(NLog.LogLevel.Warn, $"{ToString()}.UpdatePassword: {username}. {e.Message}");
                return BadRequest();
            }
        }

        [HttpGet("{name}:{pass}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult Auth(string name, string pass)
        {
            bool temp = _authRepo.Authentication(name, pass);

            _logger.Write(NLog.LogLevel.Trace, $"{ToString()}.Auth {name} {temp}");
            return temp ? Ok() : BadRequest();
        }

    }
}
