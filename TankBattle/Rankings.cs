using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TankBattle {
	/// <summary>
	/// Windows form application. Opens after game is finished. Shows the scoreboard and who won.
	/// 
	/// Author John Santias and Hoang Nguyen October 2017
	/// </summary>
	public partial class Rankings : Form {
        private int numPlayers;
        private Opponent[] opponent;
        private List<string> scores = new List<string>();

		/// <summary>
		/// Constructor, gets the number of players in the game and the list of opponents.
		/// They're set on to the private fields.
		/// 
		/// Author John Santias and Hoang Nguyen October 2017
		/// </summary>
		/// <param name="numPlayers"></param>
		/// <param name="opponent"></param>
		public Rankings(int numPlayers, Opponent[] opponent) {
            this.numPlayers = numPlayers;
            this.opponent = opponent;

            InitializeComponent();
        }

		/// <summary>
		/// The button closes this Form when clicked.
		/// 
		/// Author John Santias and Hoang Nguyen October 2017
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void closeButton_Click(object sender, EventArgs e) {
            Close();
        }

		/// <summary>
		/// Loads all the players, their scores and adds to the ListBox on the form in descending order.
		/// 
		/// Author John Santias and Hoang Nguyen October 2017
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Rankings_Load(object sender, EventArgs e) {

			for (int i = 0; i < numPlayers; i++)
			{
				int score = opponent[i].GetScore();
				string scoreStr = (score.ToString() + " Win/s - " + opponent[i].Name());
				scores.Add(scoreStr);
			}

			scores.Sort();
			scores.Reverse();
			listBox1.DataSource = scores;

			whoWon.Text = scores[0] + " Won!";
		}
    }
}
