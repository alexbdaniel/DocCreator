using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordManager.Models;

namespace WordManager;

public class Preparation
{
	public ReplacementArgs BuildReplacementArg(Dictionary<string, string> replacements, string templateFullPath, string destination, string newBaseName)//todo change to async
	{
		const string placeholderStart = "{{";
		const string placeholderFinish = "}}";

		return new ReplacementArgs()
		{
			Replacements = replacements,
			DocFullPath = CopyFile(templateFullPath, destination, newBaseName)
		};

	}

	/// <summary>
	/// 
	/// </summary>
	/// <param name="source">Full path of file to copy</param>
	/// <returns></returns>
	private string CopyFile(string source, string destinationDirectory)
	{
		string destinationFullPath = Path.Combine(destinationDirectory, Path.GetFileName(source));

		if (File.Exists(destinationFullPath)) return $"[file_exists]{destinationFullPath}";

		File.Copy(source, destinationFullPath, false);

		return destinationFullPath;


	}
	/// <summary>
	/// 
	/// </summary>
	/// <param name="source">Full path of file to copy</param>
	/// <param name="newBaseName">Give the copied file a new base name</param>
	/// <returns></returns>
	private string CopyFile(string source, string destinationDirectory, string newBaseName, bool? appendGuidIfFileExists = false)
	{
		var newFileName = $"{newBaseName}{Path.GetExtension(source)}";

		string destinationFullPath = Path.Combine(destinationDirectory, newFileName);

		if (File.Exists(destinationFullPath))
		{
			if (appendGuidIfFileExists == false) return $"[file_exists]{destinationFullPath}";

			newFileName = $"{newBaseName}_{Guid.NewGuid()}{Path.GetExtension(source)}";
			destinationFullPath = Path.Combine(destinationDirectory, newFileName);
		}		

		File.Copy(source, destinationFullPath, false);

		return destinationFullPath;
	}

	/// <summary>
	/// 
	/// </summary>
	/// <param name="source">Full path of file to copy</param>
	/// <returns></returns>
	private string CopyFileWithNewRandomBaseName(string source, string destinationDirectory)
	{
		var guid = Guid.NewGuid();
		var newFileName = $"{Path.GetFileNameWithoutExtension(source)}_{guid}{Path.GetExtension(source)}";
		string destinationFullPath = Path.Combine(destinationDirectory, newFileName);

		File.Copy(source, destinationFullPath, false);

		return destinationFullPath;
	}




	//var rec1 = new ReplacementArgs()
	//{
	//	ToFind = "{{name}}", //todo set identifier before? inserstion into replacementArgs
	//	Replacement = "Smith",
	//	TemplateFullPath = @"C:\Users\Alex.Daniel\Desktop\temp\template.docx",
	//	SaveFullPath = @"C:\Users\Alex.Daniel\Desktop\temp\output\result1.pdf"
	//};

	//var rec2 = new ReplacementArgs()
	//{
	//	ToFind = "{{name}}", //todo set identifier before? inserstion into replacementArgs
	//	Replacement = "Smith",
	//	TemplateFullPath = @"C:\Users\Alex.Daniel\Desktop\temp\template2.docx",
	//	SaveFullPath = @"C:\Users\Alex.Daniel\Desktop\temp\output\result2.pdf"
	//};

	//var records = new List<ReplacementArgs>() { rec1, rec2 };
}
