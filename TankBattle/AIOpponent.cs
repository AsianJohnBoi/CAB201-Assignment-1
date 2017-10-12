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
        public AIOpponent(string name, TankModel tank, Color colour) : base(name, tank, colour)
        {
            
        }

        public override void StartRound()
        {
            
        }

        public override void BeginTurn(GameplayForm gameplayForm, Gameplay currentGame)
        {
            throw new NotImplementedException();
        }

        public override void ProjectileHitPos(float x, float y)
        {
            throw new NotImplementedException();
        }
    }
}
