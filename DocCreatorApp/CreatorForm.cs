﻿using DocCreatorApp.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DocCreatorApp;
public partial class CreatorForm : Form
{
	public CreatorForm()
	{
		InitializeComponent();
		SetFormInitialValues.ConfigNavigationListView(this.NavigationListView);
	}

	private void NavigationListView_SelectedIndexChanged(object sender, EventArgs e)
	{
		
	}
}