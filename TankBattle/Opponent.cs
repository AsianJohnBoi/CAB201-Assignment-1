using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TankBattle
{
    abstract public class Opponent
    {
        public Opponent(string name, TankModel tank, Color colour)
        {
            throw new NotImplementedException();
        }
        public TankModel GetTank()
        {
            throw new NotImplementedException();
        }
        public string Name()
        {
            throw new NotImplementedException();
        }
        public Color GetColour()
        {
            throw new NotImplementedException();
        }
        public void AddScore()
        {
            throw new NotImplementedException();
        }
        public int GetScore()
        {
            throw new NotImplementedException();
        }

        public abstract void StartRound();

        public abstract void BeginTurn(GameplayForm gameplayForm, Gameplay currentGame);

        public abstract void ProjectileHitPos(float x, float y);
    }
}
