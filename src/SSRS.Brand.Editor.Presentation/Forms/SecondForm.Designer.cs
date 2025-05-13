namespace SSRS.Brand.Editor.Presentation.Forms;

partial class SecondForm
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
		SecondFormLabel = new Label();
		SuspendLayout();
		// 
		// SecondFormLabel
		// 
		SecondFormLabel.AutoSize = true;
		SecondFormLabel.Dock = DockStyle.Fill;
		SecondFormLabel.Location = new Point(0, 0);
		SecondFormLabel.Name = "SecondFormLabel";
		SecondFormLabel.Size = new Size(59, 25);
		SecondFormLabel.TabIndex = 0;
		SecondFormLabel.Text = "label1";
		SecondFormLabel.TextAlign = ContentAlignment.MiddleCenter;
		// 
		// SecondForm
		// 
		AutoScaleDimensions = new SizeF(10F, 25F);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(800, 450);
		Controls.Add(SecondFormLabel);
		Name = "SecondForm";
		StartPosition = FormStartPosition.CenterParent;
		Text = "SecondForm";
		ResumeLayout(false);
		PerformLayout();
	}

	#endregion

	private Label SecondFormLabel;
}