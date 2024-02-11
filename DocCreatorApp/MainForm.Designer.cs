namespace DocCreatorApp
{
	partial class MainForm
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
			textBox1 = new TextBox();
			createButton = new Button();
			SuspendLayout();
			// 
			// textBox1
			// 
			textBox1.Location = new Point(189, 192);
			textBox1.Name = "textBox1";
			textBox1.Size = new Size(165, 23);
			textBox1.TabIndex = 0;
			// 
			// createButton
			// 
			createButton.Location = new Point(332, 310);
			createButton.Name = "createButton";
			createButton.Size = new Size(118, 27);
			createButton.TabIndex = 1;
			createButton.Text = "Create Document";
			createButton.UseVisualStyleBackColor = true;
			createButton.Click += createButton_Click;
			// 
			// MainForm
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(800, 450);
			Controls.Add(createButton);
			Controls.Add(textBox1);
			Name = "MainForm";
			Text = "MainForm";
			Load += MainForm_Load;
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private TextBox textBox1;
		private Button createButton;
	}
}