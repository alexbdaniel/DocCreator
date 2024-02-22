using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using WordManager.Models;

namespace WordManager;

[JsonSerializable(typeof(DocArgs))]
public partial class DocArgsSerializerContext : JsonSerializerContext { }

public class Preparation
{
    private readonly string placeholderStart = "{{";
	private readonly string placeholderEnd = "}}";
    private readonly JsonSerializerOptions serializerOptions = new JsonSerializerOptions()
    {
        IncludeFields = true,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    };

	public Preparation()
    {
        
    }

    public async Task<List<DocArgs>?> GetDocArgsListFromFileAsync(string fullPath)
    {
		using (var stream = new FileStream(fullPath, FileMode.Open, FileAccess.Read))
		{
			var contents = await JsonSerializer.DeserializeAsync<List<DocArgs>>(stream, options: serializerOptions);
			return contents;
		}
	}












	public DocArgs BuildDocArgs(
        string templateFullPath,
        string x
        
        
        
        )
    {

        throw new NotImplementedException();
    }
}
