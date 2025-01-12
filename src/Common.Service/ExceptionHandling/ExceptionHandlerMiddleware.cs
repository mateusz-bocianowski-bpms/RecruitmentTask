using System.Net;
using System.Net.Mime;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;

using Common.Exceptions;
using Common.Domain;

namespace Common.Service.ExceptionHandling;

public class ExceptionHandlerMiddleware
{
    private const string ErrorMessage = "An unexpected error occurred.";

    private readonly RequestDelegate next;
    private readonly IHostEnvironment env;

    public ExceptionHandlerMiddleware(RequestDelegate next, IHostEnvironment env)
    {
        this.next = next;
        this.env = env;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await next(httpContext);
        }
        catch (Exception exception)
        {
            await HandleExceptionAsync(httpContext, exception);
        }
    }

    private async Task HandleExceptionAsync(HttpContext httpContext, Exception exception)
    {
        var response = httpContext.Response;
        response.ContentType = MediaTypeNames.Application.Json;

        response.StatusCode = exception switch
        {
            InvalidArgumentException => (int)HttpStatusCode.BadRequest,
            EntityNotFoundException => (int)HttpStatusCode.NotFound,
            _ => (int)HttpStatusCode.InternalServerError
        };

        var responseMessage = new ResponseMessage
        {
            Message = exception.Message,
            StackTrace = ShowStackTrace(response) ? exception.StackTrace : null
        };

        await response.WriteAsJsonAsync(responseMessage);
    }

    private bool ShowStackTrace(HttpResponse response)
    {
        return env.IsDevelopment() && (response.StatusCode == (int)HttpStatusCode.InternalServerError);
    }
}

public class ResponseMessage
{
    public string? Message { get; init; }
    public string? StackTrace { get; init; }
}