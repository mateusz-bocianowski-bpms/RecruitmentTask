using Microsoft.AspNetCore.Builder;

namespace Common.Service.ExceptionHandling;

public static class ApplicationBuilderExtensions
{
    public static IApplicationBuilder UseExceptionHandlerMiddleware(this IApplicationBuilder app)
        => app.UseMiddleware<ExceptionHandlerMiddleware>();
}