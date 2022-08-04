// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Translator.Repository;
using Translator.Repository.Interface;
using Translator.Service.Interface;

class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Hello World");
       

        var host= CreateHostBuilder(args).Build();

        var mess = host.Services.GetService<ITranslatorRepository>().Translate("test words", "fr");
    }

    private static IHostBuilder CreateHostBuilder(string[] args)
    {
        var hostBuilder = Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((context, builder) =>
            {
                builder.SetBasePath(Directory.GetCurrentDirectory());
            })
            .ConfigureServices((context, services) =>
            {
                services.AddScoped<ITranslatorRepository, TranslatorRepository>();    
        });

        return hostBuilder;
    }
}

class EnglishToFrench
{
    private static ITranslatorService _repository;
    TranslatorRepository repository= new TranslatorRepository(_repository);
    public EnglishToFrench()
    {
        var result = repository.Translate("test words", "fr");
        Console.WriteLine(result);
    }
}

