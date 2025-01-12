﻿global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.Hosting;
global using Microsoft.Extensions.Options;

using var host = Host.CreateDefaultBuilder()
    .ConfigureServices(services =>
    {
        // services.AddOptions(); // already added from host
        services.AddGreetingService(options =>
        {
            options.From = "Christian";
        });
        services.AddSingleton<IGreetingService, GreetingService>();
        services.AddTransient<HomeController>();
    }).Build();

var controller = host.Services.GetRequiredService<HomeController>();
string result = controller.Hello("Katharina");
Console.WriteLine(result);
