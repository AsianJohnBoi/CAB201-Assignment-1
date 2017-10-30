using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TankBattle
{
	/// <summary>
	/// Concrete class extending the opponent class. This is a computer-controlled opponent/s. 
	/// 
	/// Author John Santias and Hoang Nguyen October 2017
	/// </summary>
	public class AIOpponent : Opponent
    {
		private string name;
		private TankModel tank;
		private Color colour;
        private Random rnd = new Random();
        private GameplayForm gameplayform;

		/// <summary>
		/// Constructor for the AIOpponent class. It mostly exists to pass its parameters to the base constructor.
		/// 
		/// Author John Santias and Hoang Nguyen October 2017
		/// </summary>
		/// <param name="name">Name set onto this AI opponent</param>
		/// <param name="tank">The tank model assiociated with this AI</param>
		/// <param name="colour">The colour associated with this AI</param>
		public AIOpponent(string name, TankModel tank, Color colour) : base(name, tank, colour)
        {
			this.name = name;
			this.tank = tank;
			this.colour = colour;
        }

		/// <summary>
		/// Called each round, allowing the AIOpponent to refresh its knowledge of the gameplay state, 
		/// knowing that the tanks have been placed in a different order.
		/// 
		/// Author John Santias and Hoang Nguyen October 2017
		/// </summary>
		public override void StartRound()
        {
            
        }

		/// <summary>
		/// Called when it's this player's turn. The player will need to call methods in gameplayForm 
		/// such as SetWeaponIndex(), SetAimingAngle(), SetPower() and finally Attack() to aim and fire the weapon.
		/// 
		/// Author John Santias October 2017
		/// </summary>
		/// <param name="gameplayForm"></param>
		/// <param name="currentGame"></param>
		public override void BeginTurn(GameplayForm gameplayForm, Gameplay currentGame)
        {
            gameplayform = gameplayForm;
            gameplayform.SetWeaponIndex(1);
            float angle = rnd.Next(-90, 91);
            gameplayform.SetAimingAngle(angle);
            int power = rnd.Next(0, 101);
            gameplayForm.SetPower(power);
            gameplayForm.Attack();
        }

		/// <summary>
		/// Called each time a shot fired by this player hits, allowing the computer to adjust its aim.
		/// 
		/// Author John Santias and Hoang Nguyen October 2017
		/// </summary>
		/// <param name="x"></param>
		/// <param name="y"></param>
		public override void ProjectileHitPos(float x, float y)
        {
            
        }
    }
}
