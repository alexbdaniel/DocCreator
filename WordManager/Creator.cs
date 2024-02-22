using WordManager.Models;
using Word = Microsoft.Office.Interop.Word;
using DocumentFormat.OpenXml.Packaging;
using System.IO;
using System.Text.RegularExpressions;
using OpenXmlPowerTools;
using System.Xml.Linq;
using DocumentFormat.OpenXml;
using Serilog;
using System.Text.Json;
using WordManager.Logging;
using System.Collections.Concurrent;

namespace WordManager;

public class Creator
{
    public Creator()
    {
	
	}



    /// <summary>
    /// Creates documents from a json file.
    /// </summary>
    /// <param name="docArgsFullPath">Full path of the file containing the arguments.</param>
    /// <returns>A message to act on.</returns>
    public async Task<List<DocCreationResponse>> CreateDocsHandlerAsync(string? docArgsFullPath = "")
	{
		var results = new List<DocCreationResponse>();

		if (string.IsNullOrWhiteSpace(docArgsFullPath))
		{
			Logger.AppendToResults(ref results, Logger.CreateResponseItem($"Valid path for the document arguments was not supplied. Full path = \"{docArgsFullPath}\""));
			return results;
		} 
				
		if (!Utilities.CheckFileExists(docArgsFullPath))
		{
			Logger.AppendToResults(ref results, Logger.CreateResponseItem($"Document arguments file does not exist. Full path = \"{docArgsFullPath}\""));
			return results;
		}
	





		List<DocArgs>? docArgs;
		try
		{
			docArgs = await new Preparation().GetDocArgsListFromFileAsync(docArgsFullPath);
			if (docArgs == null) 
			{
				Logger.AppendToResults(ref results, Logger.CreateResponseItem($"Arguments could not be deserialized; check the format. Full path = \"{docArgsFullPath}\""));
				return results;
			}
		} 
		catch 
		{
			Logger.AppendToResults(ref results, Logger.CreateResponseItem($"Arguments could not be deserialized; check the format. Full path = \"{docArgsFullPath}\""));
			return results;
		}

		CreateDocs(docArgs, ref results);

		return results;
	}



	private void CreateDocs(List<DocArgs> args, ref List<DocCreationResponse> results)
	{
		var parallelOptions = new ParallelOptions(){ CancellationToken = CancellationToken.None };
		var parallelResults = new ConcurrentBag<DocCreationResponse>();

		Parallel.ForEach(args, parallelOptions, (i) =>
		{
			string fullPath = Exporting.CopyFile(i.TemplateFullPath, i.SaveArgs.Directory, i.SaveArgs.BaseName, i.SaveArgs.Extension);

			if (fullPath.StartsWith("[exception]"))
			{
				var responseItem = Logger.CreateResponseItem($"Failed to copy file. Final full path = \"{fullPath}\"", i);
				Logger.AppendToResults(ref parallelResults, responseItem);
			}
			else
			{
				ReplaceText(fullPath, i.PlaceholderArgs);
				var responseItem = Logger.CreateResponseItem($"Output = \"{fullPath}\"", i, success: true);
				Logger.AppendToResults(ref parallelResults, responseItem);
			}
		});

		foreach(var i in parallelResults)
		{
			results.Add(i);
		}
	}

	

	private void ReplaceText(string docFullPath, List<PlaceholderArgs> args)
	{
		using (var doc = WordprocessingDocument.Open(docFullPath, true))
		{
			foreach (var arg in args)
			{
				TextReplacer.SearchAndReplace(doc, arg.ToFind, arg.ReplaceWith, matchCase: true);
			}
			doc.MainDocumentPart.PutXDocument();
			doc.Save();
		}
	}

	
	

}
