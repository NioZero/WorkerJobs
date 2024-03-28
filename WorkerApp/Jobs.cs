using System.Collections.ObjectModel;

namespace WorkerApp;

public class Jobs
{
    #region init

    private readonly ILogger<Jobs> Logger;

    private readonly IServiceProvider ServiceProvider;

    public Jobs(ILogger<Jobs> logger, IServiceProvider serviceProvider)
    {
        Logger = logger;
        ServiceProvider = serviceProvider;
    }

    #endregion

    /// <summary>
    /// Dictionary with Jobs key and Methods associated
    /// </summary>
    private readonly IReadOnlyDictionary<string, Func<ILogger, IServiceProvider, Task>> _jobList = new ReadOnlyDictionary<string, Func<ILogger, IServiceProvider, Task>>(new Dictionary<string, Func<ILogger, IServiceProvider, Task>>(StringComparer.InvariantCultureIgnoreCase)
    {
        { "Job1", Job1 },
        { "Job2", Job2 }
    });

    /// <summary>
    /// Execute specific Job Name
    /// </summary>
    /// <param name="jobName">Key of Job</param>
    /// <exception cref="KeyNotFoundException">If <see cref="jobName"/> is not found</exception>
    public async Task ExecuteJob(string jobName)
    {
        if (!_jobList.ContainsKey(jobName))
            throw new KeyNotFoundException($"Job {jobName} not found");

        await _jobList[jobName].Invoke(Logger, ServiceProvider);
    }

    #region jobs

    /// <summary>
    /// Example Job 1
    /// </summary>
    private static async Task Job1(ILogger logger, IServiceProvider serviceProvider)
    {
        logger.LogInformation($"Job1 triggered at {DateTime.Now}");

        await Task.CompletedTask;
    }

    /// <summary>
    /// Example Job 2
    /// </summary>
    private static async Task Job2(ILogger logger, IServiceProvider serviceProvider)
    {
        logger.LogInformation($"Job2 triggered at {DateTime.Now}");

        await Task.CompletedTask;
    }

    #endregion
}
