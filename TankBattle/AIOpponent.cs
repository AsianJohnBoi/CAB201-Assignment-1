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
		private Color colour;
        private Random rnd = new Random();
        private GameplayForm gameplayform;

        public AIOpponent(string name, TankModel tank, Color colour) : base(name, tank, colour)
        {
			this.name = name;
			this.tank = tank;
			this.colour = colour;
        }

        public override void StartRound()
        {
            
        }

        public override void BeginTurn(GameplayForm gameplayForm, Gameplay currentGame)
        {
            gameplayform = gameplayForm;
            gameplayform.SetWeaponIndex(1);
            float angle = rnd.Next(-90, 91);
            gameplayform.SetAimingAngle(angle);
            int power = rnd.Next(0, 101);
            gameplayForm.SetPower(power);
            gameplayForm.Attack();
        }

        public override void ProjectileHitPos(float x, float y)
        {
            throw new NotImplementedException();
        }
    }
}
