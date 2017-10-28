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

            Opponent player1 = new HumanOpponent("Player 1", TankModel.GetTank(1), Gameplay.GetTankColour(1));
            Opponent player2 = new HumanOpponent("Player 2", TankModel.GetTank(1), Gameplay.GetTankColour(2));

            game.SetPlayer(1, player1);
            game.SetPlayer(2, player2);

            game.NewGame();

        }
    }
}
