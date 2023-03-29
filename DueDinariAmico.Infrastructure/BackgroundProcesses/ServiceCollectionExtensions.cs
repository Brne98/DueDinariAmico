using DueDinariAmico.Infrastructure.BackgroundProcesses;
using Microsoft.Extensions.DependencyInjection;
using Quartz;

namespace ExchangeRate.Infrastructure.BackgroundProcesses;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddBackgroundProcesses(this IServiceCollection services)
    {
        services.AddQuartz(q =>
        {
            // Use a Scoped container to create jobs.
            q.UseMicrosoftDependencyInjectionJobFactory();
                
            q.AddJobAndTriger<AddExchangeRateToDatabase>("0 0 8 ? * MON,TUE,WED,THU,FRI *"); //At 08:00:00am every day except on weekend
                
            // For testing purposes
            // q.AddJobAndTriger<AddExchangeRateToDatabase>("0/5 * * ? * * *"); //Every 5 seconds
        });
            
        services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);
        return services;
    }
}