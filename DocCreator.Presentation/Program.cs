
using DocCreator.Presentation.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Formatting.Compact;
using WordManager;
using WordManager.Models;
using static System.Environment;
using DocCreator.Presentation;
using Microsoft.Extensions.Options;

namespace DocCreator.Presentation;

internal class Program
{
	static void Main(string[] args)
	{

	

		
		Console.WriteLine("Specify the full path for the document arguments:");

		string? docArgsFullPath = Console.ReadLine()?.Trim();
		if (string.IsNullOrWhiteSpace(docArgsFullPath))
		{
			Main(args);
		}
		else
		{
			docArgsFullPath = Cleaning.CleanPath(docArgsFullPath);
		}
			
		var result = new Creator().CreateDocsHandlerAsync(docArgsFullPath).Result;

		var log = new LogSetup<DocCreationResponse>();

		string logFullPath = log.CreateLogFile();
		log.WriteToLogFile(result, logFullPath);

		Console.WriteLine(Helper.CreateLogMessage(result, logFullPath));

		Main(args);




		Console.ReadKey(true);
	}

	static IServiceCollection AddServices(this IServiceCollection services)
	{
		var configuration = new ConfigurationBuilder()
			.AddJsonFile("appsettings.json")
			.Build();

		return services;
	}


}
