using WordManager.Models;
using Word = Microsoft.Office.Interop.Word;
using DocumentFormat.OpenXml.Packaging;
using System.IO;
using System.Text.RegularExpressions;
using OpenXmlPowerTools;
using System.Xml.Linq;
using DocumentFormat.OpenXml;

namespace WordManager;

public class Creator
{
	private readonly Word.Application wordApp;

	public Creator()
	{
		
	}

	public async Task<string> CreateDocs(List<ReplacementArgs> args)
	{
		var parallelOptions = new ParallelOptions()
		{
			CancellationToken = CancellationToken.None
		};

		var cancellationToken = parallelOptions.CancellationToken;

		var results = new List<string>();
		

		await Parallel.ForEachAsync(args, parallelOptions, async (i, cancellationToken) =>
		{
			//var result = await ReplaceStringsWithWordAppAsync(i);
			var result = await ReplaceXmlStringsAsync(i);
			results.Add(result);
		});
		
		wordApp.Quit(SaveChanges: true);

		return "ok";


	}


	public async Task<string> ReplaceStringsWithWordAppAsync(ReplacementArgs args)
	{
		var doc = wordApp.Documents.Open(args.DocFullPath);

		foreach (var i in args.Replacements)
		{
			foreach (Word.Range range in doc.StoryRanges)
			{
				range.Find.Execute(
					FindText: i.Key,
					MatchCase: true,
					MatchWholeWord: true,
					Forward: true,
					ReplaceWith: i.Value
					);
			}

		}

		doc.Save();
		return "ok";


	}

	private async Task<string> ReplaceXmlStringsAsync(ReplacementArgs args)
	{




		using (var doc = WordprocessingDocument.Open(args.DocFullPath, isEditable: true))
		{
			string? docText;
			var root = doc.MainDocumentPart.GetXDocument().Root;

			var headers = root.Descendants(W.h).ToList();

			foreach (var header in headers)
			{

			}


			var content = root.Descendants(W.p).ToList();
		

			var regex = new Regex("{{dddd}}");
		
			

			foreach (var i in args.Replacements)
			{
				var regexText = new Regex(i.Key);


			}
		}

		return "ok";
	}

	private void ReplaceInHeaders(XElement element)
	{
		var headers = element.Elements(W.headers);
		

		foreach (var header in headers)
		{

		}
	}











	public async Task<string> ReplaceText(string docFullPath)
	{
		

		using (var doc = WordprocessingDocument.Open(docFullPath, true))
		{
			string replaceWith = "Smith";
			string regexPattern = "{{dddd}}";
			var regex = new Regex(regexPattern);
		
			var root = doc.MainDocumentPart.GetXDocument();
			var content = root.Descendants(W.p);


			//var headerParts = doc.MainDocumentPart.HeaderParts;

			foreach (var headerPart in doc.MainDocumentPart.HeaderParts)
			{
				var headerContent = headerPart.RootElement.Descendants<DocumentFormat.OpenXml.Wordprocessing.Text>();
				foreach (var i in headerPart.RootElement.Descendants<DocumentFormat.OpenXml.Wordprocessing.Text>())
				{
					
					i.Text = i.Text.Replace(regexPattern, replaceWith);
				}

			}

			//var h = doc.MainDocumentPart.HeaderParts.SelectMany(i => i.GetXDocument().Descendants(W.p));
			//OpenXmlRegex.Replace(content, regex, replaceWith, null);
			//OpenXmlRegex.Replace(h, regex, replaceWith, null);

			TextReplacer.SearchAndReplace(doc, regexPattern, replaceWith, true);

			doc.MainDocumentPart.PutXDocument();
			
			doc.Save();
		}


		return "";


		

	}
	

}
