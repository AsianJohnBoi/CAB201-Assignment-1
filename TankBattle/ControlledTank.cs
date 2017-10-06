using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TankBattle
{
    public class ControlledTank
    {
        private Opponent player;
        private int tankX;
        private int tankY;
        private TankModel tankModel;
        private int currentDur;
        private int power;
        private int angle;
        private int Tankweapon;

		public ControlledTank(Opponent player, int tankX, int tankY, Gameplay game)
        {
            this.player = player;
            this.tankX = tankX;
            this.tankY = tankY;
            tankModel = player.GetTank();
            currentDur = tankModel.GetArmour();
        }

        public Opponent GetPlayerNumber()
        {
            return player;
        }
        public TankModel GetTank()
        {
            return tankModel;
        }

        public float GetAim()
        {
            return angle; 
        }

        public void SetAimingAngle(float angle)
        {
            if (angle >= -90 && angle <= 180){ this.angle = (int)angle; }
        }

        public int GetCurrentPower()
        {
            return power;
        }

        public void SetPower(int power)
        {
            this.power = power;
        }

        public int GetWeaponIndex()
        {
            return Tankweapon;
        }
        public void SetWeaponIndex(int newWeapon)
        {
            this.Tankweapon = newWeapon;
        }

		public void Draw(Graphics graphics, Size displaySize)
        {
			//int drawX1 = displaySize.Width * x / Terrain.WIDTH;
			//int drawY1 = displaySize.Height * y / Terrain.HEIGHT;
			//int drawX2 = displaySize.Width * (x + TankModel.WIDTH) / Terrain.WIDTH;
			//int drawY2 = displaySize.Height * (y + TankModel.HEIGHT) / Terrain.HEIGHT;
			//graphics.DrawImage(TankModel.CreateBitmap(), new Rectangle(drawX1, drawY1, drawX2 - drawX1, drawY2 - drawY1));

			//int drawY3 = displaySize.Height * (y - TankModel.HEIGHT) / Terrain.HEIGHT;
			//Font font = new Font("Arial", 8);
			//Brush brush = new SolidBrush(Color.White);

			//int pct = armour * 100 / TheTank.GetArmour();
			//if (pct < 100)
			//{
			//	graphics.DrawString(pct + "%", font, brush, new Point(drawX1, drawY3));
			//}
		}

		public int GetX()
        {
            throw new NotImplementedException();
        }
        public int GetYPos()
        {
            throw new NotImplementedException();
        }

        public void Attack()
        {
            throw new NotImplementedException();
        }

        public void InflictDamage(int damageAmount)
        {
            throw new NotImplementedException();
        }

        public bool Exists()
        {
            if (currentDur > 0) { return true; }
            else { return false; }
        }

        public bool Gravity()
        {
            throw new NotImplementedException();
        }
    }
}
