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

public class Exporting
{
	/// <summary>
	/// Copies file and appends a GUID to the base name if the file already exists in the target directory.
	/// </summary>
	/// <param name="source">Full path of file to copy</param>
	/// <param name="destDirName">Directory name to save to</param>
	/// <param name="targetBaseName">Ideal basename assuming other files do not exist</param>
	/// <param name="extension"></param>
	/// <returns>Full path of copied file if successful. Otherwise, returns a string starting with "[file_exists]".</returns>
	internal static string CopyFile(string source, string destDirName, string targetBaseName, string extension)
    {

        string fullPathWithoutExtension = Path.Combine(destDirName, targetBaseName);
        int attempts = 0;
        
        while (File.Exists(fullPathWithoutExtension + "." + extension) && attempts < 10)
        {
            attempts++;
            fullPathWithoutExtension = Path.Combine(destDirName, $"{targetBaseName}_{Guid.NewGuid()}");
        }

        string destFullPath = fullPathWithoutExtension + "." + extension;

        if ( attempts >= 10 ) return $"[exception] attempted to rename file {attempts} times: {destFullPath}";

        try
        {
            File.Copy(source, destFullPath, overwrite: false);
            return destFullPath;
        } catch
        {
			return $"[exception] failed to copy file. Ensure the application has write access to the target directory: {destDirName}.";
		}
        

    }




    internal static string CreateLogFile()
    {
		string tempDirName = Path.GetTempPath();
		var dt = DateTime.UtcNow.ToString("o").Replace(":", "");
		string name = $"create_doc_log_{dt}.json";
		string fullPath = Path.Combine(tempDirName, name);
        string initialText = @"{""results"": }";


        File.Create(fullPath);
        File.WriteAllText(fullPath, initialText);

        return fullPath;
	}


    
    

    

}
