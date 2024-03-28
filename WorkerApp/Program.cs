using WorkerApp;

var builder = Host.CreateDefaultBuilder(args);

builder.ConfigureAppConfiguration((builter, b) =>
{
    b.AddCommandLine(args);
});

builder.ConfigureServices((builder, b) =>
{
    b.AddSingleton<Jobs>();
});

var app = builder.Build();

var configuration = app.Services.GetRequiredService<IConfiguration>();

var jobs = app.Services.GetRequiredService<Jobs>();

await jobs.ExecuteJob(configuration["job"]);

await app.RunAsync();
