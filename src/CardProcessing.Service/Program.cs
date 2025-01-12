using Common.Service.ExceptionHandling;

using CardProcessing.Domain;
using CardProcessing.Application.Contract;
using CardProcessing.Application;
using CardProcessing.Infrastructure;

namespace CardProcessing.Service;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        ConfigureServices(builder.Services);

        var app = builder.Build();
        
        ConfigurePipeline(app, app.Environment);

        app.MapControllers(); 

        app.Run();
    }

    private static void ConfigureServices(IServiceCollection services)
    {
        // Swagger
        services.AddSwaggerGen();
        
        // WebApi
        services.AddControllers();
        
        ConfigureLocalServices(services);
    }

    private static void ConfigureLocalServices(IServiceCollection services)
    {
        // Domain
        services.AddScoped<IRepository, MemoryRepository>();

        // Application
        services.AddScoped<ICardService, CardService>();
        services.AddScoped<ICardProcessingService, CardProcessingService>();
        services.AddScoped<IActionService, ActionService>();

        // Validation
        services.AddScoped(typeof(Common.Validation.IValidator<>), typeof(Common.Validation.FluentValidation.FluentValidator<>));
        services.AddScoped(typeof(FluentValidation.IValidator<CardProcessing.Service.Contract.AllowedCardActionsRequest>), 
            typeof(CardProcessing.Service.Validation.AllowedCardActionsRequestValidator));
    }

    private static void ConfigurePipeline(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseExceptionHandlerMiddleware();

        if (env.IsDevelopment())
        {
            // Swagger
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
    }
}