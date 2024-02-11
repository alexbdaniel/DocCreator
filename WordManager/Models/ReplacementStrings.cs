using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordManager.Models;

public class ReplacementStrings : Dictionary<string, string>
{
	public new void Add(string toFind, string replaceWith) => base.Add(toFind, replaceWith);

	public new string this[string toFind]
	{
		get { return base[toFind]; }
		set { base[toFind] = value; }
	}	
}
