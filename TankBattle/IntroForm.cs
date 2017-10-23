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
    public partial class IntroForm : Form
    {
        public IntroForm()
        {
            InitializeComponent();
        }

        private void NewGameButton_Click(object sender, EventArgs e)
        {
            Gameplay game = new Gameplay(2, 1);
            Opponent player1 = new HumanOpponent("Player 1", TankModel.GetTank(1), Gameplay.GetTankColour(1));
            Opponent player2 = new HumanOpponent("Player 2", TankModel.GetTank(1), Gameplay.GetTankColour(2));
            game.SetPlayer(1, player1);
            game.SetPlayer(2, player2);
            game.NewGame();
        }
    }
}
