using read_cloud.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace read_cloud.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController(ILogger<UserController> logger) : ControllerBase
    {
        private readonly ILogger<UserController> _logger = logger;

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> CreateUser([FromBody] UserRequest user)
        {
            
            return Ok();
        }

        [HttpDelete("{user_name}")]
        [Authorize]
        public async Task<ActionResult> DeleteUser(string user_name)
        {
            return Ok();
        }

        [HttpPut("{user_name}")]
        [Authorize]
        public async Task<ActionResult> UpdateUser(string user_name)
        {
            return Ok();
        }

        [HttpPost, Route("preferences")]
        [Authorize]
        public async Task<ActionResult> AddUserPreferences([FromBody] UserBookPreferences userPreferences)
        {

            return Ok();
        }
    }
}