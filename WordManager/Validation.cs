using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordManager;
public class Validation
{
	public bool CheckArgsValid(string? fullPath)
	{
		if (string.IsNullOrEmpty(fullPath)) return false;

		return CheckFileExists(fullPath);
	}

	private bool CheckFileExists(string? fullPath = "")
	{
		if (string.IsNullOrWhiteSpace(fullPath)) return false;
		return File.Exists(fullPath);
	}
}
