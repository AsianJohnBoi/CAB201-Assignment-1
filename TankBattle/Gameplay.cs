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
        //check if array / int
		private int[] numPlayers;
		private int numRounds;
		private int playerNum;
        private int currentPlayer;
		private List<WeaponEffect> WeaponsEffect;
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
			this.numRounds = numRounds;
            TheOppo = new Opponent[numPlayers];
			WeaponsEffect = new List<WeaponEffect>();
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
			return numRounds;
		}

		public void SetPlayer(int playerNum, Opponent player)
		{
            TheOppo[playerNum - 1] = player;
		}

		public Opponent GetPlayerNumber(int playerNum)
		{
			return TheOppo[playerNum - 1];
		}

		public ControlledTank PlayerTank(int playerNum)
		{
			return TheTank[playerNum - 1];
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
			Random rndA = new Random();
            Random rndB = new Random();
			for (int i = array.Length; i >= 1; i--)
			{

                int idxA = rndA.Next(0,array.Length), idxB = rndB.Next(0,array.Length);

                while (idxA==idxB)
                {
                    idxB = rndB.Next(0, array.Length);
                }

                int tmp = array[idxA];
                array[idxA] = array[idxB];
                array[idxB] = tmp;
			}
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
            TheTank = new ControlledTank[TheOppo.Length];
            for (int i = 0; i < TheTank.Length; i++){
                TheTank[i] = new ControlledTank(TheOppo[i], thepos[i], newTerrain.TankYPosition(thepos[i]), this);
            }
            
            GetWindSpeed();

            GameplayForm newForm = new GameplayForm(this);
            newForm.Show();
		}

		public Terrain GetLevel()
		{
			return newTerrain;
		}

		public void DrawPlayers(Graphics graphics, Size displaySize)
		{
			for (int i = 0; i < TheTank.Length; i++)
            {
                if (TheTank[i].Exists())
                {
                    TheTank[i].Draw(graphics, displaySize);
                }
            }
		}

		public ControlledTank GetCurrentGameplayTank()
		{
            return TheTank[playerNum];
		}

		public void AddWeaponEffect(WeaponEffect weaponEffect)
		{
			for (int i = 0; i < WeaponsEffect.Count; i++)
            {
                if (WeaponsEffect[i] == null)
                {
                    WeaponsEffect[i] = weaponEffect;
                }
            }
		}

		public bool ProcessEffects()
		{
            bool weaponExist = false;
			for (int i = 0; i < WeaponsEffect.Count; i++)
            {
                if (WeaponsEffect[i] != null) { weaponExist = true;}
                else { weaponExist = false; }
            }
            return weaponExist;
		}

		public void RenderEffects(Graphics graphics, Size displaySize)
		{
            if (ProcessEffects())
            {
                for (int i = 0; i < WeaponsEffect.Count; i++)
                {
                    WeaponsEffect[i].Draw(graphics, displaySize);
                }
            }
		}

		public void EndEffect(WeaponEffect weaponEffect)
		{
            if (WeaponsEffect.Contains(weaponEffect))
            {
                WeaponsEffect.Remove(weaponEffect);
            }
		}

		public bool CheckHitTank(float projectileX, float projectileY) //double check
		{
            bool hit = false;
			if (projectileX < 0 | projectileX > Terrain.WIDTH || projectileY < 0 || projectileY > Terrain.HEIGHT) { hit = false; }
            else if (newTerrain.IsTileAt((int)projectileX, (int)projectileY))
            {
                hit = true;
            }
            for (int i = 0; i < TheTank.Length; i++)
            {
                if (i == playerNum)   //prevent current tank hitting itself
                {
                    i++;
                }
                if (TheTank[i].Exists() && (TheTank[i].GetX() == projectileX && TheTank[i].GetYPos() == projectileY))
                {
                    hit = true;
                }
                else if (TheTank[i].Exists() && (projectileX <= TheTank[i].GetX() + TankModel.WIDTH &&   projectileY <= TheTank[i].GetYPos() + TankModel.HEIGHT))
                {
                    hit = true;
                }
            }
            return hit;
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