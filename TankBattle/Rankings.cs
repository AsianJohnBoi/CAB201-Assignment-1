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

        public Rankings(int numPlayers, Opponent[] opponent) {
            this.numPlayers = numPlayers;
            this.opponent = opponent;

            InitializeComponent();
        }

        private void closeButton_Click(object sender, EventArgs e) {
            Close();
        }

        private void Rankings_Load(object sender, EventArgs e) {

            for (int i = 0; i < numPlayers; i++) {
                int score = opponent[i].GetScore();
                string scoreStr = (score.ToString() + " - " + opponent[i].Name());
                scores.Add(scoreStr);

                Console.WriteLine(scoreStr);

            }

            scores.Sort();
            scores.Reverse();
            listBox1.DataSource = scores;

            whoWon.Text = scores[0] + " Won!";
        }
    }
}
