using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TankBattle {
    /// <summary>
    /// 
    /// This is the player setup form. The player's can set their names
    /// controller and tank types.
    /// 
    /// Author John Santias and Hoang Nguyen October 2017
    /// 
    /// </summary>
	public partial class setupPlayerForm : Form {
        private int playerAmount, roundAmount;
        private int player = 1;
        private List<string> playerNames = new List<string>();

        /// <summary>
        /// 
        /// This constructor takes in the player amount and round amount
        /// specified in the setup game form.
        /// 
        /// Author John Santias and Hoang Nguyen October 2017
        ///     
        /// </summary>
        /// <param name="playerAmount"> Amount of players </param>
        /// <param name="roundAmount"> Amount of rounds </param>
		public setupPlayerForm(int playerAmount, int roundAmount) {
            this.playerAmount = playerAmount;
            this.roundAmount = roundAmount;
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// When the form is loaded, the BackColor of the form is changed
        /// accordingly to their assigned tank colour.
        /// 
        /// Author John Santias and Hoang Nguyen October 2017
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void setupPlayerForm_Load(object sender, EventArgs e) {
            BackColor = Gameplay.GetTankColour(player);
            nextPlayerButton.Enabled = false;
        }

        /// <summary>
        /// 
        /// The next player button is disabled until a value in 
        /// the player name text box is not null.
        ///
        /// Author John Santias and Hoang Nguyen October 2017
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void playerNameInput_TextChanged(object sender, EventArgs e) {
            if (String.IsNullOrEmpty(playerNameInput.Text))
                nextPlayerButton.Enabled = false;
            else {
                nextPlayerButton.Enabled = true;
            }
        }

        /// <summary>
        /// 
        /// When this button is pressed, the next player can select their
        /// name, tank and controller. When all players have selected their loadouts
        /// the game will begin.
        /// 
        /// Author John Santias and Hoang Nguyen October 2017
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		private void nextPlayerButton_Click(object sender, EventArgs e) {

            playerNames.Add(playerNameInput.Text);

            // If not all players have not assign player name, tank types and controller 
            if (player != playerAmount) {
                player++;
                PlayerLabel.Text = "Player #" + player + "'s name:";
                playerNameInput.Clear();
                BackColor = Gameplay.GetTankColour(player);
                nextPlayerButton.Enabled = false;

            // If all players have put in their details, game starts
            } else if (player == playerAmount) {
                Gameplay game = new Gameplay(playerAmount, roundAmount);

                for (int i = 0; i < playerAmount; i++) {
                    Opponent a = new HumanOpponent(playerNames[i], TankModel.GetTank(1), Gameplay.GetTankColour(i + 1));
                    game.SetPlayer(i + 1, a);
                }
                game.NewGame();
                Close();
            }
        }
    }
}
