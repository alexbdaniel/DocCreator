using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WordManager.Models;


internal class TemplateConfig
{



	internal Dictionary<string, Export> dic;
}

internal class Export
{
	[JsonPropertyName("directory")]
	string Directory { get; set; }

	[JsonPropertyName("baseName")]
	string BaseName { get; set; }
}
