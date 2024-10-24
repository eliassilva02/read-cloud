using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace read_cloud.Extensions;

public static class ControllerResponses
{

    public static UnauthorizedObjectResult UnauthorizedException(string message)
    {
        var problem = new ProblemDetails
        {
            Type = "https://datatracker.ietf.org/doc/html/rfc9110#section-15",
            Title = "Unauthorized",
            Status = StatusCodes.Status401Unauthorized,
            Detail = message,
            Extensions =
            {
                ["traceId"] = Activity.Current?.Id
            }
        };

        return new UnauthorizedObjectResult(problem);
    }
}
