using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordManager.CustomConfig.OPHDateStamps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordManager.Models;

namespace WordManager.CustomConfig.OPHDateStamps.Tests
{
	[TestClass()]
	public class OPHDateStampsTests
	{
		[TestMethod()]
		public async Task CreateFileArgsTest()
		{
			var records = new OPHDateStamps().CreateFileArgs();

			//var x = new Dictionary<string, string>
			//{
			//	{ "{{dddd}}", "Monday" }
			//};

			//var toreplace = new ReplacementArgs()
			//{
			//	DocFullPath = @"C:\Users\Alex.Daniel\Documents\Work Projects\OPHDateStamps\Output\AU Booking Sheet Monday.docx",
			//	Replacements = x,
			//};

			//var l = new List<ReplacementArgs>();
			//l.Add(toreplace);

			//_ = await new Creator().ReplaceStringsWithWordAppAsync(toreplace);

			await new Creator().CreateDocs(records);

			//Assert.Fail();
		}
	}
}