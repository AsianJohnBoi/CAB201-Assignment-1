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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(setupPlayerForm));
			this.panel1 = new System.Windows.Forms.Panel();
			this.nextPlayerButton = new System.Windows.Forms.Button();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.tank1RadioButton = new System.Windows.Forms.RadioButton();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.aiRadioButton = new System.Windows.Forms.RadioButton();
			this.humanRadioButton = new System.Windows.Forms.RadioButton();
			this.playerNameInput = new System.Windows.Forms.TextBox();
			this.PlayerLabel = new System.Windows.Forms.Label();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this.radioButton1 = new System.Windows.Forms.RadioButton();
			this.radioButton2 = new System.Windows.Forms.RadioButton();
			this.pictureBox3 = new System.Windows.Forms.PictureBox();
			this.radioButton3 = new System.Windows.Forms.RadioButton();
			this.pictureBox4 = new System.Windows.Forms.PictureBox();
			this.radioButton4 = new System.Windows.Forms.RadioButton();
			this.pictureBox5 = new System.Windows.Forms.PictureBox();
			this.pictureBox6 = new System.Windows.Forms.PictureBox();
			this.radioButton5 = new System.Windows.Forms.RadioButton();
			this.panel1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
			this.panel1.Controls.Add(this.nextPlayerButton);
			this.panel1.Controls.Add(this.pictureBox6);
			this.panel1.Controls.Add(this.groupBox2);
			this.panel1.Controls.Add(this.groupBox1);
			this.panel1.Controls.Add(this.playerNameInput);
			this.panel1.Controls.Add(this.PlayerLabel);
			this.panel1.Location = new System.Drawing.Point(12, 12);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(447, 200);
			this.panel1.TabIndex = 0;
			// 
			// nextPlayerButton
			// 
			this.nextPlayerButton.Enabled = false;
			this.nextPlayerButton.Location = new System.Drawing.Point(14, 158);
			this.nextPlayerButton.Name = "nextPlayerButton";
			this.nextPlayerButton.Size = new System.Drawing.Size(424, 27);
			this.nextPlayerButton.TabIndex = 4;
			this.nextPlayerButton.Text = "Next Player";
			this.nextPlayerButton.UseVisualStyleBackColor = true;
			this.nextPlayerButton.Click += new System.EventHandler(this.nextPlayerButton_Click);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.radioButton5);
			this.groupBox2.Controls.Add(this.radioButton4);
			this.groupBox2.Controls.Add(this.pictureBox5);
			this.groupBox2.Controls.Add(this.radioButton3);
			this.groupBox2.Controls.Add(this.pictureBox4);
			this.groupBox2.Controls.Add(this.radioButton2);
			this.groupBox2.Controls.Add(this.pictureBox3);
			this.groupBox2.Controls.Add(this.radioButton1);
			this.groupBox2.Controls.Add(this.pictureBox2);
			this.groupBox2.Controls.Add(this.pictureBox1);
			this.groupBox2.Controls.Add(this.tank1RadioButton);
			this.groupBox2.Location = new System.Drawing.Point(140, 81);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(298, 67);
			this.groupBox2.TabIndex = 3;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Tank";
			// 
			// pictureBox1
			// 
			this.pictureBox1.ErrorImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.ErrorImage")));
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(28, 25);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(27, 36);
			this.pictureBox1.TabIndex = 1;
			this.pictureBox1.TabStop = false;
			// 
			// tank1RadioButton
			// 
			this.tank1RadioButton.AutoSize = true;
			this.tank1RadioButton.Checked = true;
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
			this.groupBox1.Location = new System.Drawing.Point(13, 81);
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
			this.aiRadioButton.Text = "AI";
			this.aiRadioButton.UseVisualStyleBackColor = true;
			// 
			// humanRadioButton
			// 
			this.humanRadioButton.AutoSize = true;
			this.humanRadioButton.Checked = true;
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
			this.playerNameInput.Location = new System.Drawing.Point(173, 26);
			this.playerNameInput.Name = "playerNameInput";
			this.playerNameInput.Size = new System.Drawing.Size(265, 30);
			this.playerNameInput.TabIndex = 1;
			this.playerNameInput.TextChanged += new System.EventHandler(this.playerNameInput_TextChanged);
			// 
			// PlayerLabel
			// 
			this.PlayerLabel.AutoSize = true;
			this.PlayerLabel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.PlayerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
			this.PlayerLabel.Location = new System.Drawing.Point(8, 28);
			this.PlayerLabel.Name = "PlayerLabel";
			this.PlayerLabel.Size = new System.Drawing.Size(168, 25);
			this.PlayerLabel.TabIndex = 0;
			this.PlayerLabel.Text = "Player #1\'s name:";
			this.PlayerLabel.Click += new System.EventHandler(this.label1_Click);
			// 
			// pictureBox2
			// 
			this.pictureBox2.ErrorImage = ((System.Drawing.Image)(resources.GetObject("pictureBox2.ErrorImage")));
			this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
			this.pictureBox2.Location = new System.Drawing.Point(75, 25);
			this.pictureBox2.Name = "pictureBox2";
			this.pictureBox2.Size = new System.Drawing.Size(27, 36);
			this.pictureBox2.TabIndex = 2;
			this.pictureBox2.TabStop = false;
			// 
			// radioButton1
			// 
			this.radioButton1.AutoSize = true;
			this.radioButton1.Location = new System.Drawing.Point(59, 31);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.Size = new System.Drawing.Size(14, 13);
			this.radioButton1.TabIndex = 3;
			this.radioButton1.TabStop = true;
			this.radioButton1.UseVisualStyleBackColor = true;
			// 
			// radioButton2
			// 
			this.radioButton2.AutoSize = true;
			this.radioButton2.Location = new System.Drawing.Point(103, 31);
			this.radioButton2.Name = "radioButton2";
			this.radioButton2.Size = new System.Drawing.Size(14, 13);
			this.radioButton2.TabIndex = 5;
			this.radioButton2.TabStop = true;
			this.radioButton2.UseVisualStyleBackColor = true;
			// 
			// pictureBox3
			// 
			this.pictureBox3.ErrorImage = ((System.Drawing.Image)(resources.GetObject("pictureBox3.ErrorImage")));
			this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
			this.pictureBox3.Location = new System.Drawing.Point(119, 25);
			this.pictureBox3.Name = "pictureBox3";
			this.pictureBox3.Size = new System.Drawing.Size(27, 36);
			this.pictureBox3.TabIndex = 4;
			this.pictureBox3.TabStop = false;
			// 
			// radioButton3
			// 
			this.radioButton3.AutoSize = true;
			this.radioButton3.Location = new System.Drawing.Point(147, 31);
			this.radioButton3.Name = "radioButton3";
			this.radioButton3.Size = new System.Drawing.Size(14, 13);
			this.radioButton3.TabIndex = 7;
			this.radioButton3.TabStop = true;
			this.radioButton3.UseVisualStyleBackColor = true;
			// 
			// pictureBox4
			// 
			this.pictureBox4.ErrorImage = ((System.Drawing.Image)(resources.GetObject("pictureBox4.ErrorImage")));
			this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
			this.pictureBox4.Location = new System.Drawing.Point(163, 25);
			this.pictureBox4.Name = "pictureBox4";
			this.pictureBox4.Size = new System.Drawing.Size(27, 36);
			this.pictureBox4.TabIndex = 6;
			this.pictureBox4.TabStop = false;
			// 
			// radioButton4
			// 
			this.radioButton4.AutoSize = true;
			this.radioButton4.Location = new System.Drawing.Point(191, 31);
			this.radioButton4.Name = "radioButton4";
			this.radioButton4.Size = new System.Drawing.Size(14, 13);
			this.radioButton4.TabIndex = 9;
			this.radioButton4.TabStop = true;
			this.radioButton4.UseVisualStyleBackColor = true;
			// 
			// pictureBox5
			// 
			this.pictureBox5.ErrorImage = ((System.Drawing.Image)(resources.GetObject("pictureBox5.ErrorImage")));
			this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
			this.pictureBox5.Location = new System.Drawing.Point(207, 25);
			this.pictureBox5.Name = "pictureBox5";
			this.pictureBox5.Size = new System.Drawing.Size(27, 36);
			this.pictureBox5.TabIndex = 8;
			this.pictureBox5.TabStop = false;
			// 
			// pictureBox6
			// 
			this.pictureBox6.ErrorImage = ((System.Drawing.Image)(resources.GetObject("pictureBox6.ErrorImage")));
			this.pictureBox6.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox6.Image")));
			this.pictureBox6.Location = new System.Drawing.Point(391, 106);
			this.pictureBox6.Name = "pictureBox6";
			this.pictureBox6.Size = new System.Drawing.Size(27, 36);
			this.pictureBox6.TabIndex = 10;
			this.pictureBox6.TabStop = false;
			// 
			// radioButton5
			// 
			this.radioButton5.AutoSize = true;
			this.radioButton5.Location = new System.Drawing.Point(236, 29);
			this.radioButton5.Name = "radioButton5";
			this.radioButton5.Size = new System.Drawing.Size(14, 13);
			this.radioButton5.TabIndex = 10;
			this.radioButton5.TabStop = true;
			this.radioButton5.UseVisualStyleBackColor = true;
			// 
			// setupPlayerForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Maroon;
			this.ClientSize = new System.Drawing.Size(471, 224);
			this.Controls.Add(this.panel1);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "setupPlayerForm";
			this.ShowIcon = false;
			this.Text = "Setup Player";
			this.Load += new System.EventHandler(this.setupPlayerForm_Load);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
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
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.PictureBox pictureBox6;
		private System.Windows.Forms.RadioButton radioButton4;
		private System.Windows.Forms.PictureBox pictureBox5;
		private System.Windows.Forms.RadioButton radioButton3;
		private System.Windows.Forms.PictureBox pictureBox4;
		private System.Windows.Forms.RadioButton radioButton2;
		private System.Windows.Forms.PictureBox pictureBox3;
		private System.Windows.Forms.RadioButton radioButton1;
		private System.Windows.Forms.PictureBox pictureBox2;
		private System.Windows.Forms.RadioButton radioButton5;
	}
}