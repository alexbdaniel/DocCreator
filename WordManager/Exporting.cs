using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using WordManager.Models;
using WordApp = Microsoft.Office.Interop.Word;


namespace WordManager;

internal class Exporting
{
	private readonly SaveOptions args;

    public Exporting(SaveOptions args)
    {
        this.args = args;
    }


    internal void SaveAsDocx(WordApp.Document doc, bool closeAfterSave = true)
	{
		string fullPath = Path.Combine(args.DirectoryName, args.BaseName) + ".docx";
		
		doc.SaveAs2(fullPath);
		if (closeAfterSave) doc.Close(false);

	}

	internal void SaveAsPdf(WordApp.Document doc, bool openAfterExport = false, bool closeAfterExport = true)
	{
		string fullPath = Path.Combine(args.DirectoryName, args.BaseName) + ".pdf";

		doc.ExportAsFixedFormat2(fullPath, WordApp.WdExportFormat.wdExportFormatPDF, openAfterExport, WordApp.WdExportOptimizeFor.wdExportOptimizeForOnScreen);
		if (closeAfterExport) doc.Close(false);
	}



}
