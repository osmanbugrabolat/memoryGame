namespace memoryGame
{
	partial class Game
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
			lblOyuncu1 = new Label();
			lblOyuncu2 = new Label();
			lblZaman = new Label();
			lblPlayer1Score = new Label();
			lblPlayer2Score = new Label();
			SuspendLayout();
			// 
			// lblOyuncu1
			// 
			lblOyuncu1.AutoSize = true;
			lblOyuncu1.BackColor = Color.Transparent;
			lblOyuncu1.Font = new Font("Segoe UI", 15F);
			lblOyuncu1.Location = new Point(28, 9);
			lblOyuncu1.Name = "lblOyuncu1";
			lblOyuncu1.Size = new Size(76, 28);
			lblOyuncu1.TabIndex = 0;
			lblOyuncu1.Text = "Player1";
			lblOyuncu1.Click += lblOyuncu1_Click;
			// 
			// lblOyuncu2
			// 
			lblOyuncu2.AutoSize = true;
			lblOyuncu2.Font = new Font("Segoe UI", 15F);
			lblOyuncu2.Location = new Point(702, 7);
			lblOyuncu2.Name = "lblOyuncu2";
			lblOyuncu2.Size = new Size(76, 28);
			lblOyuncu2.TabIndex = 1;
			lblOyuncu2.Text = "Player2";
			lblOyuncu2.Click += lblOyuncu2_Click;
			// 
			// lblZaman
			// 
			lblZaman.AutoSize = true;
			lblZaman.Font = new Font("Segoe UI", 15F);
			lblZaman.Location = new Point(370, 9);
			lblZaman.Name = "lblZaman";
			lblZaman.Size = new Size(51, 28);
			lblZaman.TabIndex = 2;
			lblZaman.Text = "Süre";
			// 
			// lblPlayer1Score
			// 
			lblPlayer1Score.AutoSize = true;
			lblPlayer1Score.Font = new Font("Segoe UI", 12F);
			lblPlayer1Score.Location = new Point(40, 54);
			lblPlayer1Score.Name = "lblPlayer1Score";
			lblPlayer1Score.Size = new Size(52, 21);
			lblPlayer1Score.TabIndex = 3;
			lblPlayer1Score.Text = "Score:";
			lblPlayer1Score.Click += lblPlayer1Score_Click;
			// 
			// lblPlayer2Score
			// 
			lblPlayer2Score.AutoSize = true;
			lblPlayer2Score.Font = new Font("Segoe UI", 12F);
			lblPlayer2Score.Location = new Point(713, 54);
			lblPlayer2Score.Name = "lblPlayer2Score";
			lblPlayer2Score.Size = new Size(52, 21);
			lblPlayer2Score.TabIndex = 4;
			lblPlayer2Score.Text = "Score:";
			// 
			// Game
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(843, 717);
			Controls.Add(lblPlayer2Score);
			Controls.Add(lblPlayer1Score);
			Controls.Add(lblZaman);
			Controls.Add(lblOyuncu2);
			Controls.Add(lblOyuncu1);
			Name = "Game";
			Text = "Game";
			Load += Game_Load;
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private Label lblOyuncu1;
		private Label lblOyuncu2;
		private Label lblZaman;
		private Label lblPlayer1Score;
		private Label lblPlayer2Score;
	}
}