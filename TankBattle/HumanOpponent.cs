using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Diagnostics;

namespace TankBattle
{
	/// <summary>
	/// Concrete class that extends the Opponents class, providing functionality specific to human-controlled Opponents.
	/// 
	/// Author John Santias and Hoang Nguyen October 2017
	/// </summary>
	public class HumanOpponent : Opponent
	{
		private string name;
		private TankModel tank;
		private Color colour;

		/// <summary>
		/// Constructor for the HumanOpponent class. All functionality is handled by Opponent so this 
		/// method doesn't need to do anything.
		/// 
		/// Author John Santias September 2017
		/// </summary>
		/// <param name="name"></param>
		/// <param name="tank"></param>
		/// <param name="colour"></param>
		public HumanOpponent(string name, TankModel tank, Color colour) : base(name, tank, colour)
		{
			this.name = name;
			this.tank = tank;
			this.colour = colour;
		}

		/// <summary>
		/// This is called each round, but doesn't need to do anything here.
		/// 
		/// Author John Santias September 2017
		/// </summary>
		public override void StartRound()
		{

		}

		/// <summary>
		/// Called when it's this player's turn. As this player is human-controlled, this method should
		/// call EnableTankButton() on the GameplayForm passed onto this method.
		/// 
		/// Author John Santias September 2017
		/// </summary>
		/// <param name="gameplayForm">The current gameplayform being used</param>
		/// <param name="currentGame">The current Game being played</param>
		public override void BeginTurn(GameplayForm gameplayForm, Gameplay currentGame)
		{
            gameplayForm.EnableTankButtons();
	    }

		/// <summary>
		/// Called each time a shot is fired by this player lands, but doesn't need to do anything here
		/// 
		/// Author John Santias and Hoang Nguyen September 2017
		/// </summary>
		/// <param name="x">The x position of where the projectile landed</param>
		/// <param name="y">The y position of where the projectile landed</param>
		public override void ProjectileHitPos(float x, float y)
		{
			
		}
	}
}
