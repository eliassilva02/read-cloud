using Microsoft.AspNetCore.Mvc;
using read_cloud.DTOs;
using System.Diagnostics;

namespace read_cloud.Extensions;

public static class ControllerResponses
{
    public static BadRequestObjectResult BadRequest(List<string> _params)
    {
        var problem = new ErrorResponse
        {
            Type = "https://datatracker.ietf.org/doc/html/rfc9110#section-15",
            Title = "BadRequest",
            Status = 400,
            Errors = new ErrorsDetails(_params, null),
            TraceId = Activity.Current?.Id
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
