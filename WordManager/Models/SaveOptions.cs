using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordManager.Models;

internal class SaveOptions
{
	internal string BaseName { get; set; }

	internal string FileExtension { get; set; } = "docx";

	internal string DirectoryName { get; set; }

	internal bool CloseAfterSave { get; set; }
}
