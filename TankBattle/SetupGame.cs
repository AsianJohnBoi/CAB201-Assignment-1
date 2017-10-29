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
	public partial class setupGameForm : Form
	{
		public setupGameForm()
		{
			InitializeComponent();
		}

        private int playerAmount, roundAmount;

        private void setupPlayersButton_Click(object sender, EventArgs e) {
            playerAmount = (int)playerAmountInput.Value;
            roundAmount = (int)roundAmountInput.Value;

            Gameplay game = new Gameplay(playerAmount, roundAmount);

			for (int i = 0; i < playerAmount; i++)
			{
				Opponent player = new HumanOpponent("Player" + (i + 1), TankModel.GetTank(i+1), Gameplay.GetTankColour(i+1));
				game.SetPlayer(i+1, player);
			}
            game.NewGame();

        }
    }
}
