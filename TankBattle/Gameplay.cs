using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;

namespace TankBattle 
{
    public class Gameplay 
{
		private int[] numPlayers;
		private int numRounds, currentPlayer, currentRound, opponent, wind;
        private List<WeaponEffect> WeaponsEffect;
        private Terrain newTerrain;
        private Opponent[] theOppo;
        private ControlledTank[] theTank;
        private Random rnd = new Random();

		private bool winnerFound = false;

		/// <summary>
		/// This is the gameplay's constructor. Called with number of players and the number of rounds in the game
		/// The constructor creates an array with the number of players (numPlayers) and stores it on to a private 
		/// variable. The amount of rounds to be played in the game is stored in the private variable.
		/// A new opponent is created with the number of players and a new list is created to store the weapons.
		/// 
		/// Author John Santias and Hoang Nguyen September 2017
		/// </summary>
		/// <param name="numPlayers">The number of players in the game</param>
		/// <param name="numRounds">The number of rounds in the game</param>
		public Gameplay(int numPlayers, int numRounds)
		{
            this.numPlayers = new int[numPlayers];
            this.numRounds = numRounds;
            theOppo = new Opponent[numPlayers];
            WeaponsEffect = new List<WeaponEffect>();
        }

		/// <summary>
		/// This method returns the total number of players in the game.
		/// 
		/// Author John Santias and Hoang Nguyen September 2017
		/// </summary>
		/// <returns>number of players in the game</returns>
		public int PlayerCount()
		{
            return numPlayers.Length;
        }

		/// <summary>
		/// This method return the current round of the game
		/// 
		/// Author John Santias and Hoang Nguyen September 2017
		/// </summary>
		/// <returns>the current round</returns>
		public int GetRound()
		{
            return currentRound;
        }

		/// <summary>
		/// Returns the total number of rounds the game will last for.
		/// 
		/// Author John Santias and Hoang Nguyen September 2017
		/// </summary>
		/// <returns>the number of rounds in the game</returns>
		public int GetTotalRounds()
		{
            return numRounds;
        }

		/// <summary>
		/// Takes the player number between one and the number of players and assigns the appropriate field in 
		/// Gameplay's opponent to the player.
		/// 
		/// Author John Santias and Hoang Nguyen September 2017
		/// </summary>
		/// <param name="playerNum">The current player number</param>
		/// <param name="player">A reference of Opponent stored as player</param>
		public void SetPlayer(int playerNum, Opponent player)
		{
            theOppo[playerNum - 1] = player;
        }

		/// <summary>
		/// Takes player number between one and the number of players and returns the appropriate opponent from
		/// the opponent array.
		/// 
		/// Author John Santias and Hoang Nguyen September 2017
		/// </summary>
		/// <param name="playerNum">The current player number</param>
		/// <returns>The opponent's player number</returns>
		public Opponent GetPlayerNumber(int playerNum)
		{
            return theOppo[playerNum - 1];
        }

		/// <summary>
		/// Takes player number between one and the number of players and returns the ControlledTank associated
		/// with the opponent of that number.
		/// 
		/// Author John Santias and Hoang Nguyen September 2017
		/// </summary>
		/// <param name="playerNum">The current player number</param>
		/// <returns>ControlledTank associated with the opponent</returns>
		public ControlledTank PlayerTank(int playerNum)
		{
            return theTank[playerNum - 1];
        }

		/// <summary>
		/// Gets the player number and returns the appropriate colour used to represent that player. 
		/// A list of colours are created then selected on the player's number. E.g. player number is 5, the method
		/// will return the 5th colour in the list.
		/// 
		/// Author John Santias September 2017
		/// </summary>
		/// <param name="playerNum">The current player number</param>
		/// <returns>Colour associated with the playernum</returns>
		public static Color GetTankColour(int playerNum)
		{
			Color[] TheColor = new Color[] { Color.Blue, Color.Red, Color.Orange, Color.Yellow, Color.Green, Color.Indigo, Color.Violet, Color.Turquoise };
            return TheColor[playerNum - 1];
        }

		/// <summary>
		/// Calculates the horizontal positions of each player on the map. An array of coordinates is created with a size of the
		/// number of players in the game. Each player's x positions are calculated and stored in the array. The array is returned.
		/// 
		/// Author Hoang Nguyen October 2017
		/// </summary>
		/// <param name="numPlayers">The current player number</param>
		/// <returns>Array of player's coordinates</returns>
		public static int[] CalculatePlayerPositions(int numPlayers)
		{
            int[] coords = new int[numPlayers];

            int terrainW = Terrain.WIDTH / numPlayers;
            int spaceBetweenTanks = terrainW / 2;

            if (numPlayers == 2) {
                coords[0] = spaceBetweenTanks;
                coords[1] = spaceBetweenTanks + terrainW;
			}
			else {
                for (int i = 1; i < numPlayers; i++)
				{
                    coords[0] = spaceBetweenTanks;
                    coords[i] = coords[i - 1] + terrainW;
                }
            }
            return coords;
        }

		/// <summary>
		/// Shuffles a given array. 
		/// {0, 1, 2, 3} might become {0, 3, 1, 2} or {1, 2, 0, 3} or {3, 1, 2, 0} etc.
		/// 
		/// Author John Santias September 2017
		/// </summary>
		/// <param name="array">Any array to be shuffled</param>
		public static void Shuffle(int[] array)
		{
            Random rndA = new Random();
            Random rndB = new Random();
            for (int i = array.Length; i >= 1; i--)
			{
                int number1 = rndA.Next(0, array.Length), number2 = rndB.Next(0, array.Length);

                while (number1 == number2)
				{
					number2 = rndB.Next(0, array.Length);
                }

                int tmp = array[number1]; //gets the first number in list for swapping
                array[number1] = array[number2]; //swaps with the second selected number in list
                array[number2] = tmp;
            }
        }

		/// <summary>
		/// This begins a new game. The current round is initialised to 1. Starting opponent initialised to
		/// 0 and BeginRound() is called.
		/// 
		/// Author John Santias September 2017
		/// </summary>
		public void NewGame()
		{
            currentRound = 1;
            opponent = 0;
            BeginRound();
        }

		/// <summary>
		/// Begins new round of gamplay. A game consists of multiple rounds and rounds consists of multiple
		/// turns. The method initialises the private field of Gameplay setting currentplayer to starting
		/// opponent. Creates new Terrain and an shuffled array of opponent's positions. Tanks are then placed
		/// on their positions. The wind speed of the game is set.
		/// Finally, the gameplay form is shown and game is ready to be played. 
		/// 
		/// Author John Santias September 2017
		/// </summary>
		public void BeginRound()
		{
            currentPlayer = opponent;
            newTerrain = new Terrain();
            int[] thepos = CalculatePlayerPositions(theOppo.Length);

            for (int i = 0; i < theOppo.Length - 1; i++)
			{
                theOppo[i].StartRound();
            }

            Shuffle(thepos);
            theTank = new ControlledTank[theOppo.Length];
            for (int i = 0; i < theTank.Length; i++)
			{
                theTank[i] = new ControlledTank(theOppo[i], thepos[i], newTerrain.TankYPosition(thepos[i]), this);
            }

            GetWindSpeed();

            GameplayForm newForm = new GameplayForm(this);
            newForm.Show();
        }

		/// <summary>
		/// Returns the current terrain used by the game. The current terrain is stored in the in the private
		/// field and initialised by BeginRound().
		/// 
		/// Author John Santias September 2017
		/// </summary>
		/// <returns>The current terrain used in the game</returns>
		public Terrain GetLevel()
		{
            return newTerrain;
        }


		/// <summary>
		/// Tells all ControlledTanks to draw theirselves. The graphics and displaySize are passed along the 
		/// Draw() method in ControlledTank. This method loops through each ControlledTanks in the array, checks
		/// if it is still around and the calls the Draw() method.
		/// 
		/// Author John Santias October 2017
		/// </summary>
		/// <param name="graphics">Kind of graphics to use on the player's tank</param>
		/// <param name="displaySize">Size of the display look of tank</param>
		public void DrawPlayers(Graphics graphics, Size displaySize)
		{
            for (int i = 0; i < theTank.Length; i++)
			{ 
                if (theTank[i].Exists())
				{
                    theTank[i].Draw(graphics, displaySize);
                }
            }
        }

		/// <summary>
		/// Returns the ControlledTank associated with the current player. 
		/// 
		/// Author John Santias October 2017
		/// </summary>
		/// <returns>ControlledTank of the player</returns>
		public ControlledTank GetCurrentGameplayTank()
		{
            return theTank[currentPlayer];
        }

		/// <summary>
		/// Adds given weaponEffect to the list/array of WeaponEffects. Adds the weaponEffect to the 
		/// first blank spot in the list/array.
		/// 
		/// Author John Santias October 2017
		/// </summary>
		/// <param name="weaponEffect">The weapon's effect to be used by the tank</param>
		public void AddWeaponEffect(WeaponEffect weaponEffect)
		{

            WeaponsEffect.Add(weaponEffect);
            weaponEffect.RecordCurrentGame(this);

        }

		/// <summary>
		/// Loops through all weaponeffects in the array/list, calling Process() on each. Determines if
		/// any tank shells or explosions still being animated. Animation doesn't stop until they are all
		/// gone.
		/// 
		/// Author John Santias October 2017
		/// </summary>
		/// <returns></returns>
		public bool ProcessEffects()
		{
            bool weaponExist = false;

            for (int i = 0; i < WeaponsEffect.Count; i++)
			{
                WeaponsEffect[i].Process();
                weaponExist = true;
            }
            return weaponExist;
        }

		/// <summary>
		/// Loops through all WeaponEffects in the array, calling Draw() on each. The graphics and displaySize aren't
		/// used in this method but passed on to the Draw() method. 
		/// 
		/// Author John Santias October 2017
		/// </summary>
		/// <param name="graphics">Kind of graphics to use on the player's tank</param>
		/// <param name="displaySize">The size of the display look of tank</param>
		public void RenderEffects(Graphics graphics, Size displaySize)
		{
            if (ProcessEffects()) {
                for (int i = 0; i < WeaponsEffect.Count; i++)
				{
                    WeaponsEffect[i].Draw(graphics, displaySize);
                }
            }
        }

		/// <summary>
		/// Removes the WeaponEffect referenced by weaponEffect from the array or list used by Gameplay to store
		/// active WeaponEffects. 
		/// 
		/// Author John Santias October 2017
		/// </summary>
		/// <param name="weaponEffect">The weapon's effect to be used by the tank</param>
		public void EndEffect(WeaponEffect weaponEffect)
		{
            if (WeaponsEffect.Contains(weaponEffect))
			{
                WeaponsEffect.Remove(weaponEffect);
            }
        }

		/// <summary>
		/// Returns true if a Shell at projectileX, projectileY will hit the tank. The position of the projectile 
		/// and tank is compared. If the projectile is in within the tank's square (or inside the tank), this method
		/// returns true and the damage to the tank is calculated in InflictDamage().
		/// 
		/// Author John Santias October 2017
		/// </summary>
		/// <param name="projectileX">X position of the projectile/shell</param>
		/// <param name="projectileY">Y position of the projectile/shell</param>
		/// <returns></returns>
		public bool CheckHitTank(float projectileX, float projectileY) 
        {
            if (projectileX < 0 || projectileX > Terrain.WIDTH || projectileY < 0 || projectileY > Terrain.HEIGHT) //if projectile offscreen 
			{
				return false;
			}
            if (newTerrain.IsTileAt((int)projectileX, (int)projectileY))
			{
                return true;
            }
			if (GetCurrentGameplayTank().Exists() && (GetCurrentGameplayTank().GetX() == projectileX && GetCurrentGameplayTank().GetYPos() == projectileY)) //projectile in same position as the tank
			{
				return true;
			}

			for (int i = 0; i < theTank.Length; i++)
			{
				//if shell hits tank inside its rectangle
				if ((projectileX >= theTank[i].GetX() && projectileX <= theTank[i].GetX() + TankModel.WIDTH) && i != currentPlayer)  //projectile is in between the left and the right side of the tank
				{ 
					if ((projectileY >= theTank[i].GetYPos() && projectileY <= theTank[i].GetYPos() + TankModel.HEIGHT) && i != currentPlayer) //projectile is in between the top and bottom of the tank
					{ 
						return true;
					}
				}
			}
			return false;
        }

		/// <summary>
		/// Inflicts up to explosionDamage damage on any ControlledTanks within the circle described by damageX, 
		/// damgeY, and radius.
		/// 
		/// Author Hoang Nguyen October 2017
		/// </summary>
		/// <param name="damageX">The X position of where the explosion starts</param>
		/// <param name="damageY">The Y position of where the explosion starts</param>
		/// <param name="explosionDamage">The damage amount the explosion can cause</param>
		/// <param name="radius">The radius of the explosion</param>
		public void InflictDamage(float damageX, float damageY, float explosionDamage, float radius)
        {
            for (int i = 0; i < theTank.Length; i++)
			{
                if (theTank[i].Exists())
				{
                    float dist;
                    double tempDist;
					int damageDone = 0;
					float tempDamage = 0;
					float tankPositionX;
					float tankPositionY;

					tankPositionX = (theTank[i].GetX() + (TankModel.WIDTH / 2));
                    tankPositionY = (theTank[i].GetYPos() + (TankModel.HEIGHT / 2));

                    tempDist = Math.Sqrt(Math.Pow(damageX - tankPositionX, 2) + Math.Pow(damageY - tankPositionY, 2));
                    dist = (float)tempDist;

                    if (dist > radius)
					{
                        tempDamage = 0;
                    }
					else if (dist > radius && dist < radius / 2)
					{
                        tempDamage = (explosionDamage * (radius - dist) / radius);
                    }
					else if (dist < radius / 2)
					{
                        tempDamage = explosionDamage;
                    }

                    damageDone = (int)tempDamage;
                    theTank[i].InflictDamage(damageDone);

                }
            }
        }

		/// <summary>
		/// Called after all WeaponEffect animations have finished and moves any terrain and/or
		/// ControlledTanks that are floating in the air down. Similar to ProcessEffects, this
		/// returns false once there is nothing left to move, and true until then.
		/// 
		/// Author John Santias and Hoang Nguyen October 2017
		/// </summary>
		/// <returns></returns>
		public bool Gravity() 
        {
            bool anyMovement = false;
            newTerrain.Gravity();
			if (newTerrain.Gravity())
            {
                anyMovement = true;
            }
            for (int i = 0; i < theTank.Length; i++)
			{
                newTerrain.Gravity();
                if (theTank[i].Gravity())
				{
                    anyMovement = true;
                }
            }
            return anyMovement;
        }

		/// <summary>
		/// Called once the current turn is over. It checks how many ControlledTanks are in battle,
		/// detemines where the round is over or not, if it isn't, the current player changes to the
		/// next player that is still alive. This returns true if the round is still going. False, if
		/// over.
		/// 
		/// Author John Santias and Hoang Nguyen October 2017
		/// </summary>
		/// <returns></returns>
		public bool TurnOver() 
        {
            int howManyExists = 0;

            for (int i = 0; i < theTank.Length; i++)
			{
                if (theTank[i].Exists())
                {
                    howManyExists++;
                }
            }

			if (howManyExists >= 2) 
			{
				for (int i = 0; i < howManyExists; i++)
				{
					currentPlayer++;
					if (currentPlayer >= theTank.Length)
					{
						currentPlayer = 0;
					}
					if (theTank[currentPlayer].Exists())
					{
						wind += rnd.Next(-10, 10);
						if (wind <= -100)
						{
							wind = -100;
						}
						else if (wind >= 100)
						{
							wind = 100;
						}
						return true;
					}
				}
			}
			if (howManyExists < 2) 
            {
				RewardWinner();
                return false;
            }
            return false;
        }

		/// <summary>
		/// When the current round is over. It finds out which player won the round and rewards that player with a point. 
		/// 
		/// Author John Santias October 2017
		/// </summary>
		public void RewardWinner() 
        {
			if (winnerFound) 
			{
				return; //prevents multiple counts in addings scores
			}
            for (int i = 0; i < theTank.Length; i++)
			{
				if (winnerFound)
				{
					break;
				}
                else if (theTank[i].Exists())
				{
					winnerFound = true;
                    theOppo[i].AddScore();
                }
            }
        }

		/// <summary>
		/// Called after the current round is over. GameplayForm decides whether the round is over based on whether 
		/// TurnOver() returned true or false.
		/// 
		/// Author John Santias Nguyen October 2017
		/// </summary>
		public void NextRound() 
        {
			if (currentRound == numRounds)
			{
				Rankings ranks = new Rankings(numPlayers.Length, theOppo);
				ranks.Show();
			}
			else if (!TurnOver())
			{
                currentRound++;
                currentPlayer = 0;
                BeginRound();
				if (winnerFound)
				{
					winnerFound = false; //resets the bool for the TurnOver() method
				}
            }
        }

		/// <summary>
		/// Returns current wind speend. Ranges between -100, 100;
		/// 
		/// Author John Santias October 2017
		/// </summary>
		/// <returns>Current wind speed</returns>
		public int GetWindSpeed()
		{
            Random rnd = new Random();
            wind = rnd.Next(-100, 101);
            return wind;
        }
    }
}