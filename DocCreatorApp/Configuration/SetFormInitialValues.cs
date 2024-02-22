using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocCreatorApp.Configuration;
internal static class SetFormInitialValues
{
	internal static void ConfigNavigationListView(ListView listView)
	{
		

		var item = new ListViewItem()
		{
			Text = "Letter type"
		};

		listView.Items.Add(item);

		listView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);

		listView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);

	}
}
