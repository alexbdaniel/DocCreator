using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandLine;

namespace DocCreator.Presentation.Configuration;
internal class CommandLineOptions
{
	[Option('p', "docargsfullpath", Required = true, HelpText = "Full path to the document arguments")]
	public string DocArgsFullPath { get; set; }

	//[Option('a', "docargs", Required = true, HelpText = "Full path to the document arguments")]
	//public string DocArgsFullPath { get; set; }

	[Option('d', "opendirectory", Required = false, Default = true, HelpText = "Open the directory with the created documents on completion.")]
	public bool OpenDirectoryOnCompletion { get; set; } = true;
}

