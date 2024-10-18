namespace memoryGame
{
	public partial class Welcome : Form
	{
		public Welcome()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			Game game = new Game();

			game.Show();

			this.Hide();
		}

		private void Welcome_Load(object sender, EventArgs e)
		{

		}
	}
}
