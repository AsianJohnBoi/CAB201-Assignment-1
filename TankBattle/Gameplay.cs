using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace TankBattle
{
	public class Gameplay
	{
		private int[] numPlayers;
		private int[] numRounds;
		private int playerNum;
        private int currentPlayer;
		private List<string> WeaponsEffect;
		private int currentRound;
		private int opponent;
		private int x;
		private Terrain newTerrain;
		private Opponent[] TheOppo;
        private int Wind;
        private ControlledTank[] TheTank;

		public Gameplay(int numPlayers, int numRounds)
		{
			this.numPlayers = new int[numPlayers];
			this.numRounds = new int[numRounds];
			WeaponsEffect = new List<string>();
		}

		public int PlayerCount()
		{
			return numPlayers.Length;
		}

		public int GetRound()
		{
			return currentRound;
		}

		public int GetTotalRounds()
		{
			return numRounds.Length;
		}

		public void SetPlayer(int playerNum, Opponent player)
		{
			playerNum = numPlayers.Length - 1;
		}

		public Opponent GetPlayerNumber(int playerNum)
		{
			return TheOppo[playerNum - 1];
		}

		public ControlledTank PlayerTank(int playerNum)
		{
			TankModel tank = TankModel.GetTank(1);
			x = playerNum;

			TheTank = new ControlledTank[x];
			{
				//not implemented, not sure
			};
			return TheTank[playerNum];
		}

		public static Color GetTankColour(int playerNum)
		{
			Color[] TheColor = new Color[] { Color.AliceBlue, Color.Beige, Color.Chocolate, Color.Gold, Color.Orange, Color.Violet, Color.Yellow, Color.Green };
			return TheColor[playerNum - 1];
		}

		public static int[] CalculatePlayerPositions(int numPlayers)
		{	
			int TerrainW = (Terrain.WIDTH / numPlayers);
			int x = 0;
			int y = 40;
			int[] coords = new int[numPlayers * 2];

			for (int i = 0; i >= numPlayers; i++)
			{
				x = x + TerrainW;
				coords[i] = x; //add x position to list, loops to replace the previous int
			}
			return coords;
		}

		public static void Shuffle(int[] array)
		{
			int[] shuffledArray = array;
			int rndNo;
			Random rnd = new Random();
			for (int i = array.Length; i >= 1; i--)
			{
				rndNo = rnd.Next(1, i + 1) - 1;
				shuffledArray[i - 1] = array[rndNo];
				array[rndNo] = array[i - 1];
			}
			array = shuffledArray;
		}
		public void NewGame()
		{
			currentRound = 1;
			opponent = 0;
			BeginRound();
		}

		public void BeginRound()
		{
            currentPlayer = opponent; 
			newTerrain = new Terrain(); 
			int[] thepos = CalculatePlayerPositions(TheOppo.Length);                                  
            
			for (int i = 0; i < TheOppo.Length - 1; i++)
			{
				TheOppo[i].StartRound();
			}

            Shuffle(thepos);
            TheTank = new int[TheOppo.Length];
            for (int i = 0; i < TheTank.Length; i++){
                TheTank[i] = new ControlledTank(TheOppo[i], thepos[i], newTerrain.TankYPosition(thepos[i]), this);
            }
            
            GetWindSpeed();

            GameplayForm newForm = new GameplayForm();
            newForm.Show();
		}

		public Terrain GetLevel()
		{
			return newTerrain;
		}

		public void DrawPlayers(Graphics graphics, Size displaySize)
		{
			throw new NotImplementedException();
		}

		public ControlledTank GetCurrentGameplayTank()
		{
			throw new NotImplementedException();
		}

		public void AddWeaponEffect(WeaponEffect weaponEffect)
		{
			throw new NotImplementedException();
		}

		public bool ProcessEffects()
		{
			throw new NotImplementedException();
		}

		public void RenderEffects(Graphics graphics, Size displaySize)
		{
			throw new NotImplementedException();
		}

		public void EndEffect(WeaponEffect weaponEffect)
		{
			throw new NotImplementedException();
		}

		public bool CheckHitTank(float projectileX, float projectileY)
		{
			throw new NotImplementedException();
		}

		public void InflictDamage(float damageX, float damageY, float explosionDamage, float radius)
		{
			throw new NotImplementedException();
		}

		public bool Gravity()
		{
			throw new NotImplementedException();
		}

		public bool TurnOver()
		{
			throw new NotImplementedException();
		}

		public void RewardWinner()
		{
			throw new NotImplementedException();
		}

		public void NextRound()
		{
			throw new NotImplementedException();
		}

		public int GetWindSpeed()
		{
            Random rnd = new Random();
			Wind = rnd.Next(-100, 101);
            return Wind;
		}
	}
}