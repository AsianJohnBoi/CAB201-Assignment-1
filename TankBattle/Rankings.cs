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
        private int numPlayers, highestScore;
        private Opponent[] opponent;
        private List<string> scores = new List<string>();
        private List<int> compareScores = new List<int>();

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

            // Go through all players adding their scores and names to a list
			for (int i = 0; i < numPlayers; i++)
			{
				int score = opponent[i].GetScore();
                compareScores.Add(score);

                string scoreStr = (score.ToString() + " Win/s - " + opponent[i].Name());
				scores.Add(scoreStr);
			}

            // Scores list is sorted in descending order
			scores.Sort();
			scores.Reverse();

            // Display list items in listBox
			listBox1.DataSource = scores;

            // Compare scores list is sorted in descending order
            compareScores.Sort();
            compareScores.Reverse();

            // Get the highest score by using first index
            highestScore = compareScores[0];

            // Display winner's name on top of box depending on comparison of scores
            for (int i = 1; i < compareScores.Count - 1; i++) 
            {
                if (highestScore == compareScores[i]) 
                {
                    whoWon.Text = "It's a tie!";
                    break;
                } 
                else 
                {
                    whoWon.Text = scores[0] + " Won!";
                }
            }
        }
    }
}
