using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace TankBattle
{
    public class ControlledTank
    {
		private int tankX, tankY, currentDur, power, angle, tankWeapon;
		private Opponent player;
		private Gameplay game;
        private TankModel tankModel;
        
        private Bitmap colour;

		public ControlledTank(Opponent player, int tankX, int tankY, Gameplay game)
        {
            this.player = player;
            this.tankX = tankX;
            this.tankY = tankY;
            this.game = game;
            tankModel = player.GetTank();
            currentDur = tankModel.GetArmour();
            angle = 0;
            power = 25;
            tankWeapon = 0;
            colour = tankModel.CreateBitmap(player.GetColour(), angle);
        }

        public Opponent GetPlayerNumber()
        {
            return player;
        }
        public TankModel GetTank()
        {
            return player.GetTank();
        }

        public float GetAim()
        {
            return angle; 
        }

        public void SetAimingAngle(float angle)
        {
            if (angle >= -90 && angle <= 180)
			{
				this.angle = (int)angle;
			}
			colour = tankModel.CreateBitmap(player.GetColour(), angle);
        }

        public int GetCurrentPower()
        {
            return power;
        }

        public void SetPower(int power)
        {
            this.power = (power < 5) ? 5 : (power > 100) ? 100 : power;
        }

        public int GetWeaponIndex()
        {
            return tankWeapon;
        }

        public void SetWeaponIndex(int newWeapon)
        {
            tankWeapon = newWeapon;
        }

		public void Draw(Graphics graphics, Size displaySize)
        {
            int x = tankX;
            int y = tankY;
			int drawX1 = displaySize.Width * x / Terrain.WIDTH;
            int drawY1 = displaySize.Height * y / Terrain.HEIGHT;
            int drawX2 = displaySize.Width * (x + TankModel.WIDTH) / Terrain.WIDTH;
            int drawY2 = displaySize.Height * (y + TankModel.HEIGHT) / Terrain.HEIGHT;
            graphics.DrawImage(colour, new Rectangle(drawX1, drawY1, drawX2 - drawX1, drawY2 - drawY1));
            
            int drawY3 = displaySize.Height * (y - TankModel.HEIGHT) / Terrain.HEIGHT;
            Font font = new Font("Arial", 8);
            Brush brush = new SolidBrush(Color.White);

            int pct = currentDur * 100 / tankModel.GetArmour();
            if (pct < 100)
            {
                graphics.DrawString(pct + "%", font, brush, new Point(drawX1, drawY3));
            }
		}

		public int GetX()
        {
           return tankX;
        }
        public int GetYPos()
        {
            return tankY;
        }

        public void Attack()
        {
            GetTank().FireWeapon(tankWeapon, this, game);
        }

        public void InflictDamage(int damageAmount)
        {
            currentDur -= damageAmount;
        }

        public bool Exists()
        {
            if (currentDur > 0)
			{
				return true;
			}
            else {
				return false;
			}
        }

        public bool Gravity()
        {
			if (!Exists())
			{
				return false;
			}
			Terrain t = game.GetLevel();
			int x = GetX();
			int y = GetYPos();
			if (t.CheckTankCollision(x, y + 1))
			{
				return false;
			}
			else
			{
				tankY++;
				currentDur--;
				if (tankY == Terrain.HEIGHT - TankModel.HEIGHT)
				{
					currentDur = 0;
					return true;
				}
			}
			return true;
        }
    }
}
