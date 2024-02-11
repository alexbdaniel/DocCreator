using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordManager.Models;
using WordApp = Microsoft.Office.Interop.Word;

namespace WordManager;

internal class StringReplacement
{
	private readonly string toFind;
	private readonly string replacement;
	private readonly WordApp.Document doc;

    internal StringReplacement(string toFind, string replacement, WordApp.Document doc)
    {
        this.toFind = toFind;
		this.replacement = replacement;
		this.doc = doc;
    }

    internal void ReplaceString()
	{
		
		foreach (WordApp.Range range in doc.StoryRanges)
		{
			range.Find.ClearFormatting();
			range.Find.Text = toFind;
			range.Find.Replacement.Text = replacement;

			range.Find.Execute(Replace: WordApp.WdReplace.wdReplaceAll);
		}

		
	}


	










}
