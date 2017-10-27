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
    public partial class SetupGameForm : Form {
        public SetupGameForm() {
            InitializeComponent();
        }

        // Public variables
        public int setupPlayerAmount, setupRoundAmount;

        private void setupPlayersButton_Click(object sender, EventArgs e) {
            // Retrieve game setup input
            setupPlayerAmount = (int)playerAmountInput.Value;
            setupRoundAmount = (int)roundAmountInput.Value;

            SetupPlayerForm setupPlayer = new SetupPlayerForm();
            setupPlayer.Show();
        }

        public int getPlayerAmount() {
            return setupPlayerAmount;
        }

        public int getRoundAmount() {
            return setupRoundAmount;
        }
    }
}
