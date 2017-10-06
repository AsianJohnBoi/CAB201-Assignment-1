using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            graphic[X1, Y1] = 1;
            graphic[X2, Y2] = 1;
            int dx = X2 - X1;
            int dy = Y2 - Y1;
            for (int x = X1; x != X2; x++ ){
                int y = Y1 + dy * (x - X1) / dx;
                graphic[x, y] = 1;
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
            return new TheTank();
        }
    }
    //create 4 
    public class TheTank : TankModel
    {
        private int X1, Y1, X2, Y2;
        private int currentDur;
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

			X1 = 7;
			Y1 = 6;
			X2 = (int)Math.Sin(angle);
			Y2 = (int)Math.Cos(angle);
			DrawLine(graphic, X1, Y1, X2, Y2);
			return graphic;
        }

        public override void FireWeapon(int weapon, ControlledTank playerTank, Gameplay currentGame)
        {
            throw new NotImplementedException();
        }

        public override int GetArmour()
        {
            currentDur = 100;
            return currentDur;
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
