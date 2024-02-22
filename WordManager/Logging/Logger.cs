using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WordManager.Models;

namespace WordManager.Logging;
internal class Logger
{
	internal static DocCreationResponse CreateResponseItem(string? message, bool? success = false)
	{
		return new DocCreationResponse()
		{
			Success = success ?? false,
			Message = message,
			DocArgs = null
		};
	}

	internal static DocCreationResponse CreateResponseItem(string? message, DocArgs? docArgs, bool? success = false)
	{
		return new DocCreationResponse()
		{
			Success = success ?? false,
			Message = message,
			DocArgs = docArgs
		};
	}

	internal static void AppendToResults(ref List<DocCreationResponse> resultList, DocCreationResponse item)
	{
		resultList.Add(item);
	}

	internal static void AppendToResults(ref ConcurrentBag<DocCreationResponse> results, DocCreationResponse item)
	{
		results.Add(item);
	}

	internal static async Task<string> WriteToLogFileAsync(DocCreationResponse response, string fullPath)
	{
		var serializerOptions = new JsonSerializerOptions() { IncludeFields = true, PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
		var txt = JsonSerializer.Serialize(response, options: serializerOptions);

		using (var file = new StreamWriter(fullPath))
		{
			await file.WriteLineAsync($"{txt},");
		}

		return fullPath;


	}


}
