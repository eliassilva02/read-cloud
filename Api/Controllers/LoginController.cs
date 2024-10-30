using Application.Enums;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using read_cloud.DTOs;
using read_cloud.Extensions;

namespace read_cloud.Controllers
{
    [ApiController]
    [Route("api/login")]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        [Route("auth")]
        public async Task<ActionResult> AuthenticateAsync(
            [FromBody] LoginDTO login,
            [FromServices] IAuthService service
        )
        {
            try
            {
                var response = await service.LoginAsync(login.UserName, login.Password);

                return response.Result switch
                {
                    EAuthResponse.UserNotFound => NotFound(),
                    EAuthResponse.InvalidPassword => ControllerResponses.Unauthorized(response.Message),
                    _ => Ok(new AuthResponse(response.Message, response.Token)),
                };
            }
            catch (Exception ex)
            {
                return Problem(ex.Message);
            }
        }
    }
}
