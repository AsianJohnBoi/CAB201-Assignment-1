namespace TankBattle
{
	partial class Rankings
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
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.closeButton = new System.Windows.Forms.Button();
			this.whoWon = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// listBox1
			// 
			this.listBox1.FormattingEnabled = true;
			this.listBox1.Location = new System.Drawing.Point(12, 47);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(280, 160);
			this.listBox1.TabIndex = 0;
			// 
			// closeButton
			// 
			this.closeButton.Location = new System.Drawing.Point(90, 213);
			this.closeButton.Name = "closeButton";
			this.closeButton.Size = new System.Drawing.Size(108, 23);
			this.closeButton.TabIndex = 1;
			this.closeButton.Text = "Close";
			this.closeButton.UseVisualStyleBackColor = true;
			this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
			// 
			// whoWon
			// 
			this.whoWon.AutoSize = true;
			this.whoWon.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.whoWon.Location = new System.Drawing.Point(6, 9);
			this.whoWon.Name = "whoWon";
			this.whoWon.Size = new System.Drawing.Size(155, 25);
			this.whoWon.TabIndex = 2;
			this.whoWon.Text = "Player 1 won!";
			// 
			// Rankings
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(304, 241);
			this.Controls.Add(this.whoWon);
			this.Controls.Add(this.closeButton);
			this.Controls.Add(this.listBox1);
			this.Name = "Rankings";
			this.Text = "Rankings";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.Button closeButton;
		private System.Windows.Forms.Label whoWon;
	}
}