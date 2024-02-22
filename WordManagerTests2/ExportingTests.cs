using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordManager.Tests;

[TestClass()]
public class ExportingTests
{
	[TestMethod()]
	public void CopyFileTest()
	{
		string template = "C:\\Users\\Alex.Daniel\\Projects\\doc_creator_2\\DocCreator\\WordManagerTests2\\AU Booking Sheet Friday.docx";
		string dir = "C:\\Users\\Alex.Daniel\\Projects\\doc_creator_2\\DocCreator\\WordManagerTests2\\output";
		string baseName = "Friday";
		string ext = "docx";


		//string result = Exporting.CopyFile(template, dir, baseName, ext);


		Assert.Fail();
	}
}