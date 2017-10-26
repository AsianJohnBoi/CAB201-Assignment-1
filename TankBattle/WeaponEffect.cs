using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Diagnostics;

namespace TankBattle
{
    public abstract class WeaponEffect
    {
        protected Gameplay i;

        public void RecordCurrentGame(Gameplay game)
        {
            i = game;
        }

        public abstract void Process();
        public abstract void Draw(Graphics graphics, Size displaySize);
    }
}
