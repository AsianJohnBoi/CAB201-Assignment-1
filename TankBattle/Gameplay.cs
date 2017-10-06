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
		private List<string> WeaponsEffect;
		private int currentRound;
		private int opponent;


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
			throw new NotImplementedException();
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
			TankModel tank = TankModel.GetTank(1);
			Opponent[] TheOppo = new Opponent[]
			{
			};
			return TheOppo[playerNum];
		}

		public ControlledTank PlayerTank(int playerNum)
		{
			throw new NotImplementedException();
		}

		public static Color GetTankColour(int playerNum)
		{
			Color[] TheColor = new Color[] { Color.AliceBlue, Color.Beige, Color.Chocolate, Color.Gold, Color.Orange, Color.Violet, Color.Yellow, Color.Green };
			return TheColor[playerNum - 1];
		}

		public static int[] CalculatePlayerPositions(int numPlayers)
		{
			throw new NotImplementedException();
		}

		public static void Shuffle(int[] array)
		{
			int[] shuffledArray = new int[array.Length];
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
			this.currentRound = 1;
			this.opponent = 0;
			BeginRound();
		}

		public void BeginRound()
		{

		}

		public Terrain GetLevel()
		{
			Terrain newRound = new Terrain();
			return newRound;
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
			throw new NotImplementedException();
		}
	}
}