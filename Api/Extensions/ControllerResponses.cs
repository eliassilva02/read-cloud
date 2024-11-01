using Flunt.Notifications;
using Microsoft.AspNetCore.Mvc;
using read_cloud.DTOs;

namespace read_cloud.Extensions;

public static class ControllerResponses
{
    public static BadRequestObjectResult BadRequest(List<Notification> notifications)
    {
        var messages = notifications.Select(s => s.Message).ToList();
        var keys = notifications.Select(z => z.Key).ToList();

        var problem = new ErrorResponse
        {
            Type = "https://datatracker.ietf.org/doc/html/rfc9110#section-15",
            Title = "BadRequest",
            Status = 400,
            Errors = new ErrorsDetails(messages, keys),
        };

        return new(problem);
    }

    public static UnauthorizedObjectResult Unauthorized(string message)
    {
        var problem = new ErrorResponse
        {
            Type = "https://datatracker.ietf.org/doc/html/rfc9110#section-15",
            Title = "Unauthorized",
            Status = StatusCodes.Status401Unauthorized,
            Errors = new ErrorsDetails([message], null)
        };

        return new(problem);
    }
}
