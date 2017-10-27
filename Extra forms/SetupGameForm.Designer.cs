namespace TankBattle {
    partial class SetupGameForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.playerAmountLabel = new System.Windows.Forms.Label();
            this.gameplayAmountLabel = new System.Windows.Forms.Label();
            this.setupPlayersButton = new System.Windows.Forms.Button();
            this.playerAmountInput = new System.Windows.Forms.NumericUpDown();
            this.roundAmountInput = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.playerAmountInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.roundAmountInput)).BeginInit();
            this.SuspendLayout();
            // 
            // playerAmountLabel
            // 
            this.playerAmountLabel.AutoSize = true;
            this.playerAmountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playerAmountLabel.Location = new System.Drawing.Point(57, 47);
            this.playerAmountLabel.Name = "playerAmountLabel";
            this.playerAmountLabel.Size = new System.Drawing.Size(524, 51);
            this.playerAmountLabel.TabIndex = 0;
            this.playerAmountLabel.Text = "How many players? (2-8)";
            // 
            // gameplayAmountLabel
            // 
            this.gameplayAmountLabel.AutoSize = true;
            this.gameplayAmountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameplayAmountLabel.Location = new System.Drawing.Point(57, 155);
            this.gameplayAmountLabel.Name = "gameplayAmountLabel";
            this.gameplayAmountLabel.Size = new System.Drawing.Size(616, 51);
            this.gameplayAmountLabel.TabIndex = 1;
            this.gameplayAmountLabel.Text = "How many gameplay rounds?";
            // 
            // setupPlayersButton
            // 
            this.setupPlayersButton.Location = new System.Drawing.Point(66, 250);
            this.setupPlayersButton.Name = "setupPlayersButton";
            this.setupPlayersButton.Size = new System.Drawing.Size(754, 67);
            this.setupPlayersButton.TabIndex = 2;
            this.setupPlayersButton.Text = "Setup Players";
            this.setupPlayersButton.UseVisualStyleBackColor = true;
            this.setupPlayersButton.Click += new System.EventHandler(this.setupPlayersButton_Click);
            // 
            // playerAmountInput
            // 
            this.playerAmountInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playerAmountInput.Location = new System.Drawing.Point(700, 45);
            this.playerAmountInput.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.playerAmountInput.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.playerAmountInput.Name = "playerAmountInput";
            this.playerAmountInput.Size = new System.Drawing.Size(120, 56);
            this.playerAmountInput.TabIndex = 3;
            this.playerAmountInput.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // roundAmountInput
            // 
            this.roundAmountInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roundAmountInput.Location = new System.Drawing.Point(700, 155);
            this.roundAmountInput.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.roundAmountInput.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.roundAmountInput.Name = "roundAmountInput";
            this.roundAmountInput.Size = new System.Drawing.Size(120, 56);
            this.roundAmountInput.TabIndex = 4;
            this.roundAmountInput.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // SetupGameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(890, 357);
            this.Controls.Add(this.roundAmountInput);
            this.Controls.Add(this.playerAmountInput);
            this.Controls.Add(this.setupPlayersButton);
            this.Controls.Add(this.gameplayAmountLabel);
            this.Controls.Add(this.playerAmountLabel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SetupGameForm";
            this.ShowIcon = false;
            this.Text = "Setup Game";
            ((System.ComponentModel.ISupportInitialize)(this.playerAmountInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.roundAmountInput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label playerAmountLabel;
        private System.Windows.Forms.Label gameplayAmountLabel;
        private System.Windows.Forms.Button setupPlayersButton;
        private System.Windows.Forms.NumericUpDown playerAmountInput;
        private System.Windows.Forms.NumericUpDown roundAmountInput;
    }
}