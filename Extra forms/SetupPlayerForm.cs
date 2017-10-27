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
    public partial class SetupPlayerForm : Form {
        public SetupPlayerForm() {
            InitializeComponent();
        }

        private Gameplay game;
        //private SetupGameForm setupGame;

        private int playerAmount, roundAmount;

        //public Opponent[] players;

        private void nextPlayerButton_Click(object sender, EventArgs e) {

            //setupGame = new SetupGameForm();

            //playerAmount = setupGame.getPlayerAmount();
            //roundAmount = setupGame.getRoundAmount();

            //game = new Gameplay(playerAmount, roundAmount);

            //players = new Opponent[setupGame.playerAmount];

            //for (int i = 0; i < players.Length; i++) {
            //    players[i] = new HumanOpponent("Player " + i, TankModel.GetTank(1), Gameplay.GetTankColour(1));
            //}

            //for (int i = 0; i < players.Length; i++) {
            //    game.SetPlayer(i + 1, players[i]);
            //}

            game = new Gameplay(2, 1);

            Opponent player1 = new HumanOpponent("Player 1", TankModel.GetTank(1), Gameplay.GetTankColour(1));
            Opponent player2 = new HumanOpponent("Player 2", TankModel.GetTank(1), Gameplay.GetTankColour(2));

            game.SetPlayer(1, player1);
            game.SetPlayer(2, player2);

            game.NewGame();
        }
    }
}
