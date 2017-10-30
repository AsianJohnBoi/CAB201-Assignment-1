using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace TankBattle
{
	/// <summary>
	/// This is an partial class using the GameplayForm to play the game.
	/// 
	/// Author John Santias and Hoang Nguyen October 2017
	/// </summary>
	public partial class GameplayForm : Form
	{
		private Color landscapeColour;
		private Random rng = new Random();
		private Image backgroundImage = null;
		private int levelWidth = 160;
		private int levelHeight = 120;
		private Gameplay currentGame;

		private ControlledTank currentControlledTank;
		private TankModel currentTankModel;
		private Opponent currentOpponent;

		private int windSpeed = 0;
		private int angleSet = 0;
		private int powerSet = 0;
		private int weaponSet = 1;

		private bool spacePressed = false;

		private BufferedGraphics backgroundGraphics;
		private BufferedGraphics gameplayGraphics;

		/// <summary>
		/// The constructor for GameplayForm. Setting up the gameplayForm before the InitalizedComponent() was called.
		/// The setup includes setting the background images, the landscape colours, drawling the backgrounds, the
		/// gameplay, and allowing the first player to start the game.
		/// 
		/// Author Hoang Nguyen October 2017
		/// </summary>
		/// <param name="game">The current game</param>
		public GameplayForm(Gameplay game)
		{
			SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
			SetStyle(ControlStyles.DoubleBuffer, true);
			SetStyle(ControlStyles.AllPaintingInWmPaint, true);
			SetStyle(ControlStyles.UserPaint, true);
			SetStyle(ControlStyles.UserPaint, true);

			string[] imageFilenames = { "Images\\background1.jpg",
										"Images\\background2.jpg",
										"Images\\background3.jpg",
										"Images\\background4.jpg"};

			Color[] landscapeColours = { Color.FromArgb(255, 0, 0, 0),
										Color.FromArgb(255, 73, 58, 47),
										Color.FromArgb(255, 148, 116, 93),
										Color.FromArgb(255, 133, 119, 109) };

			currentGame = game;

			int randNumber = rng.Next(4);

			backgroundImage = Image.FromFile(imageFilenames[randNumber]);
			landscapeColour = (landscapeColours[randNumber]);

			InitializeComponent();

			backgroundGraphics = InitRenderBuffer();
			gameplayGraphics = InitRenderBuffer();

			DrawBackground();

			DrawGameplay();

			NewTurn();
		}

		// From https://stackoverflow.com/questions/13999781/tearing-in-my-animation-on-winforms-c-sharp
		protected override CreateParams CreateParams
		{
			get
			{
				CreateParams cp = base.CreateParams;
				cp.ExStyle |= 0x02000000; // WS_EX_COMPOSITED
				return cp;
			}
		}

		/// <summary>
		/// Enables the control panel so the human controller can control their tank. Called from
		/// HumanOpponent.BeginTurn(). This sets the Enabled property to true.
		/// 
		/// Author Hoang Nguyen October 2017
		/// </summary>
		public void EnableTankButtons()
		{
			controlPanel.Enabled = true;
		}

		/// <summary>
		/// This method alters the value of the UpDownNumeric used to control the angle, setting it
		/// to the provided value.
		/// 
		/// Author Hoang Nguyen October 2017
		/// </summary>
		/// <param name="angle"></param>
		public void SetAimingAngle(float angle)
		{
			angleSetter.Value = (int)angle;
		}

		/// <summary>
		/// This alters the value of the TrackBar used to control the power level, setting it to the
		/// provided value.
		/// 
		/// Author Hoang Nguyen October 2017
		/// </summary>
		/// <param name="power"></param>
		public void SetPower(int power)
		{
			if (power < 5)
			{
				power = 5;
			}
			else
			{
				powerTrackBar.Value = power;
			}
		}

		/// <summary>
		/// Changes the selected item in the ComboBox, setting it to the provided value.
		/// 
		/// Author Hoang Nguyen October 2017
		/// </summary>
		/// <param name="weapon"></param>
		public void SetWeaponIndex(int weapon)
		{
			weaponComboBox.SelectedItem = weapon;
		}

		/// <summary>
		/// Method called both externally when the 'Fire!' button is clicked.
		/// 
		/// Author John Santias and Hoang Nguyen October 2017
		/// </summary>
		public void Attack()
		{
			currentControlledTank = currentGame.GetCurrentGameplayTank();
			currentControlledTank.Attack();
			controlPanel.Enabled = false;
			formTimer.Enabled = true;
		}

		/// <summary>
		/// Draws the Gameplay elements of the screen. 
		/// 
		/// Author Hoang Nguyen October 2017
		/// </summary>
		private void DrawGameplay()
		{
			backgroundGraphics.Render(gameplayGraphics.Graphics);
			currentGame.DrawPlayers(gameplayGraphics.Graphics, displayPanel.Size);
			currentGame.RenderEffects(gameplayGraphics.Graphics, displayPanel.Size);
		}

		/// <summary>
		/// Newly-created method used to update form elemtns to reflect who the current player is. It involves 
		/// a number of things like changing the colours, angles, power, round number etc.
		/// 
		/// Author John Santias and Hoang Nguyen October 2017
		/// </summary>
		private void NewTurn()
		{
			currentControlledTank = currentGame.GetCurrentGameplayTank();
			currentOpponent = currentControlledTank.GetPlayerNumber();
			Text = "Tank Battle - Round " + currentGame.GetRound() + " of " + currentGame.GetTotalRounds();
			controlPanel.BackColor = currentOpponent.GetColour();
			playerLabel.Text = currentOpponent.Name();
			currentControlledTank.SetAimingAngle(angleSet);
			currentControlledTank.SetPower(powerSet);
			windSpeed = currentGame.GetWindSpeed();

			if (windSpeed > 0)
			{
				windStatusLabel.Text = windSpeed + " E";
			}
			else if (windSpeed < 0)
			{
				windStatusLabel.Text = -windSpeed + " W";
			}
			weaponComboBox.Items.Clear();
			currentTankModel = currentControlledTank.GetTank(); 
			string[] weapons = currentTankModel.WeaponList();

			for (int i = 0; i < weapons.Length; i++)
			{
				weaponComboBox.Items.Add(weapons[i]);
			}

			weaponSet = currentControlledTank.GetWeaponIndex();
			SetWeaponIndex(weaponSet);
			currentOpponent.BeginTurn(this, currentGame);
		}

		/// <summary>
		/// Draws the background image on the form.
		/// 
		/// Author AMS 2017
		/// </summary>
		private void DrawBackground()
		{
			Graphics graphics = backgroundGraphics.Graphics;
			Image background = backgroundImage;
			graphics.DrawImage(backgroundImage, new Rectangle(0, 0, displayPanel.Width, displayPanel.Height));

			Terrain battlefield = currentGame.GetLevel();
			Brush brush = new SolidBrush(landscapeColour);

			for (int y = 0; y < Terrain.HEIGHT; y++)
			{
				for (int x = 0; x < Terrain.WIDTH; x++)
				{
					if (battlefield.IsTileAt(x, y))
					{
						int drawX1 = displayPanel.Width * x / levelWidth;
						int drawY1 = displayPanel.Height * y / levelHeight;
						int drawX2 = displayPanel.Width * (x + 1) / levelWidth;
						int drawY2 = displayPanel.Height * (y + 1) / levelHeight;
						graphics.FillRectangle(brush, drawX1, drawY1, drawX2 - drawX1, drawY2 - drawY1);
					}
				}
			}
		}

		/// <summary>
		/// Graphics rendered.
		/// 
		/// Author AMS 2017
		/// </summary>
		/// <returns>The buffered graphics</returns>
		public BufferedGraphics InitRenderBuffer()
		{
			BufferedGraphicsContext context = BufferedGraphicsManager.Current;
			Graphics graphics = displayPanel.CreateGraphics();
			Rectangle dimensions = new Rectangle(0, 0, displayPanel.Width, displayPanel.Height);
			BufferedGraphics bufferedGraphics = context.Allocate(graphics, dimensions);
			return bufferedGraphics;
		}

		/// <summary>
		/// The space underneath the control area. Where it will be replaced with the selected background image. 
		/// This area is occupied by the background image, terrain, and tanks.
		/// 
		/// Author Hoang Nguyen October 2017
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void displayPanel_Paint(object sender, PaintEventArgs e)
		{
			Graphics graphics = displayPanel.CreateGraphics();
			gameplayGraphics.Render(graphics);
		}

		/// <summary>
		/// The NumericUpDown used for selecting the angle. Angle Minimum and maximum to 5 and 100.
		/// 
		/// Author John Santias and Hoang Nguyen October 2017
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void angleSetter_ValueChanged(object sender, EventArgs e)
		{
			angleSet = (int)angleSetter.Value;
			currentControlledTank.SetAimingAngle(angleSet);
			DrawGameplay();
			displayPanel.Invalidate();
		}

		/// <summary>
		/// ComboBox used for selecting weapons associated with the Tank
		/// 
		/// Author John Santias and Hoang Nguyen October 2017
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void weaponComboBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			weaponSet = weaponComboBox.SelectedIndex;
			currentControlledTank.SetWeaponIndex(weaponSet);
		}

		/// <summary>
		/// Tick event for the timer. Handles much of the animation and physics. This also handles the forms,
		/// whether to close the current form or create a new gameplay form.
		/// 
		/// Author John Santias and Hoang Nguyen October 2017
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void formTimer_Tick(object sender, EventArgs e)
		{
			currentGame.ProcessEffects();
			if (!currentGame.ProcessEffects())
			{
				currentGame.Gravity();
				DrawBackground();
				DrawGameplay();
				displayPanel.Invalidate();
				if (currentGame.Gravity())
				{
					return;
				}
				else
				{
					formTimer.Enabled = false;
					bool turnOver = currentGame.TurnOver();
					NewTurn();
					spacePressed = false; //prevents the player from pressing the space bar multiple times
					if (!turnOver)
					{
						if (currentGame.GetRound() >= currentGame.GetTotalRounds())
						{
							currentGame.NextRound();
							Dispose();
						}
						else
						{
							Dispose();
							currentGame.NextRound();
							return;
						}
					}
				}
			}
			else
			{
				DrawGameplay();
				displayPanel.Invalidate();
				return;
			}
		}


		/// <summary>
		/// When the button is clicked, the Attack() method is called.
		/// 
		/// Author John Santias October 2017
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void fireButton_Click(object sender, EventArgs e)
		{
			Attack();
		}

		/// <summary>
		/// The trackbar adjusts the power of the tank. This trackbar is linked to the powerLevelLabel
		/// changing its text everytime the trackbar changes its value. Its value is also stored in the
		/// private variable.
		/// 
		/// Author John Santias and Hoang Nguyen October 2017
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void trackBar1_Scroll(object sender, EventArgs e)
		{
			powerSet = powerTrackBar.Value;
			currentControlledTank.SetPower(powerSet);
			DrawGameplay();
			displayPanel.Invalidate();
			powerLevelLabel.Text = powerTrackBar.Value.ToString();
		}

		/// <summary>
		/// Keyboard controls of the attack button, angles and power. The Up and down keys sets the power.
		/// The Left and Right keys sets the angle and the space bar fires the shell.
		/// 
		/// Author Hoang Nguyen October 2017
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void GameplayForm_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Space && !spacePressed)
			{
				spacePressed = true;
				controlPanel.Enabled = false; //prevents the space pressing the attack button multiple times

				Attack();
			}

			if (e.KeyCode == Keys.Right)
			{
				if (angleSetter.Value < 90)
				{
					angleSetter.Value += 1;
				}
			}

			if (e.KeyCode == Keys.Left)
			{
				if (angleSetter.Value > -90)
				{
					angleSetter.Value -= 1;
				}
			}

			if (e.KeyCode == Keys.Up)
			{
				if (powerTrackBar.Value < 100)
				{
					powerTrackBar.Value += 1;
					powerSet = powerTrackBar.Value;
					currentControlledTank.SetPower(powerSet);
					powerLevelLabel.Text = powerTrackBar.Value.ToString();
				}
			}

			if (e.KeyCode == Keys.Down)
			{
				if (powerTrackBar.Value > 5)
				{
					powerTrackBar.Value -= 1;
					powerSet = powerTrackBar.Value;
					currentControlledTank.SetPower(powerSet);
					powerLevelLabel.Text = powerTrackBar.Value.ToString();
				}
			}
		}
	}
}