// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Tranlator.Service;
using Translator.Repository;
using Translator.Repository.Interface;
using Translator.Service.Interface;

class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("English to French Translator");
        Console.WriteLine("#######################################################################");
        Console.WriteLine("");
        Console.WriteLine("");


        var host = CreateHostBuilder(args).Build();
        WriteToConsole("test words");
        WriteToConsole("Farnborough International Airshow, biennial global aerospace, defence and space trade event which showcases the latest commercial and military aircraft. Manufacturers such as Airbus and Boeing are expected to display their products and announce new orders * 2020 event was held virtually after the physical show was cancelled due to the coronavirus (COVID-19) pandemic");
        WriteToConsole("Labour market statistics: integrated national release, including the latest data for employment, economic activity, economic inactivity, unemployment, claimant count, average earnings, productivity, unit wage costs, vacancies & labour disputes");
        WriteToConsole("City of London Corporation's Financial and Professional Services dinner. Chancellor Rishi Sunak and Bank of England Governor Andrew Bailey make their annual Mansion House speeches at the event hosted by the Lord Mayor of the City of London Vincent Keaveny");
        Console.WriteLine("");


    }

    private static void WriteToConsole(string english)
    {
        TranslatorRepository repository = new TranslatorRepository(new TranslatorService());
            var result = repository.Translate(english, "fr");
        Console.WriteLine("");
        Console.WriteLine("English ->  " + english);
        Console.WriteLine("..................................");
        Console.WriteLine("French ->   " + result);
        Console.WriteLine("=======================================================================");
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
