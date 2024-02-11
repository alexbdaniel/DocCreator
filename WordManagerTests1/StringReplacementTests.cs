using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordApp = Microsoft.Office.Interop.Word;

namespace WordManager.Tests
{
	[TestClass()]
	public class StringReplacementTests
	{
		[TestMethod()]
		public void ReplaceStringTest()
		{
			const string templateFullPath = @"C:\Users\Alex.Daniel\Desktop\temp\template.docx";

			var app = new WordApp.Application();

			var doc = app.Documents.Open(templateFullPath);
			app.Visible = true;






			//new WordManager.StringReplacement(toFind: "{{name}}", "Smith", doc).ReplaceString();



			Assert.Fail();
		}
	}
}