using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace TankBattle
{
	/// <summary>
	/// Abstract class represents either a computer of human player. The AIOpponent and HumanOpponent inherit from Opponent
	/// 
	/// Author John Santias and Hoang Nguyen October 2017
	/// </summary>
	abstract public class Opponent
    {
        private string name;
		private int roundswon;
		private TankModel tank;
        private Color colour;

		/// <summary>
		/// The constructor that passes the opponent's name, TankModel and colour. These values are stored
		/// as private members of Opponent. 
		/// 
		/// Author John Santias and Hoang Nguyen September 2017
		/// </summary>
		/// <param name="name">The name of the opponent</param>
		/// <param name="tank">The opponent's tank model</param>
		/// <param name="colour">The colour associated with the opponent/player</param>
		public Opponent(string name, TankModel tank, Color colour)
        {
            this.name = name;
            this.tank = tank;
            this.colour = colour;
            roundswon = 0;
        }

		/// <summary>
		/// Gets the TankModel associated with the opponent.
		/// 
		/// Author John Santias and Hoang Nguyen September 2017
		/// </summary>
		/// <returns>TankModel associated with the opponent</returns>
		public TankModel GetTank()
        {
            return tank;
        }

		/// <summary>
		/// Returns the Opponent's name.
		/// 
		/// Author John Santias and Hoang Nguyen September 2017
		/// </summary>
		/// <returns>The name of the opponent</returns>
		public string Name()
        {
            return name;
        }


		/// <summary>
		/// Returns the Colour associated with this opponent.
		/// 
		/// Author John Santias and Hoang Nguyen September 2017
		/// </summary>
		/// <returns>Colour associated with this opponent</returns>
		public Color GetColour()
        {
            return colour;
        }

		/// <summary>
		/// Increments the number of rounds won by this player by 1
		/// 
		/// Author John Santias and Hoang Nguyen September 2017
		/// </summary>
		public void AddScore()
        {
            roundswon++;
        }

		/// <summary>
		/// Returns the number of rounds won by the player.
		/// Author John Santias and Hoang Nguyen September 2017
		/// </summary>
		/// <returns>Rounds won by player</returns>
		public int GetScore()
        {
            return roundswon;
        }

		/// <summary>
		/// Abstract implemented by the AIOpponent and HumanOpponent classes. Called each new round of battle.
		/// </summary>
		public abstract void StartRound();

		/// <summary>
		/// Implemented by the AIOpponent and HumanOpponent classes, called when it's this player's turn to
		/// move. 
		/// </summary>
		/// <param name="gameplayForm">The current gameplayForm thats being used</param>
		/// <param name="currentGame">The current Game being played</param>
        public abstract void BeginTurn(GameplayForm gameplayForm, Gameplay currentGame);

		/// <summary>
		/// Implemented by AIOpponent and HumanOpponent classes, called when Shell is launched by this player
		/// lands somewhere. This method is mainly for AIOpponent to use to adjust its aim for the next shot. 
		/// </summary>
		/// <param name="x">The shell's x position when it hits something</param>
		/// <param name="y">The shell's y position when it hits something</param>
		public abstract void ProjectileHitPos(float x, float y);
    }
}
