namespace TankBattle
{
	partial class setupGameForm
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
            this.setupPlayersButton = new System.Windows.Forms.Button();
            this.playerAmountInput = new System.Windows.Forms.NumericUpDown();
            this.roundAmountInput = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.playerAmountInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.roundAmountInput)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label1.Location = new System.Drawing.Point(24, 40);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(464, 46);
            this.label1.TabIndex = 0;
            this.label1.Text = "How many players? (2-8)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label2.Location = new System.Drawing.Point(24, 123);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(547, 46);
            this.label2.TabIndex = 1;
            this.label2.Text = "How many gameplay rounds?";
            // 
            // setupPlayersButton
            // 
            this.setupPlayersButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.setupPlayersButton.Location = new System.Drawing.Point(34, 202);
            this.setupPlayersButton.Margin = new System.Windows.Forms.Padding(6);
            this.setupPlayersButton.Name = "setupPlayersButton";
            this.setupPlayersButton.Size = new System.Drawing.Size(706, 67);
            this.setupPlayersButton.TabIndex = 4;
            this.setupPlayersButton.Text = "Setup Players";
            this.setupPlayersButton.UseVisualStyleBackColor = true;
            this.setupPlayersButton.Click += new System.EventHandler(this.setupPlayersButton_Click);
            // 
            // playerAmountInput
            // 
            this.playerAmountInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playerAmountInput.Location = new System.Drawing.Point(577, 40);
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
            this.playerAmountInput.Size = new System.Drawing.Size(120, 49);
            this.playerAmountInput.TabIndex = 5;
            this.playerAmountInput.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // roundAmountInput
            // 
            this.roundAmountInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.roundAmountInput.Location = new System.Drawing.Point(577, 123);
            this.roundAmountInput.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.roundAmountInput.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.roundAmountInput.Name = "roundAmountInput";
            this.roundAmountInput.Size = new System.Drawing.Size(120, 49);
            this.roundAmountInput.TabIndex = 6;
            this.roundAmountInput.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // setupGameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(766, 292);
            this.Controls.Add(this.roundAmountInput);
            this.Controls.Add(this.playerAmountInput);
            this.Controls.Add(this.setupPlayersButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "setupGameForm";
            this.Text = "Setup Game";
            ((System.ComponentModel.ISupportInitialize)(this.playerAmountInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.roundAmountInput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button setupPlayersButton;
        private System.Windows.Forms.NumericUpDown playerAmountInput;
        private System.Windows.Forms.NumericUpDown roundAmountInput;
    }
}