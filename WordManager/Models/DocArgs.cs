using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WordManager.Models;

public class DocArgs
{
	[JsonInclude]
	public string TemplateFullPath { get; init; }

	[JsonInclude]
	public SaveArgs SaveArgs { get; init; }

	[JsonInclude]
	public List<PlaceholderArgs> PlaceholderArgs { get; init; }

}

public class PlaceholderArgs
{
	[JsonInclude]
	public string ToFind { get; init; }

	[JsonInclude]
	public string ReplaceWith { get; init; }
}

public class SaveArgs
{
	[JsonInclude]
	public string Extension { get; init; }

	[JsonInclude]
	public string BaseName { get; init; }

	[JsonInclude]
	public bool? AppendStringOnConflict { get; init; } = true;

	[JsonInclude]
	public string Directory { get; init; }
}