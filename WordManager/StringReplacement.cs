using DocumentFormat.OpenXml.Packaging;
using OpenXmlPowerTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordManager.Models;
using WordApp = Microsoft.Office.Interop.Word;

namespace WordManager;

internal class StringReplacer
{

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
