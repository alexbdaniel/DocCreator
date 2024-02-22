using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordManager.Models;

namespace DocCreator.Presentation.Logging;
internal class Helper
{
	internal static string CreateLogMessage(List<DocCreationResponse> results, string logFullPath)
	{
		bool completedWithExceptions = results.Where(i => i.Success == false).ToList().Count() > 0;

		if (completedWithExceptions)
		{
			return $"{Environment.NewLine}Document creation completed with exceptions. Log = \"{logFullPath}\"{Environment.NewLine}";
		}
		else
		{
			return $"{Environment.NewLine}Document creation completed successfully. Log = \"{logFullPath}\"{Environment.NewLine}";
		}

		
	}
}
