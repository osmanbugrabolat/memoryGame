using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace memoryGame
{
	public partial class Game : Form
	{
		private List<PictureBox> pictureBoxes = new List<PictureBox>();
		private Dictionary<PictureBox, string> pictureBoxImages = new Dictionary<PictureBox, string>();
		private PictureBox firstPictureBox = null;
		private PictureBox secondPictureBox = null;
		private Timer gameTimer;
		private Timer revealTimer;
		private Timer initialShowTimer;
		private int totalTime = 5 * 60;
		private int player1Score = 0;
		private int player2Score = 0;
		private int currentPlayer = 1;
		private bool isChecking = false;

		public Game()
		{
			InitializeComponent();
		}

		private void Game_Load(object sender, EventArgs e)
		{
			LoadImages();
			InitializePictureBoxes();
			ShowAllImagesInitially();
			StartGameTimer();
			UpdatePlayerLabelColors();
		}

		private void LoadImages()
		{
			string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
			string folderPath = System.IO.Path.Combine(desktopPath, "Memory");
			var images = System.IO.Directory.GetFiles(folderPath, "*.png");

			images = images.Concat(images).OrderBy(x => Guid.NewGuid()).ToArray();

			for (int i = 0; i < images.Length; i++)
			{
				PictureBox pictureBox = new PictureBox();
				pictureBox.Width = 100;
				pictureBox.Height = 100;
				pictureBox.Tag = images[i];
				pictureBox.BackColor = Color.DarkGreen;
				pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
				pictureBox.Click += PictureBox_Click;
				pictureBoxes.Add(pictureBox);
				pictureBoxImages[pictureBox] = images[i];
				this.Controls.Add(pictureBox);
				PositionPictureBox(pictureBox, i);
			}
		}

		private void InitializePictureBoxes()
		{
			foreach (PictureBox pictureBox in pictureBoxes)
			{
				pictureBox.Image = null;
			}
		}

		private void ShowAllImagesInitially()
		{
			foreach (var pictureBox in pictureBoxes)
			{
				string imagePath = pictureBoxImages[pictureBox];
				if (System.IO.File.Exists(imagePath))
				{
					pictureBox.Image = Image.FromFile(imagePath);
				}
			}

			initialShowTimer = new Timer();
			initialShowTimer.Interval = 5000;
			initialShowTimer.Tick += (s, e) =>
			{
				HideAllImages();
				initialShowTimer.Stop();
			};
			initialShowTimer.Start();
		}

		private void StartGameTimer()
		{
			gameTimer = new Timer();
			gameTimer.Interval = 1000;
			gameTimer.Tick += GameTimer_Tick;
			gameTimer.Start();

			revealTimer = new Timer();
			revealTimer.Interval = 5000;
			revealTimer.Tick += RevealTimer_Tick;
		}

		private void GameTimer_Tick(object sender, EventArgs e)
		{
			totalTime--;
			lblZaman.Text = $"Süre: {totalTime / 60}:{totalTime % 60:D2}";

			if (totalTime <= 0)
			{
				gameTimer.Stop();
				DetermineWinner();
			}
		}

		private void PictureBox_Click(object sender, EventArgs e)
		{
			if (isChecking || initialShowTimer.Enabled) return;

			PictureBox clickedPictureBox = sender as PictureBox;
			if (clickedPictureBox.Image != null) return;

			string imagePath = pictureBoxImages[clickedPictureBox];

			if (System.IO.File.Exists(imagePath))
			{
				clickedPictureBox.Image = Image.FromFile(imagePath);
			}

			if (firstPictureBox == null)
			{
				firstPictureBox = clickedPictureBox;
				revealTimer.Start();
			}
			else if (secondPictureBox == null)
			{
				secondPictureBox = clickedPictureBox;
				revealTimer.Stop();
				CheckForMatch();
			}
		}

		private void CheckForMatch()
		{
			isChecking = true;

			if (firstPictureBox.Tag.ToString() == secondPictureBox.Tag.ToString())
			{
				firstPictureBox = null;
				secondPictureBox = null;
				isChecking = false;

				if (currentPlayer == 1)
					player1Score++;
				else
					player2Score++;

				UpdateScores();

				if (pictureBoxes.All(p => p.Image != null))
				{
					gameTimer.Stop();
					DetermineWinner();
				}
			}
			else
			{
				Timer delayTimer = new Timer();
				delayTimer.Interval = 1000;
				delayTimer.Tick += (s, e) =>
				{
					delayTimer.Stop();
					firstPictureBox.Image = null;
					secondPictureBox.Image = null;
					firstPictureBox = null;
					secondPictureBox = null;
					isChecking = false;

					currentPlayer = currentPlayer == 1 ? 2 : 1;
					UpdatePlayerLabelColors();
				};
				delayTimer.Start();
			}
		}

		private void RevealTimer_Tick(object sender, EventArgs e)
		{
			revealTimer.Stop();

			if (firstPictureBox != null)
			{
				firstPictureBox.Image = null;
				firstPictureBox = null;
				currentPlayer = currentPlayer == 1 ? 2 : 1;
				UpdatePlayerLabelColors();
			}
		}

		private void HideAllImages()
		{
			foreach (var pictureBox in pictureBoxes)
			{
				pictureBox.Image = null;
			}
		}

		private void PositionPictureBox(PictureBox pictureBox, int index)
		{
			int startX = 100;
			int startY = 100;
			int x = (index % 4) * 110 + startX;
			int y = (index / 4) * 110 + startY;
			pictureBox.Location = new Point(x, y);
		}

		private void UpdateScores()
		{
			lblPlayer1Score.Text = $"Oyuncu 1 Skor: {player1Score}";
			lblPlayer2Score.Text = $"Oyuncu 2 Skor: {player2Score}";
		}

		private void UpdatePlayerLabelColors()
		{
			lblOyuncu1.ForeColor = currentPlayer == 1 ? Color.Green : Color.Red;
			lblOyuncu2.ForeColor = currentPlayer == 2 ? Color.Green : Color.Red;
		}

		private void DetermineWinner()
		{
			string message;
			if (player1Score > player2Score)
			{
				message = "Tebrikler! Oyuncu 1 Kazandı!";
			}
			else if (player2Score > player1Score)
			{
				message = "Tebrikler! Oyuncu 2 Kazandı!";
			}
			else
			{
				message = "Berabere!";
			}
			MessageBox.Show(message);
			this.Close();
		}

		private void lblOyuncu1_Click(object sender, EventArgs e)
		{
			
		}

		private void lblOyuncu2_Click(object sender, EventArgs e)
		{
			
		}

		private void lblPlayer1Score_Click(object sender, EventArgs e)
		{

		}
	}
}
