using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordManager.CustomConfig.OPHDateStamps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Spreadsheet;

namespace WordManager.CustomConfig.OPHDateStamps.Tests;

[TestClass()]
public class OPHDateStampsTests
{
	[TestMethod()]
	public void CreateFileArgsTest()
	{
		var x = new OPHDateStamps();//CreateFileArgs();
		var fullPath = x.CreateArgFile();

		var args = x.CreateFileArgs();

		x.SaveArgsToFile(args, fullPath);


	}
}