namespace TankBattle {
    partial class SetupPlayerForm {
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
            this.playerNameLabel = new System.Windows.Forms.Label();
            this.playerNameTextBox = new System.Windows.Forms.TextBox();
            this.nextPlayerButton = new System.Windows.Forms.Button();
            this.controllerGroupBox = new System.Windows.Forms.GroupBox();
            this.tankGroupBox = new System.Windows.Forms.GroupBox();
            this.tank1RadioButton = new System.Windows.Forms.RadioButton();
            this.humanRadioButton = new System.Windows.Forms.RadioButton();
            this.aiRadioButton = new System.Windows.Forms.RadioButton();
            this.controllerGroupBox.SuspendLayout();
            this.tankGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // playerNameLabel
            // 
            this.playerNameLabel.AutoSize = true;
            this.playerNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playerNameLabel.Location = new System.Drawing.Point(101, 79);
            this.playerNameLabel.Name = "playerNameLabel";
            this.playerNameLabel.Size = new System.Drawing.Size(326, 42);
            this.playerNameLabel.TabIndex = 0;
            this.playerNameLabel.Text = "playerNameLabel";
            // 
            // playerNameTextBox
            // 
            this.playerNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playerNameTextBox.Location = new System.Drawing.Point(468, 79);
            this.playerNameTextBox.Name = "playerNameTextBox";
            this.playerNameTextBox.Size = new System.Drawing.Size(417, 49);
            this.playerNameTextBox.TabIndex = 1;
            // 
            // nextPlayerButton
            // 
            this.nextPlayerButton.Location = new System.Drawing.Point(108, 280);
            this.nextPlayerButton.Name = "nextPlayerButton";
            this.nextPlayerButton.Size = new System.Drawing.Size(777, 82);
            this.nextPlayerButton.TabIndex = 2;
            this.nextPlayerButton.Text = "Next Player";
            this.nextPlayerButton.UseVisualStyleBackColor = true;
            this.nextPlayerButton.Click += new System.EventHandler(this.nextPlayerButton_Click);
            // 
            // controllerGroupBox
            // 
            this.controllerGroupBox.Controls.Add(this.aiRadioButton);
            this.controllerGroupBox.Controls.Add(this.humanRadioButton);
            this.controllerGroupBox.Location = new System.Drawing.Point(108, 170);
            this.controllerGroupBox.Name = "controllerGroupBox";
            this.controllerGroupBox.Size = new System.Drawing.Size(217, 73);
            this.controllerGroupBox.TabIndex = 3;
            this.controllerGroupBox.TabStop = false;
            this.controllerGroupBox.Text = "Controller";
            // 
            // tankGroupBox
            // 
            this.tankGroupBox.Controls.Add(this.tank1RadioButton);
            this.tankGroupBox.Location = new System.Drawing.Point(468, 170);
            this.tankGroupBox.Name = "tankGroupBox";
            this.tankGroupBox.Size = new System.Drawing.Size(200, 73);
            this.tankGroupBox.TabIndex = 4;
            this.tankGroupBox.TabStop = false;
            this.tankGroupBox.Text = "Tank";
            // 
            // tank1RadioButton
            // 
            this.tank1RadioButton.AutoSize = true;
            this.tank1RadioButton.Location = new System.Drawing.Point(6, 30);
            this.tank1RadioButton.Name = "tank1RadioButton";
            this.tank1RadioButton.Size = new System.Drawing.Size(165, 29);
            this.tank1RadioButton.TabIndex = 0;
            this.tank1RadioButton.TabStop = true;
            this.tank1RadioButton.Text = "Default Tank";
            this.tank1RadioButton.UseVisualStyleBackColor = true;
            // 
            // humanRadioButton
            // 
            this.humanRadioButton.AutoSize = true;
            this.humanRadioButton.Location = new System.Drawing.Point(11, 29);
            this.humanRadioButton.Name = "humanRadioButton";
            this.humanRadioButton.Size = new System.Drawing.Size(111, 29);
            this.humanRadioButton.TabIndex = 0;
            this.humanRadioButton.TabStop = true;
            this.humanRadioButton.Text = "Human";
            this.humanRadioButton.UseVisualStyleBackColor = true;
            // 
            // aiRadioButton
            // 
            this.aiRadioButton.AutoSize = true;
            this.aiRadioButton.Location = new System.Drawing.Point(140, 29);
            this.aiRadioButton.Name = "aiRadioButton";
            this.aiRadioButton.Size = new System.Drawing.Size(62, 29);
            this.aiRadioButton.TabIndex = 1;
            this.aiRadioButton.TabStop = true;
            this.aiRadioButton.Text = "AI";
            this.aiRadioButton.UseVisualStyleBackColor = true;
            // 
            // SetupPlayerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1009, 406);
            this.Controls.Add(this.tankGroupBox);
            this.Controls.Add(this.controllerGroupBox);
            this.Controls.Add(this.nextPlayerButton);
            this.Controls.Add(this.playerNameTextBox);
            this.Controls.Add(this.playerNameLabel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SetupPlayerForm";
            this.ShowIcon = false;
            this.Text = "Setup Player";
            this.controllerGroupBox.ResumeLayout(false);
            this.controllerGroupBox.PerformLayout();
            this.tankGroupBox.ResumeLayout(false);
            this.tankGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label playerNameLabel;
        private System.Windows.Forms.TextBox playerNameTextBox;
        private System.Windows.Forms.Button nextPlayerButton;
        private System.Windows.Forms.GroupBox controllerGroupBox;
        private System.Windows.Forms.RadioButton aiRadioButton;
        private System.Windows.Forms.RadioButton humanRadioButton;
        private System.Windows.Forms.GroupBox tankGroupBox;
        private System.Windows.Forms.RadioButton tank1RadioButton;
    }
}