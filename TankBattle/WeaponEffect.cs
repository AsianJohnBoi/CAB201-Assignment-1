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
	/// Abstract class represents a generic effect created by a ControlledTank's attack. Both Blast and Shell come
	/// under this umbrella.
	/// 
	/// Author John Santias and Hoang Nguyen October 2017
	/// </summary>
	public abstract class WeaponEffect
    {
        protected Gameplay i;

		/// <summary>
		/// Called in Gameplay's AddWeaponEffect. The value of 'game' should be assigned to a 
		/// protected field in WeaponEffect so that methods in Blast and Shell can use it.
		/// 
		/// Author John Santias October 2017
		/// </summary>
		/// <param name="game">The current game played</param>
		public void RecordCurrentGame(Gameplay game)
        {
            i = game;
        }
		/// <summary>
		/// This moved the given projectile according to its angle, power, gravity and the wind. 
		/// </summary>
        public abstract void Process();

		/// <summary>
		/// Draws the Shells as a small white circle
		/// </summary>
		/// <param name="graphics">The looks of the shell</param>
		/// <param name="displaySize">The size of the shell</param>
        public abstract void Draw(Graphics graphics, Size displaySize);
    }
}
