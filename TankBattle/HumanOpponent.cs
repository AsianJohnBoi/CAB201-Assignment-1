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
		private string name;
		private TankModel tank;
		private Color colour;
		private GameplayForm i;

		public HumanOpponent(string name, TankModel tank, Color colour) : base(name, tank, colour)
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
			i.EnableTankButtons();
	}

		public override void ProjectileHitPos(float x, float y)
		{
			
		}
	}
}
