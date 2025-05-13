namespace SSRS.Brand.Editor.Presentation.Forms;

partial class FirstForm
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
		FirstFormLabel = new Label();
		SuspendLayout();
		// 
		// FirstFormLabel
		// 
		FirstFormLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
		FirstFormLabel.AutoSize = true;
		FirstFormLabel.Location = new Point(729, 416);
		FirstFormLabel.Name = "FirstFormLabel";
		FirstFormLabel.Size = new Size(59, 25);
		FirstFormLabel.TabIndex = 0;
		FirstFormLabel.Text = "label1";
		FirstFormLabel.TextAlign = ContentAlignment.MiddleCenter;
		// 
		// FirstForm
		// 
		AutoScaleDimensions = new SizeF(10F, 25F);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(800, 450);
		Controls.Add(FirstFormLabel);
		Name = "FirstForm";
		StartPosition = FormStartPosition.CenterParent;
		Text = "FirstForm";
		ResumeLayout(false);
		PerformLayout();
	}

	#endregion

	private Label FirstFormLabel;
}
