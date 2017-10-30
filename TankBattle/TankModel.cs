using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace TankBattle
{
    /// <summary>
    /// 
    /// This is an abstract class representing a generic tank model.
    /// 
    /// Author John Santias and Hoang Nguyen October 2017
    /// 
    /// </summary>
    public abstract class TankModel
    {
        public const int WIDTH = 4;
        public const int HEIGHT = 3;
        public const int NUM_TANKS = 1;

        /// <summary>
        /// 
        /// This method draws the tank into an array and returns it.
        /// 
        /// Author John Santias and Hoang Nguyen October 2017
        /// 
        /// </summary>
        /// <param name="angle"> Angle that tank is set to </param>
        /// <returns> Tank's turret set at set angle </returns>
        public abstract int[,] DisplayTank(float angle);

        /// <summary>
        ///
        /// This method draws a line on the row-major two-dimensional array 'graphic'
        /// connecting X1, Y1 to X2, Y2.
        /// 
        /// Author John Santias and Hoang Nguyen October 2017
        /// 
        /// </summary>
        /// <param name="graphic"> 2D array graphic </param>
        /// <param name="X1"> X1 - first x coordinate </param>
        /// <param name="Y1"> Y1 - first y coordinate </param>
        /// <param name="X2"> X2 - second x coordinate </param>
        /// <param name="Y2"> Y2 - second y coordinate </param>
		public static void DrawLine(int[,] graphic, int X1, int Y1, int X2, int Y2)
		{
			int dx = X2 - X1;
			int dy = Y2 - Y1;
		
			if (X1 > X2) //If X1 starts on very right of line
			{
				for (int x = X1; x != X2 - 1; x--)
				{
					int y = Y1 + dy * (x - X1) / dx;
					graphic[x, y] = 1;
				}
			}
			else if (X2 > X1) //If X1 starts on very left of line
			{
				for (int x = X1; x != X2 - 1; x++)
				{
					int y = Y1 + dy * (x - X1) / dx;
					graphic[x, y] = 1;
				}
			}
		}

        /// <summary>
        /// 
        /// This method creates the Tank's bitmap.
        /// 
        /// Author John Santias and Hoang Nguyen October 2017
        /// 
        /// </summary>
        /// <param name="tankColour"> Colour of tank </param>
        /// <param name="angle"> Set angle of tank </param>
        /// <returns> Bitmap of tank </returns>
        public Bitmap CreateBitmap(Color tankColour, float angle)
        {
            int[,] tankGraphic = DisplayTank(angle);
            int height = tankGraphic.GetLength(0);
            int width = tankGraphic.GetLength(1);

            Bitmap bmp = new Bitmap(width, height);
            Color transparent = Color.FromArgb(0, 0, 0, 0);
            Color tankOutline = Color.FromArgb(255, 0, 0, 0);

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (tankGraphic[y, x] == 0)
                    {
                        bmp.SetPixel(x, y, transparent);
                    }
                    else
                    {
                        bmp.SetPixel(x, y, tankColour);
                    }
                }
            }
           
            for (int y = 1; y < height - 1; y++) // Outline each pixel
            {
                for (int x = 1; x < width - 1; x++)
                {
                    if (tankGraphic[y, x] != 0)
                    {
						if (tankGraphic[y - 1, x] == 0)
						{
							bmp.SetPixel(x, y - 1, tankOutline);
						}
                        if (tankGraphic[y + 1, x] == 0)
						{
							bmp.SetPixel(x, y + 1, tankOutline);
						}
                        if (tankGraphic[y, x - 1] == 0)
						{
							bmp.SetPixel(x - 1, y, tankOutline);
						}
                        if (tankGraphic[y, x + 1] == 0)
                            bmp.SetPixel(x + 1, y, tankOutline);
                    }
                }
            }
            return bmp;
        }

        /// <summary>
        /// 
        /// This abstract method gets the starting durability of this type of tank.
        /// 
        /// Author John Santias and Hoang Nguyen October 2017
        /// 
        /// </summary>
        /// <returns> The durability rating for this type of tank </returns>
        public abstract int GetArmour();

        /// <summary>
        /// 
        /// This abstract method returns an array containing a list of weapons that this tank has.
        /// 
        /// Author John Santias and Hoang Nguyen October 2017
        /// 
        /// </summary>
        /// <returns> Array containing list of weapons </returns>
        public abstract string[] WeaponList();

        /// <summary>
        /// 
        /// This abstract method is used to handle firing the specified weapon from the tank playerTank.
        /// 
        /// Author John Santias and Hoang Nguyen October 2017
        /// 
        /// </summary>
        /// <param name="weapon"> Weapon index </param>
        /// <param name="playerTank"> The playerTank in reference to ControlledTank </param>
        /// <param name="currentGame"> The currentGame in reference to Gameplay </param>
        public abstract void FireWeapon(int weapon, ControlledTank playerTank, Gameplay currentGame);

        public static TankModel GetTank(int tankNumber)
        {
            return new TheTank();
        }
    }

	public class TheTank : TankModel
    {
        public double X1, Y1, X2, Y2;
        public String[] Weapons;

		public override int[,] DisplayTank(float angle)
		{
			int[,] graphic = { { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
				   { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
				   { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
				   { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
				   { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
				   { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
				   { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
				   { 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0 },
				   { 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0 },
				   { 0, 0, 1, 1, 0, 1, 0, 1, 0, 1, 0, 1, 1, 0, 0, 0 },
				   { 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0 },
				   { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 } };

			float radians = (180 - angle) * (float)Math.PI / 180; //Math.Cos/Sin takes radians not angles

			X1 = 7;
			Y1 = 6;
			X2 = Math.Round(X1 + (5 * Math.Cos(radians)));
			Y2 = Math.Round(Y1 + (5 * Math.Sin(radians)));

			DrawLine(graphic, (int)X1, (int)Y1, (int)X2, (int)Y2);
			return graphic;
        }

        public override void FireWeapon(int weapon, ControlledTank playerTank, Gameplay currentGame)
        {
            float centerPosX = (float)playerTank.GetX() + (WIDTH / 2), centerPosY = (float)playerTank.GetYPos() + (HEIGHT / 2);
            Opponent op = playerTank.GetPlayerNumber();
            Blast blast = new Blast(100, 4, 4);
            Shell shell = new Shell(centerPosX, centerPosY, playerTank.GetAim(), playerTank.GetCurrentPower(), 0.01f, blast, op);
            currentGame.AddWeaponEffect(shell);
        }

        public override int GetArmour()
        {
            return 100;
        }

        public override string[] WeaponList()
        {
            Weapons = new string[] 
            {
                "Standard shell", "Medium Shell", "Large Shell", "Armour Piercing Shell",
            };
            return Weapons;
        }
    }
}
