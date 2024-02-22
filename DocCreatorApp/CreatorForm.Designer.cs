namespace DocCreatorApp;

partial class CreatorForm
{
	/// <summary>
	/// Required designer variable.
	/// </summary>
	private System.ComponentModel.IContainer components = null;

	/// <summary>
	/// Clean up any resources being used.
	/// </summary>
	/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
	protected override void Dispose(bool disposing)
	{
		if (disposing && (components != null))
		{
			components.Dispose();
		}
		base.Dispose(disposing);
	}

	#region Windows Form Designer generated code

	/// <summary>
	/// Required method for Designer support - do not modify
	/// the contents of this method with the code editor.
	/// </summary>
	private void InitializeComponent()
	{
		NavigationListView = new ListView();
		SuspendLayout();
		// 
		// NavigationListView
		// 
		NavigationListView.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
		NavigationListView.Location = new Point(3, 31);
		NavigationListView.Margin = new Padding(1, 3, 1, 3);
		NavigationListView.MultiSelect = false;
		NavigationListView.Name = "NavigationListView";
		NavigationListView.Size = new Size(144, 407);
		NavigationListView.TabIndex = 0;
		NavigationListView.UseCompatibleStateImageBehavior = false;
		NavigationListView.View = View.List;
		NavigationListView.SelectedIndexChanged += NavigationListView_SelectedIndexChanged;
		// 
		// CreatorForm
		// 
		AutoScaleDimensions = new SizeF(7F, 15F);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(800, 450);
		Controls.Add(NavigationListView);
		Name = "CreatorForm";
		Text = "CreatorForm";
		ResumeLayout(false);
	}

	#endregion

	private ListView NavigationListView;
}