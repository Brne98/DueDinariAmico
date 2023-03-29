using System.Reflection;
using DueDinariAmico.Application.Interfaces;
using DueDinariAmico.Application.Queries;
using DueDinariAmico.Application.Services;
using DueDinariAmico.Infrastructure.HttpClients;
using DueDinariAmico.Infrastructure.Persistence.Context;
using DueDinariAmico.Infrastructure.Persistence.Repositories;
using DueDinariAmico.Infrastructure.Services;
using ExchangeRate.Infrastructure.BackgroundProcesses;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//TODO Dependency Injection
// Add MediatR
builder.Services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());

//Add Services
builder.Services.AddHttpClient<ExchangeRateHttpClient>("ExchangeRateHttpClient");
builder.Services.AddScoped(typeof(IExchangeRateRepository<>), typeof(ExchangeRateRepository<>));
builder.Services.AddScoped<IExchangeRateService, ExchangeRateService>();
builder.Services.AddScoped<IHttpClientService, HttpClientService>();
builder.Services.AddBackgroundProcesses();


builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"),
        sqlServerOptionsAction: sqlOptions =>
        {
            sqlOptions.EnableRetryOnFailure();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();