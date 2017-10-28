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
        public IntroForm()
        {
            InitializeComponent();
        }

        private void NewGameButton_Click(object sender, EventArgs e)
        {
            //         Gameplay game = new Gameplay(2, 1);
            //         Opponent player1 = new HumanOpponent("Player 1", TankModel.GetTank(1), Gameplay.GetTankColour(1));
            //         Opponent player2 = new HumanOpponent("Player 2", TankModel.GetTank(1), Gameplay.GetTankColour(2));
            ////Opponent player3 = new HumanOpponent("Player 2", TankModel.GetTank(1), Gameplay.GetTankColour(2));
            ////Opponent player4 = new HumanOpponent("Player 1", TankModel.GetTank(1), Gameplay.GetTankColour(1));
            //         //Opponent player5 = new HumanOpponent("Player 2", TankModel.GetTank(1), Gameplay.GetTankColour(2));
            ////Opponent player6 = new HumanOpponent("Player 2", TankModel.GetTank(1), Gameplay.GetTankColour(2));
            ////Opponent player7 = new HumanOpponent("Player 2", TankModel.GetTank(1), Gameplay.GetTankColour(2));
            ////Opponent player8 = new HumanOpponent("Player 2", TankModel.GetTank(1), Gameplay.GetTankColour(2));

            //         game.SetPlayer(1, player1);
            //         game.SetPlayer(2, player2);
            ////game.SetPlayer(3, player2);
            ////game.SetPlayer(4, player1);
            //         //game.SetPlayer(5, player2);
            ////game.SetPlayer(6, player2);
            ////game.SetPlayer(7, player1);
            //         //game.SetPlayer(8, player2);
            //         game.NewGame();

            setupGameForm setupGame = new setupGameForm();

            setupGame.Show();

        }
    }
}
