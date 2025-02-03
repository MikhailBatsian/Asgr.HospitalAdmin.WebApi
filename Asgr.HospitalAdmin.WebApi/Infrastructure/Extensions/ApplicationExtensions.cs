using Asgr.HospitalAdmin.Persistence;
using Asgr.HospitalAdmin.WebApi.Middlewares;
using Microsoft.EntityFrameworkCore;

namespace Asgr.HospitalAdmin.WebApi.Infrastructure.Extensions;

internal static class ApplicationExtensions
{
    internal static void AddSwagger(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddEndpointsApiExplorer();
        serviceCollection.AddSwaggerGen();
    }

    internal static void UseSwaggerApi(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    internal static void UseExceptionHandler(this WebApplication app)
    {
        app.UseMiddleware<ExceptionMiddleware>();
    }

    internal static void AddDbContext(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<HospitalAdminDbContext>(options =>
        {
            var connectionString = builder.Configuration.GetConnectionString("Database");
            options.UseNpgsql(connectionString);
        });
    }
}