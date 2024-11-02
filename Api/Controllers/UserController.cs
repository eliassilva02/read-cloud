using read_cloud.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Infra.Interfaces;
using read_cloud.Enums;
using System.Text.Json;
using Application.Services;
using read_cloud.Extensions;

namespace read_cloud.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController(ILogger<UserController> logger, IUnitOfWork unitOfWork) : ControllerBase
    {
        private readonly ILogger<UserController> _logger = logger;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        [HttpPost]
        public async Task<ActionResult> CreateUserAsync(
            [FromBody] UserRequestDTO user,
            [FromServices] UserService userService)
        {
            var _event = new EventId((int)ELogEvents.CreateUser, ELogEvents.CreateUser.ToString());
            try
            {
                _logger.LogInformation(_event, "Criando usuário {User}", user);
                _unitOfWork.BeginTransaction();

                var notifications = await userService.CreateUserAsync(new(user.Name, user.Email, user.Password, user.UserName, user.Phone, user.Cpf, new(user.Address.Cep, user.Address.Street, user.Address.Number, user.Address.City, user.Address.State, user.Address.Country, user.Address.Complement, user.Address.ReferencePoint), user.DateBirth, user.LevelUser));

                if (notifications.Count > 0)
                    return ControllerResponses.BadRequest(notifications);

                _unitOfWork.Commit();
                return Ok();
            }
            catch (Exception ex)
            {
                string? jsonStr = null;

                if (user != null)
                    jsonStr = JsonSerializer.Serialize(user);

                _logger.LogError(_event, ex, "{JsonStr}", jsonStr);
                _unitOfWork.Roolback();

                return Problem();
            }
        }

        [HttpDelete("{user_name}")]
        [Authorize]
        public async Task<ActionResult> DeleteUserAsync(string user_name)
        {
            return Ok();
        }

        [HttpPut("{user_name}")]
        [Authorize]
        public async Task<ActionResult> UpdateUserAsync(string user_name)
        {
            return Ok();
        }

        [HttpPost, Route("preferences")]
        [Authorize]
        public async Task<ActionResult> AddUserPreferencesAsync([FromBody] UserBookPreferences userPreferences)
        {

            return Ok();
        }
    }
}