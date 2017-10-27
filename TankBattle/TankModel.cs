using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace TankBattle
{
    public abstract class TankModel
    {
        public const int WIDTH = 4;
        public const int HEIGHT = 3;
        public const int NUM_TANKS = 1;

        public abstract int[,] DisplayTank(float angle);

        //private int X1, X2, Y1, Y2;
        public static void DrawLine(int[,] graphic, int X1, int Y1, int X2, int Y2)
        {
            int dx = X2 - X1;
            int dy = Y2 - Y1;
		
            //If X1 starts on very right of line
            if (X1 > X2) {
                for (int x = X1; x != X2 - 1; x--) {
                    int y = Y1 + dy * (x - X1) / dx;
                    graphic[x, y] = 1;
                }
            }
		
	    //If X1 starts on very left of line
            else if (X2 > X1) {
                for (int x = X1; x != X2 - 1; x++) {
                    int y = Y1 + dy * (x - X1) / dx;
                    graphic[x, y] = 1;
                }
            }
        }
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

            // Outline each pixel
            for (int y = 1; y < height - 1; y++)
            {
                for (int x = 1; x < width - 1; x++)
                {
                    if (tankGraphic[y, x] != 0)
                    {
                        if (tankGraphic[y - 1, x] == 0)
                            bmp.SetPixel(x, y - 1, tankOutline);
                        if (tankGraphic[y + 1, x] == 0)
                            bmp.SetPixel(x, y + 1, tankOutline);
                        if (tankGraphic[y, x - 1] == 0)
                            bmp.SetPixel(x - 1, y, tankOutline);
                        if (tankGraphic[y, x + 1] == 0)
                            bmp.SetPixel(x + 1, y, tankOutline);
                    }
                }
            }

            return bmp;
        }

        public abstract int GetArmour();

        public abstract string[] WeaponList();

        public abstract void FireWeapon(int weapon, ControlledTank playerTank, Gameplay currentGame);

        public static TankModel GetTank(int tankNumber)
        {
            return new TheTank(); //100
        }
    }
    //create 4 
    public class TheTank : TankModel
    {
        private int X1, Y1, X2, Y2;
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

			if (angle >= 0)
			{
				X1 = 7;
				Y1 = 6;
                double x_t = Math.Sin(Math.PI/180 * angle);
                double y_t = Math.Cos(Math.PI /180 * angle);
                X2 = (int)Math.Sin(Math.PI / 180 * angle);
                Y2 = (int)Math.Cos(Math.PI / 180 * angle);
                //X2 = X1 + ((int)(Math.Sin(Math.PI / 180 * angle) * 10) / 2 + 1);
                //Y2 = Y1 - ((int)(Math.Cos(Math.PI / 180 * angle) * 10) / 2 + 1);
            }
            else if ( angle < 0)
            {
                X2 = 7;
                Y2 = 6;
                X1 = (int)Math.Sin(Math.PI / 180 * angle);
                Y1 = (int)Math.Cos(Math.PI / 180 * angle);
                //            X1 = X2 + ((int)(Math.Sin(Math.PI / 180 * angle) * 10) / 2 + 1);
                //Y1 = Y1 - ((int)(Math.Cos(Math.PI / 180 * angle) * 10) / 2 + 1);
                double x_t = Math.Sin(Math.PI / 180 * angle);
                double y_t = Math.Cos(Math.PI / 180 * angle);
			}
			DrawLine(graphic, X1, Y1, X2, Y2);
			return graphic;
        }

        public override void FireWeapon(int weapon, ControlledTank playerTank, Gameplay currentGame)
        {
            float centerPosX = (float)playerTank.GetX() + (TankModel.WIDTH / 2), centerPosY = (float)playerTank.GetYPos() + (TankModel.HEIGHT / 2);
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
