
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
using CommandLine;
using DocCreator.Presentation.Configuration;

namespace DocCreator.Presentation;

internal class Program
{
	static void Main(string[] args)
	{
		Parser.Default.ParseArguments<CommandLineOptions>(args).WithParsed(options =>
		{
			

			string? docArgsFullPath = options.DocArgsFullPath;

			if (string.IsNullOrWhiteSpace(docArgsFullPath))
			{
				Console.WriteLine("Specify a valid path to the document arguments");
				return;
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

		});
		







		Console.ReadKey();
	}




}
