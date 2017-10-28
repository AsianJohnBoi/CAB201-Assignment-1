namespace TankBattle
{
	partial class SetupPlayer
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
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.domainUpDown1 = new System.Windows.Forms.DomainUpDown();
			this.domainUpDown2 = new System.Windows.Forms.DomainUpDown();
			this.button1 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
			this.label1.Location = new System.Drawing.Point(12, 21);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(231, 25);
			this.label1.TabIndex = 0;
			this.label1.Text = "How many players? (2-8)";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
			this.label2.Location = new System.Drawing.Point(12, 64);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(270, 25);
			this.label2.TabIndex = 1;
			this.label2.Text = "How many gameplay rounds?";
			// 
			// domainUpDown1
			// 
			this.domainUpDown1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
			this.domainUpDown1.Location = new System.Drawing.Point(301, 22);
			this.domainUpDown1.Name = "domainUpDown1";
			this.domainUpDown1.Size = new System.Drawing.Size(70, 27);
			this.domainUpDown1.TabIndex = 2;
			this.domainUpDown1.Text = "2";
			// 
			// domainUpDown2
			// 
			this.domainUpDown2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
			this.domainUpDown2.Location = new System.Drawing.Point(300, 64);
			this.domainUpDown2.Name = "domainUpDown2";
			this.domainUpDown2.Size = new System.Drawing.Size(70, 29);
			this.domainUpDown2.TabIndex = 3;
			this.domainUpDown2.Text = "1";
			// 
			// button1
			// 
			this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
			this.button1.Location = new System.Drawing.Point(17, 105);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(353, 35);
			this.button1.TabIndex = 4;
			this.button1.Text = "Setup Players";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// SetupPlayer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(383, 152);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.domainUpDown2);
			this.Controls.Add(this.domainUpDown1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Name = "SetupPlayer";
			this.Text = "Setup Player #1";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DomainUpDown domainUpDown1;
		private System.Windows.Forms.DomainUpDown domainUpDown2;
		private System.Windows.Forms.Button button1;
	}
}