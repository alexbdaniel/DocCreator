using OpenXmlPowerTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace WordManager;
internal class Utilities
{
	internal static async Task<T?> DeserializeAsync<T>(Stream stream) where T : class
	{
		var serializerOptions = new JsonSerializerOptions()
		{
			PropertyNamingPolicy = JsonNamingPolicy.CamelCase
		};

		return await JsonSerializer.DeserializeAsync<T>(stream, serializerOptions);



	}

	internal static bool CheckFileExists(string? fullPath = "")
	{
		if (string.IsNullOrWhiteSpace(fullPath)) return false;
		return File.Exists(fullPath);
	}
}
