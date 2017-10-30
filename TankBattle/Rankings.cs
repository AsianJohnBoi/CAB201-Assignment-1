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
                string scoreStr = (opponent[i].Name() + "(" + score.ToString() + "wins)");
                scores.Add(scoreStr);

            }

            scores.OrderBy(num => num).ToList();
            listBox1.DataSource = scores;

            whoWon.Text = scores[0] + "Won!";
        }
    }
}
