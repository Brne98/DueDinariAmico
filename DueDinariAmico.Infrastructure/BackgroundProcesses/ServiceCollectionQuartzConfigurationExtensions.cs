using Quartz;

namespace ExchangeRate.Infrastructure.BackgroundProcesses;

public static class ServiceCollectionQuartzConfigurationExtensions
{
    public static void AddJobAndTriger<T>(this IServiceCollectionQuartzConfigurator quartz, string cronSchedule) where T : IJob
    {
        string jobName = typeof(T).Name;
        
        var jobKey = new JobKey(jobName);
        quartz.AddJob<T>(opts => opts.WithIdentity(jobKey));

        quartz.AddTrigger(opts => opts
            .ForJob(jobName) // link to the NotifyAdExpiredJob
            .WithIdentity(jobName + "-trigger") // give the trigger a unique name
            .WithCronSchedule(cronSchedule)); // use the schedule from configuration (example:run every 5 seconds)
    }
}
