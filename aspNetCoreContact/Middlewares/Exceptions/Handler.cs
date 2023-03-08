using System.Net;
using System.Text.Json;
using aspNetCoreContact.Errors;
using aspNetCoreContact.Exception;

namespace aspNetCoreContact.Middlewares.Exceptions;

public class Handler : AbstractExceptionHandlerMiddleware
{
    public Handler(RequestDelegate next) : base(next)
    {
    }

    public override (HttpStatusCode code, string message) GetResponse(System.Exception exception)
    {
        HttpStatusCode code;
        switch (exception)
        {
            case StudentNotFoundException:
                code = HttpStatusCode.NotFound;
                break;
            default:
                code = HttpStatusCode.InternalServerError;
                break;
        }
        return (code, JsonSerializer.Serialize(new NotFound(exception.Message)));
    }
}