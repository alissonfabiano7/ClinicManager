using ClinicManager.Application;
using ClinicManager.Domain.Interfaces;
using ClinicManager.Infrastructure.Data;
using ClinicManager.Infrastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using ClinicManager.Application.Patients.Commands.CreatePatient;
using ClinicManager.Application.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseInMemoryDatabase("ClinicManagerDb"));

builder.Services.AddScoped<IPatientRepository, PatientRepository>();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(ApplicationAssemblyReference).Assembly);
});

builder.Services.AddAutoMapper(typeof(ApplicationAssemblyReference).Assembly);

builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));



builder.Services.AddTransient<IValidator<CreatePatientCommand>, CreatePatientValidator>();



var app = builder.Build();

DbSeeder.Seed(app.Services);

app.UseExceptionHandler(errorApp =>
{
    errorApp.Run(async context =>
    {
        var exception = context.Features.Get<IExceptionHandlerFeature>()?.Error;

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = exception is NotFoundException
            ? StatusCodes.Status404NotFound
            : StatusCodes.Status500InternalServerError;

        var response = new { error = exception?.Message };
        await context.Response.WriteAsync(JsonSerializer.Serialize(response));
    });
});

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();