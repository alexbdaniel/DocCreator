using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordManager.Models;
public class DocCreationResponse
{
	public bool Success { get; init; }

	public string? Message { get; init; }

	public DocArgs? DocArgs { get; init; }
}
