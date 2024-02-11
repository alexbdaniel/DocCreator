using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordManager.Models;

public record ReplacementArgs
{
	public Dictionary<string, string> Replacements { get; set; }

	public string ToFind { get; init; }

	public string Replacement { get; init; }

	public string TemplateFullPath { get; init; }

	public string SaveFullPath { get; init; }

	public string DocFullPath { get; init; }
}

