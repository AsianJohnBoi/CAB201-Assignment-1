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
	public partial class setupPlayerForm : Form
	{
		private int playerAmount, roundAmount;
		private int player = 0;
		private List<string> playerNames = new List<string>();

		private void label1_Click(object sender, EventArgs e)
		{

		}

		public setupPlayerForm(int playerAmount, int roundAmount)
		{
			this.playerAmount = playerAmount;
			this.roundAmount = roundAmount;
			InitializeComponent();
		}

		private void nextPlayerButton_Click(object sender, EventArgs e)
		{
			if (player < playerAmount)
			{
				PlayerLabel.Text = "Player #" + (player + 1) + "'s name:";
				playerNames.Add(playerNameInput.Text);
				playerNameInput.Clear();
				player++;
			}
			else
			{
				Gameplay game = new Gameplay(playerAmount, roundAmount);

				for (int i = 0; i < playerAmount; i++)
				{
					Opponent player = new HumanOpponent(playerNames[i], TankModel.GetTank(i + 1), Gameplay.GetTankColour(i + 1));
					game.SetPlayer(i + 1, player);
				}
				game.NewGame();
				Close();
			}
			
		}
	}
}
