using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace TankBattle
{
    public partial class IntroForm : Form
    {
		/// <summary>
		/// Title screen. The first thing you'll see upon loading the game. 
		/// </summary>
        public IntroForm()
        {
            InitializeComponent();
        }

		/// <summary>
		/// When the user presses the button, a new form will show up for the user to select
		/// how many players will be playing and how many rounds.
		/// 
		/// Author John Santias and Hoang Nguyen October 2017
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void NewGameButton_Click(object sender, EventArgs e)
        {
            setupGameForm setupGame = new setupGameForm();
            setupGame.Show();

        }
    }
}
