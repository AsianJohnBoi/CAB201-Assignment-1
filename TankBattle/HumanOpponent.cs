using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TankBattle
{
    public class HumanOpponent : Opponent
    {
        public HumanOpponent(string name, TankModel tank, Color colour) : base(name, tank, colour)
        {
            throw new NotImplementedException();
        }

        public override void StartRound()
        {
            throw new NotImplementedException();
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
