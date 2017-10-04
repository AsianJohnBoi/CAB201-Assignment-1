using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TankBattle
{
    public abstract class Attack
    {
        public void RecordCurrentGame(Gameplay game)
        {
            throw new NotImplementedException();
        }

        public abstract void ProcessTimeEvent();
        public abstract void Paint(Graphics graphics, Size displaySize);
    }
}
