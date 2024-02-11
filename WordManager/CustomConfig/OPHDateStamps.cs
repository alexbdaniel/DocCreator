using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WordManager.Models;

namespace WordManager.CustomConfig.OPHDateStamps;



public class OPHDateStamps
{
	private Dictionary<string, string> templateFullPaths = new Dictionary<string, string>
	{
		{ "Monday", @"C:\Users\Alex.Daniel\Documents\Work Projects\OPHDateStamps\Templates\AU Booking Sheet Monday.docx" },
		{ "Tuesday", @"C:\Users\Alex.Daniel\Documents\Work Projects\OPHDateStamps\Templates\AU Booking Sheet Tuesday.docx"},
		{ "Wednesday", @"C:\Users\Alex.Daniel\Documents\Work Projects\OPHDateStamps\Templates\AU Booking Sheet Wednesday-Thursday.docx" },
		{ "Thursday", @"C:\Users\Alex.Daniel\Documents\Work Projects\OPHDateStamps\Templates\AU Booking Sheet Wednesday-Thursday.docx" },
		{ "Friday", @"C:\Users\Alex.Daniel\Documents\Work Projects\OPHDateStamps\Templates\AU Booking Sheet Friday.docx" },
		{ "Saturday", @"C:\Users\Alex.Daniel\Documents\Work Projects\OPHDateStamps\Templates\AU Booking Sheet Saturday-Sunday.docx" },
		{ "Sunday", @"C:\Users\Alex.Daniel\Documents\Work Projects\OPHDateStamps\Templates\AU Booking Sheet Saturday-Sunday.docx" }


	};


	public List<ReplacementArgs> CreateFileArgs()
	{
		var start = new DateOnly(2024, 4, 1);
		var end = new DateOnly(2024, 9, 30);
		string outputDir = @"C:\Users\Alex.Daniel\Documents\Work Projects\OPHDateStamps\Output";

		var span = end.DayNumber - start.DayNumber;

		var argList = new List<ReplacementArgs>();
		var days = new List<DateOnly>(span);
		
		for (int i = 0; i < span; i++)
		{
			days.Add(start.AddDays(i));
		}

		foreach (var day in days)
		{
			var toReplace = new Dictionary<string, string>
			{
				{ "{{dddd}}", day.ToString("dddd") },
				{ "{{d MMMM yyyy}}", day.ToString("d MMMM yyyy") }
			};

			string dayName = day.ToString("dddd");
			var templateFullPath = templateFullPaths[dayName];


		
			string baseName = day.ToString("yyyy-MM-dd dddd");

			var args = new Preparation().BuildReplacementArg(toReplace, templateFullPath, outputDir, baseName);
			argList.Add(args);
			
		};



		return argList;

	}
}

public static class ReflectionExtensions
{
	public static T GetFieldValue<T>(this object obj, string name)
	{
		// Set the flags so that private and public fields from instances will be found
		var bindingFlags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;
		var field = obj.GetType().GetField(name, bindingFlags);
		return (T)field?.GetValue(obj);
	}
}
