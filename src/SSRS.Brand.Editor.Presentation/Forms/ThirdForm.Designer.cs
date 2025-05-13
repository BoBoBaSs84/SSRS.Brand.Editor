namespace SSRS.Brand.Editor.Presentation.Forms;

partial class ThirdForm
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
		ThirdFormLabel = new Label();
		SuspendLayout();
		// 
		// ThirdFormLabel
		// 
		ThirdFormLabel.AutoSize = true;
		ThirdFormLabel.Dock = DockStyle.Fill;
		ThirdFormLabel.Location = new Point(0, 0);
		ThirdFormLabel.Name = "ThirdFormLabel";
		ThirdFormLabel.Size = new Size(59, 25);
		ThirdFormLabel.TabIndex = 0;
		ThirdFormLabel.Text = "label1";
		ThirdFormLabel.TextAlign = ContentAlignment.MiddleCenter;
		// 
		// ThirdForm
		// 
		AutoScaleDimensions = new SizeF(10F, 25F);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(800, 450);
		Controls.Add(ThirdFormLabel);
		Name = "ThirdForm";
		StartPosition = FormStartPosition.CenterParent;
		Text = "ThirdForm";
		ResumeLayout(false);
		PerformLayout();
	}

	#endregion

	private Label ThirdFormLabel;
}