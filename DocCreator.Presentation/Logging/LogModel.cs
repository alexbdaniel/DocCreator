using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocCreator.Presentation.Logging;

internal class LogModel<T> where T : class
{
	internal required List<T> Results { get; set; }
}
