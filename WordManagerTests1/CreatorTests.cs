using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordManager.Models;
using System.Security.AccessControl;
using DocumentFormat.OpenXml.EMMA;
using System.Text.RegularExpressions;

namespace WordManager.Tests
{
	[TestClass()]
	public class CreatorTests
	{
		[TestMethod()]
		public async Task CreateDocTest()
		{
			var rec1 = new ReplacementArgs()
			{
				ToFind = "{{name}}", //todo set identifier before? inserstion into replacementArgs
				Replacement = "Smith",
				TemplateFullPath = @"C:\Users\Alex.Daniel\Desktop\temp\template.docx",
				SaveFullPath = @"C:\Users\Alex.Daniel\Desktop\temp\output\result1.pdf"
			};

			var rec2 = new ReplacementArgs()
			{
				ToFind = "{{name}}", //todo set identifier before? inserstion into replacementArgs
				Replacement = "Smith",
				TemplateFullPath = @"C:\Users\Alex.Daniel\Desktop\temp\template2.docx",
				SaveFullPath = @"C:\Users\Alex.Daniel\Desktop\temp\output\result2.pdf"
			};

			var records = new List<ReplacementArgs>() { rec1, rec2 };


			_ = await new Creator().CreateDocs(records);



		}

		[TestMethod()]
		public async Task ReplaceTextTest()
		{
			string path = @"C:\Users\Alex.Daniel\Documents\Work Projects\OPHDateStamps\Output\AU Booking Sheet Monday.docx";

		

			_ = await new Creator().ReplaceText(path);



		}




		




		[TestMethod()]
		public void Buffering()
		{
			string startFlag = "{{";
			string endFlag = "}}";
			string toFind = "{{dddd}}";
			string[] content = { "{{", "dddd", "}}", " ", "{{dddd}}" };


			//keep original position as index?

			//only find flag, then test until closing flag? 
			//first look for flags alone, then whole strings
			var found = new List<int>();

			string joined = "";

			var indexes = new Dictionary<string, Indexes>();

			foreach (var (value, i) in content.Select((value, i) => (value, i)))
			{
				int _index = i;
				joined = joined + value;

				int startPosition = joined.Length - 1;
				int endPosition = startPosition + value.Length - 1;

				indexes.Add(
					value,
					new Indexes()
					{
						StartPosition = startPosition,
						EndPosition = endPosition,
						Index = i,
						Value = value
					});
			};

			var chars = joined.ToCharArray();
			var buffer = new List<string>();


			foreach (var (value, i) in chars.Select((value, i) => (value, i)))
			{
				buffer.Add(value.ToString());
			}

			var pattern = @".*?(" + startFlag + @").*?(?=\1|$)";
			var regex = new Regex(pattern);
			var matches = regex.Matches(joined);




		}

		
	}

	public static class Ext
	{
		public static IEnumerable<int> IndexOfAll(this string toFind, string subString)
		{
			return Regex.Matches(toFind, subString).Cast<Match>().Select(i => i.Index);
		}
	}

	
}