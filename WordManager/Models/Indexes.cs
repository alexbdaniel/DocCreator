using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordManager.Models;

public record Indexes
{
	public int Index { get; set; }
	public int StartPosition { get; set; }
	public int EndPosition { get; set; }
	public string Value { get; set; }

}