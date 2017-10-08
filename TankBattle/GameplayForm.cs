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

namespace TankBattle
{
    public partial class GameplayForm : Form
    {
        private Color landscapeColour;
        private Random rng = new Random();
        private Image backgroundImage = null;
        private int levelWidth = 160;
        private int levelHeight = 120;
        private Gameplay currentGame;

		private BufferedGraphics backgroundGraphics;
        private BufferedGraphics gameplayGraphics;

		internal object GetComponent<T>()
		{
			throw new NotImplementedException();
		}

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

            //Set random background image and colour 
            backgroundImage = Image.FromFile(imageFilenames[randNumber]);
            landscapeColour = Color.FromName(landscapeColours[randNumber].ToString());

            InitializeComponent();

            //Initialise graphic buffers
            backgroundGraphics = InitRenderBuffer();
            gameplayGraphics = InitRenderBuffer();

            DrawBackground();

            DrawGameplay();

            NewTurn();
        }

        private void DrawGameplay() {
            backgroundGraphics.Render(gameplayGraphics.Graphics);
            currentGame.DrawPlayers(gameplayGraphics.Graphics, displayPanel.Size);
            currentGame.RenderEffects(gameplayGraphics.Graphics, displayPanel.Size);
        }

        private void NewTurn() {
            throw new NotImplementedException();
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

        public void EnableTankButtons()
        {
            controlPanel.Enabled = true;
        }

        public void SetAimingAngle(float angle)
        {
            angleSetter.Value = (int)angle; //not sure if change angle to int
        }

        public void SetPower(int power)
        {
            powerTrackBar.Value = power;
        }
        public void SetWeaponIndex(int weapon)
        {
            weaponComboBox.SelectedItem = weapon;
        }

        public void Attack()
        {
            currentGame.GetCurrentGameplayTank();
            Attack(); //Calls currentGame's GetCurrentGameplayTank() method to get a reference to the current player's
                      //ControlledTank, then calls its Attack() method.

            controlPanel.Enabled = false;
            formTimer.Enabled = true;
        }

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

        public BufferedGraphics InitRenderBuffer()
        {
            BufferedGraphicsContext context = BufferedGraphicsManager.Current;
            Graphics graphics = displayPanel.CreateGraphics();
            Rectangle dimensions = new Rectangle(0, 0, displayPanel.Width, displayPanel.Height);
            BufferedGraphics bufferedGraphics = context.Allocate(graphics, dimensions);
            return bufferedGraphics;
        }

        private void displayPanel_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = displayPanel.CreateGraphics();
            gameplayGraphics.Render(graphics);
        }

        private void GameplayForm_Load(object sender, EventArgs e) {

        }
    }
}
