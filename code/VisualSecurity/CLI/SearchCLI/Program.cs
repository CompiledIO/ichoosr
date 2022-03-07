using CommandLine;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SearchCLI.Application;
using SearchCLI.Application.Handlers;
using SearchCLI.Application.Queries;
using SearchCLI.Models;
using System;
using System.Threading.Tasks;
using VisualSecurity.Infrastructure.Csv.Interfaces.Services;
using VisualSecurity.Infrastructure.Csv.Services;

namespace SearchCLI
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            await Parser.Default.ParseArguments<Options>(args)
                .WithParsedAsync(RunOptions);
        }

        static async Task RunOptions(Options options)
        {
            var builder = CreateHostBuilder().Build();

            using (var scope = builder.Services.CreateScope())
            {
                var mediator = scope.ServiceProvider.GetService<IMediator>();

                try
                {
                    Console.WriteLine(await mediator.Send(new NameQuery(options.Name)));
                }
                catch (Exception ex)
                {
                    //Preferably use logging
                    Console.WriteLine(ex.Message);
                }
            }
        }

        public static IHostBuilder CreateHostBuilder() =>
        Host.CreateDefaultBuilder()
            .ConfigureServices((hostContext, services) =>
            {
                services.AddAutoMapper(typeof(ApplicationProfile));
                services.AddMediatR(typeof(SearchCameraByNameHandler).Assembly);                
                services.AddSingleton(typeof(IReadDataService<, ,>), typeof(ReadDataService<, ,>));
            });
    }
}
