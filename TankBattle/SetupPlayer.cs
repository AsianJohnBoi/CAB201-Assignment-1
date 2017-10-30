using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TankBattle
{
	public partial class setupPlayerForm : Form
	{
		private int playerAmount, roundAmount, player = 1;
		private List<string> playerNames = new List<string>();

		public setupPlayerForm(int playerAmount, int roundAmount)
		{
			this.playerAmount = playerAmount;
			this.roundAmount = roundAmount;
			InitializeComponent();
		}

		private void setupPlayerForm_Load(object sender, EventArgs e)
		{
			BackColor = Gameplay.GetTankColour(player);
			nextPlayerButton.Enabled = false;
		}

		private void playerNameInput_TextChanged(object sender, EventArgs e)
		{
			if (String.IsNullOrEmpty(playerNameInput.Text))
				nextPlayerButton.Enabled = false;
			else
			{
				nextPlayerButton.Enabled = true;
			}
		}

		private void nextPlayerButton_Click(object sender, EventArgs e)
		{
			playerNames.Add(playerNameInput.Text);
			if (player != playerAmount)
			{ 
				player++;
				PlayerLabel.Text = "Player #" + player + "'s name:";
				playerNameInput.Clear();
				BackColor = Gameplay.GetTankColour(player);
				nextPlayerButton.Enabled = false;
			}
			else if (player == playerAmount)
			{
				Gameplay game = new Gameplay(playerAmount, roundAmount);

				for (int i = 0; i < playerAmount; i++)
				{
					Opponent a = new HumanOpponent(playerNames[i], TankModel.GetTank(1), Gameplay.GetTankColour(i+1));
					game.SetPlayer(i + 1, a);
				}
				game.NewGame();
				Close();
			}
		}
	}
}
