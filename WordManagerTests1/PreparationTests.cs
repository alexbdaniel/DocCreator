using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordManager.Tests
{
	[TestClass()]
	public class PreparationTests
	{
		public record rec
		{
			public string source { get; set; }
			public string destination { get; set; }
		}







		[TestMethod()]
		public void CopyFileTest()
		{
			var rec1 = new rec()
			{
				destination = @"C:\Users\Alex.Daniel\Desktop\temp\output",
				source = @"C:\Users\Alex.Daniel\Desktop\temp\template.docx"
			};
			var rec2 = new rec()
			{
				destination = @"C:\Users\Alex.Daniel\Desktop\temp\output",
				source = @"C:\Users\Alex.Daniel\Desktop\temp\template.docx"
			};
			var rec3 = new rec()
			{
				destination = @"C:\Users\Alex.Daniel\Desktop\temp\output",
				source = @"C:\Users\Alex.Daniel\Desktop\temp\template.docx"
			};
			var rec4 = new rec()
			{
				destination = @"C:\Users\Alex.Daniel\Desktop\temp\output",
				source = @"C:\Users\Alex.Daniel\Desktop\temp\template.docx"
			};

			var list = new List<rec>
			{
				rec1, rec2, rec3, rec4
			};

			



			
		}
	}
}