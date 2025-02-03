using Microsoft.EntityFrameworkCore;
using FluentValidation;
using Asgr.HospitalAdmin.Application.Patients.Repositories;
using Asgr.HospitalAdmin.Application.Patients.Services;
using Asgr.HospitalAdmin.Application.Patients.Services.Interfaces;
using Asgr.HospitalAdmin.Persistence;
using Asgr.HospitalAdmin.Persistence.Repositories;
using Asgr.HospitalAdmin.WebApi.Infrastructure.Extensions;
using Asgr.HospitalAdmin.WebApi.Validators;

namespace Asgr.HospitalAdmin.WebApi;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        
        builder.AddDbContext();

        builder.Services.AddScoped<IPatientService, PatientService>();
        builder.Services.AddScoped<IPatientRepository, PatientRepository>();
            
        builder.Services.AddControllers();
        builder.Services.AddSwagger();
        builder.Services.AddValidatorsFromAssemblyContaining<PatientRequestModelValidator>();
        builder.Services.AddCors(options =>
        {
            options.AddDefaultPolicy(policy =>
            {
                policy.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            });
        });

        var app = builder.Build();

        app.UseExceptionHandler();
        app.UseCors();
        app.UseSwaggerApi();
        app.UseHttpsRedirection();
        app.MapControllers();

        ApplyNewMigrations(app);

        app.MapGet("/api", () => Results.Ok("API is running"));

        app.Run();
    }

    private static void ApplyNewMigrations(WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<HospitalAdminDbContext>();
        dbContext.Database.Migrate();
    }
}