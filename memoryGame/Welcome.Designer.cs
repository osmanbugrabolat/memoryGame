namespace memoryGame
{
	partial class Welcome
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Welcome));
			button1 = new Button();
			label1 = new Label();
			label2 = new Label();
			SuspendLayout();
			// 
			// button1
			// 
			button1.BackColor = Color.FromArgb(0, 192, 0);
			button1.Font = new Font("Segoe UI", 15F);
			button1.Location = new Point(186, 363);
			button1.Name = "button1";
			button1.Size = new Size(176, 63);
			button1.TabIndex = 0;
			button1.Text = "Başla";
			button1.UseVisualStyleBackColor = false;
			button1.Click += button1_Click;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Font = new Font("Segoe UI", 9F);
			label1.Location = new Point(12, 78);
			label1.Name = "label1";
			label1.Size = new Size(560, 255);
			label1.TabIndex = 1;
			label1.Text = resources.GetString("label1.Text");
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.BackColor = Color.Transparent;
			label2.Font = new Font("Segoe UI", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 162);
			label2.Location = new Point(186, 9);
			label2.Name = "label2";
			label2.Size = new Size(189, 37);
			label2.TabIndex = 2;
			label2.Text = "Hafıza Oyunu";
			// 
			// Welcome
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(582, 450);
			Controls.Add(label2);
			Controls.Add(label1);
			Controls.Add(button1);
			Name = "Welcome";
			Text = "Form1";
			Load += Welcome_Load;
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Button button1;
		private Label label1;
		private Label label2;
	}
}
