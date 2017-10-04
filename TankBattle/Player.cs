using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TankBattle
{
    abstract public class Player
    {
        public Player(string name, TankType tank, Color colour)
        {
            throw new NotImplementedException();
        }
        public TankType CreateTank()
        {
            throw new NotImplementedException();
        }
        public string PlayerName()
        {
            throw new NotImplementedException();
        }
        public Color PlayerColour()
        {
            throw new NotImplementedException();
        }
        public void Winner()
        {
            throw new NotImplementedException();
        }
        public int GetScore()
        {
            throw new NotImplementedException();
        }

        public abstract void StartRound();

        public abstract void CommenceTurn(SkirmishForm gameplayForm, Gameplay currentGame);

        public abstract void ReportHit(float x, float y);
    }
}
