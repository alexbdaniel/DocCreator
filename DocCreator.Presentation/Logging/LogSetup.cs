using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WordManager.Models;

namespace DocCreator.Presentation.Logging;
internal class LogSetup<T> where T : class
{
	internal string CreateLogFile()
	{
		string tempDirName = Path.GetTempPath();
		var dt = DateTime.UtcNow.ToString("o").Replace(":", "");
		string name = $"doccreator_log_{dt}.json";
		string fullPath = Path.Combine(tempDirName, name);

		File.Create(fullPath).Dispose();

		return fullPath;
	}

	internal string CreateLog(List<T> results)
	{
		var log = new LogModel<T>() { Results = results };

		return "ok";
	}

	internal void WriteToLogFile(List<T> results, string fullPath)
	{
		var serializerOptions = new JsonSerializerOptions() { IncludeFields = true, PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
		string txt = JsonSerializer.Serialize(results, options: serializerOptions);

		using (var file = new StreamWriter(path: fullPath))
		{
			file.Write(txt);
		}

	}


}
