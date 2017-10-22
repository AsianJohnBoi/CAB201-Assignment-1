using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TankBattle
{
    public class AIOpponent : Opponent
    {
        private string name;
        private TankModel tank;
        private Color color;
        private GameplayForm gameplayform;

        public AIOpponent(string name, TankModel tank, Color colour) : base(name, tank, colour)
        {
            this.name = name;
            this.tank = tank;
            color = color;
        }

        public override void StartRound()
        {
            
        }

        public override void BeginTurn(GameplayForm gameplayForm, Gameplay currentGame)
        {
            gameplayform = gameplayForm;
            //gameplayform.SetWeaponIndex();
            //gameplayform.SetAimingAngle();
            //gameplayForm.SetPower();
            gameplayForm.Attack();
        }

        public override void ProjectileHitPos(float x, float y)
        {
            throw new NotImplementedException();
        }
    }
}
