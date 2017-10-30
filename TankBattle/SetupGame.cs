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
    /// <summary>
    /// 
    /// This is the game setup screen. The amount of players and
    /// rounds can be set here.
    /// 
    /// Author John Santias and Hoang Nguyen October 2017
    /// 
    /// </summary>
	public partial class setupGameForm : Form
	{
		private int playerAmount, roundAmount;

		public setupGameForm()
		{
			InitializeComponent();
		}

        /// <summary>
        /// 
        /// When the user presses this button, the setup player form will appear.
        /// 
        /// Author John Santias and Hoang Nguyen October 2017
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void setupPlayersButton_Click(object sender, EventArgs e)
		{
            playerAmount = (int)playerAmountInput.Value;
            roundAmount = (int)roundAmountInput.Value;
			Hide();
			setupPlayerForm setupPlayer = new setupPlayerForm(playerAmount, roundAmount);
			setupPlayer.Show();
		}
	}
}
