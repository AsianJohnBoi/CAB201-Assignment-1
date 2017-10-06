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
            throw new NotImplementedException();
        }

        public void SetAimingAngle(float angle)
        {
            throw new NotImplementedException();
        }

        public int GetCurrentPower()
        {
            throw new NotImplementedException();
        }

        public void SetPower(int power)
        {
            throw new NotImplementedException();
        }

        public int GetWeaponIndex()
        {
            throw new NotImplementedException();
        }
        public void SetWeaponIndex(int newWeapon)
        {
            throw new NotImplementedException();
        }

        public void Draw(Graphics graphics, Size displaySize)
        {
            throw new NotImplementedException();
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
