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
            this.label1 = new System.Windows.Forms.Label();
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
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(24, 23);
            this.panel1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(830, 385);
            this.panel1.TabIndex = 0;
            // 
            // nextPlayerButton
            // 
            this.nextPlayerButton.Location = new System.Drawing.Point(68, 304);
            this.nextPlayerButton.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.nextPlayerButton.Name = "nextPlayerButton";
            this.nextPlayerButton.Size = new System.Drawing.Size(694, 52);
            this.nextPlayerButton.TabIndex = 4;
            this.nextPlayerButton.Text = "Next Player";
            this.nextPlayerButton.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tank1RadioButton);
            this.groupBox2.Location = new System.Drawing.Point(320, 156);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupBox2.Size = new System.Drawing.Size(442, 129);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tank";
            // 
            // tank1RadioButton
            // 
            this.tank1RadioButton.AutoSize = true;
            this.tank1RadioButton.Location = new System.Drawing.Point(24, 60);
            this.tank1RadioButton.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.tank1RadioButton.Name = "tank1RadioButton";
            this.tank1RadioButton.Size = new System.Drawing.Size(27, 26);
            this.tank1RadioButton.TabIndex = 0;
            this.tank1RadioButton.TabStop = true;
            this.tank1RadioButton.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.aiRadioButton);
            this.groupBox1.Controls.Add(this.humanRadioButton);
            this.groupBox1.Location = new System.Drawing.Point(66, 156);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.groupBox1.Size = new System.Drawing.Size(222, 129);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Controller";
            // 
            // aiRadioButton
            // 
            this.aiRadioButton.AutoSize = true;
            this.aiRadioButton.Location = new System.Drawing.Point(142, 56);
            this.aiRadioButton.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.aiRadioButton.Name = "aiRadioButton";
            this.aiRadioButton.Size = new System.Drawing.Size(62, 29);
            this.aiRadioButton.TabIndex = 1;
            this.aiRadioButton.TabStop = true;
            this.aiRadioButton.Text = "AI";
            this.aiRadioButton.UseVisualStyleBackColor = true;
            // 
            // humanRadioButton
            // 
            this.humanRadioButton.AutoSize = true;
            this.humanRadioButton.Location = new System.Drawing.Point(12, 56);
            this.humanRadioButton.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.humanRadioButton.Name = "humanRadioButton";
            this.humanRadioButton.Size = new System.Drawing.Size(111, 29);
            this.humanRadioButton.TabIndex = 0;
            this.humanRadioButton.TabStop = true;
            this.humanRadioButton.Text = "Human";
            this.humanRadioButton.UseVisualStyleBackColor = true;
            // 
            // playerNameInput
            // 
            this.playerNameInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.playerNameInput.Location = new System.Drawing.Point(386, 50);
            this.playerNameInput.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.playerNameInput.Name = "playerNameInput";
            this.playerNameInput.Size = new System.Drawing.Size(372, 53);
            this.playerNameInput.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label1.Location = new System.Drawing.Point(56, 50);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(331, 46);
            this.label1.TabIndex = 0;
            this.label1.Text = "playerNameLabel";
            // 
            // setupPlayerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Maroon;
            this.ClientSize = new System.Drawing.Size(878, 431);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
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
		private System.Windows.Forms.Label label1;
	}
}