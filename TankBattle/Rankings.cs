using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TankBattle
{
	public partial class Rankings : Form
	{
		private int numPlayers;
		private Opponent[] opponent;

		public Rankings(int numPlayers, Opponent[] opponent)
		{
			this.numPlayers = numPlayers;
			this.opponent = opponent;
			List<string> scores = new List<string>();
			for (int i = 0; i < numPlayers; i++)
			{
				int score = opponent[i].GetScore();
				string scoreStr = score.ToString();
				scores.Add(opponent[i].Name() + "(" + scoreStr + "wins)");
			}
			scores.OrderBy(num => num).ToList();

			for (int i = 0; i < scores.Count; i++)
			{
				listBox1.Items.Add(scores[i]);
			}

			whoWon.Text = scores[0] + "Won!";

			InitializeComponent();
		}

		private void closeButton_Click(object sender, EventArgs e)
		{
			Close();
		}
	}
}
