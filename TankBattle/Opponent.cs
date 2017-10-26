using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace TankBattle
{
    abstract public class Opponent
    {
        private string name;
        private TankModel tank;
        private Color colour;
        private int roundswon;

        public Opponent(string name, TankModel tank, Color colour)
        {
            this.name = name;
            this.tank = tank;
            this.colour = colour;
            this.roundswon = 0;

        }
        public TankModel GetTank()
        {
            return tank;
        }
        public string Name()
        {
            return name;
        }
        public Color GetColour()
        {
            return colour;
        }
        public void AddScore()
        {
            roundswon++;
        }
        public int GetScore()
        {
            return roundswon;
        }

        public abstract void StartRound();

        public abstract void BeginTurn(GameplayForm gameplayForm, Gameplay currentGame);

        public abstract void ProjectileHitPos(float x, float y);
    }
}
