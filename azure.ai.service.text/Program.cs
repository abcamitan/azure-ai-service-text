using azure.ai.service.text;
using Azure.AI.Service.Text.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

var host = Host.CreateDefaultBuilder(args)  
    .ConfigureAppConfiguration((hostContext, config) =>
    {
        var env = hostContext.HostingEnvironment;
        config.AddJsonFile($"local.settings.json", optional: true, reloadOnChange: true);
        config.AddEnvironmentVariables();
    })
    .ConfigureLogging(logging =>
    {
        logging.ClearProviders();
        logging.AddConsole();
    })
    .ConfigureServices((hostContext, services) =>
    {
        services
            .AddOptions<AIServiceOption>()
            .Configure<IConfiguration>((option, configuration) =>
            {
                configuration.GetSection(nameof(AIServiceOption)).Bind(option);
            });

        services.AddSingleton<IDetectLanguageService>((sc) =>
        {
            var options = sc.GetRequiredService<IOptions<AIServiceOption>>().Value;
            return new DetectLanguageService(options);
        });

        services.AddTransient<UserInput>();

        var userInput = services.BuildServiceProvider().GetService<UserInput>();
        userInput!.Run();
    })
    .Build();
