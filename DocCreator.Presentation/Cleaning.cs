using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocCreator.Presentation;
internal class Cleaning
{
	internal static string CleanPath(string path)
	{
		StringBuilder sb = new StringBuilder(path);

		sb.Replace("\"", "");

		return sb.ToString().Trim();
	}
}
