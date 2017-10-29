namespace TankBattle
{
	partial class setupPlayerForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.panel1 = new System.Windows.Forms.Panel();
			this.nextPlayerButton = new System.Windows.Forms.Button();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.tank1RadioButton = new System.Windows.Forms.RadioButton();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.aiRadioButton = new System.Windows.Forms.RadioButton();
			this.humanRadioButton = new System.Windows.Forms.RadioButton();
			this.playerNameInput = new System.Windows.Forms.TextBox();
			this.PlayerLabel = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.Silver;
			this.panel1.Controls.Add(this.nextPlayerButton);
			this.panel1.Controls.Add(this.groupBox2);
			this.panel1.Controls.Add(this.groupBox1);
			this.panel1.Controls.Add(this.playerNameInput);
			this.panel1.Controls.Add(this.PlayerLabel);
			this.panel1.Location = new System.Drawing.Point(12, 12);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(415, 200);
			this.panel1.TabIndex = 0;
			// 
			// nextPlayerButton
			// 
			this.nextPlayerButton.Location = new System.Drawing.Point(34, 158);
			this.nextPlayerButton.Name = "nextPlayerButton";
			this.nextPlayerButton.Size = new System.Drawing.Size(347, 27);
			this.nextPlayerButton.TabIndex = 4;
			this.nextPlayerButton.Text = "Next Player";
			this.nextPlayerButton.UseVisualStyleBackColor = true;
			this.nextPlayerButton.Click += new System.EventHandler(this.nextPlayerButton_Click);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.tank1RadioButton);
			this.groupBox2.Location = new System.Drawing.Point(160, 81);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(221, 67);
			this.groupBox2.TabIndex = 3;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Tank";
			// 
			// tank1RadioButton
			// 
			this.tank1RadioButton.AutoSize = true;
			this.tank1RadioButton.Location = new System.Drawing.Point(12, 31);
			this.tank1RadioButton.Name = "tank1RadioButton";
			this.tank1RadioButton.Size = new System.Drawing.Size(14, 13);
			this.tank1RadioButton.TabIndex = 0;
			this.tank1RadioButton.TabStop = true;
			this.tank1RadioButton.UseVisualStyleBackColor = true;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.aiRadioButton);
			this.groupBox1.Controls.Add(this.humanRadioButton);
			this.groupBox1.Location = new System.Drawing.Point(33, 81);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(111, 67);
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Controller";
			// 
			// aiRadioButton
			// 
			this.aiRadioButton.AutoSize = true;
			this.aiRadioButton.Location = new System.Drawing.Point(71, 29);
			this.aiRadioButton.Name = "aiRadioButton";
			this.aiRadioButton.Size = new System.Drawing.Size(35, 17);
			this.aiRadioButton.TabIndex = 1;
			this.aiRadioButton.TabStop = true;
			this.aiRadioButton.Text = "AI";
			this.aiRadioButton.UseVisualStyleBackColor = true;
			// 
			// humanRadioButton
			// 
			this.humanRadioButton.AutoSize = true;
			this.humanRadioButton.Location = new System.Drawing.Point(6, 29);
			this.humanRadioButton.Name = "humanRadioButton";
			this.humanRadioButton.Size = new System.Drawing.Size(59, 17);
			this.humanRadioButton.TabIndex = 0;
			this.humanRadioButton.TabStop = true;
			this.humanRadioButton.Text = "Human";
			this.humanRadioButton.UseVisualStyleBackColor = true;
			// 
			// playerNameInput
			// 
			this.playerNameInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
			this.playerNameInput.Location = new System.Drawing.Point(193, 26);
			this.playerNameInput.Name = "playerNameInput";
			this.playerNameInput.Size = new System.Drawing.Size(188, 30);
			this.playerNameInput.TabIndex = 1;
			// 
			// PlayerLabel
			// 
			this.PlayerLabel.AutoSize = true;
			this.PlayerLabel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.PlayerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
			this.PlayerLabel.Location = new System.Drawing.Point(28, 28);
			this.PlayerLabel.Name = "PlayerLabel";
			this.PlayerLabel.Size = new System.Drawing.Size(168, 25);
			this.PlayerLabel.TabIndex = 0;
			this.PlayerLabel.Text = "Player #1\'s name:";
			this.PlayerLabel.Click += new System.EventHandler(this.label1_Click);
			// 
			// setupPlayerForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Maroon;
			this.ClientSize = new System.Drawing.Size(439, 224);
			this.Controls.Add(this.panel1);
			this.Name = "setupPlayerForm";
			this.Text = "Setup Player";
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button nextPlayerButton;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.RadioButton tank1RadioButton;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton aiRadioButton;
		private System.Windows.Forms.RadioButton humanRadioButton;
		private System.Windows.Forms.TextBox playerNameInput;
		private System.Windows.Forms.Label PlayerLabel;
	}
}