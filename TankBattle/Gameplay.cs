using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;

namespace TankBattle {
    public class Gameplay {
        private int[] numPlayers;
        private int numRounds;
        private int currentPlayer;
        private List<WeaponEffect> WeaponsEffect;
        private int currentRound;
        private int opponent;
        private Terrain newTerrain;
        private Opponent[] TheOppo;
        private int Wind;
        private ControlledTank[] TheTank;
        private Random rnd = new Random();

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
			Color[] TheColor = new Color[] { Color.Blue, Color.Red, Color.Orange, Color.Yellow, Color.Green, Color.Indigo, Color.Violet, Color.Turquoise };
            return TheColor[playerNum - 1];
        }

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

                int tmp = array[number1];
                array[number1] = array[number2];
                array[number2] = tmp;
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
            for (int i = 0; i < TheTank.Length; i++)
			{
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
            return TheTank[currentPlayer];
        }

        public void AddWeaponEffect(WeaponEffect weaponEffect)
		{

            WeaponsEffect.Add(weaponEffect);
            weaponEffect.RecordCurrentGame(this);

        }

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

        public void RenderEffects(Graphics graphics, Size displaySize)
		{
            if (ProcessEffects()) {
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

        public bool CheckHitTank(float projectileX, float projectileY) 
        {
            if (projectileX < 0 || projectileX > Terrain.WIDTH || projectileY < 0 || projectileY > Terrain.HEIGHT)
			{
				return false;
			}
            if (newTerrain.IsTileAt((int)projectileX, (int)projectileY))
			{
                return true;
            }
			if (GetCurrentGameplayTank().Exists() && (GetCurrentGameplayTank().GetX() == projectileX && GetCurrentGameplayTank().GetYPos() == projectileY))
			{
				return true;
			}

			for (int i = 0; i < TheTank.Length; i++)
			{
				if ((projectileX >= TheTank[i].GetX() && projectileX <= TheTank[i].GetX() + TankModel.WIDTH) && i != currentPlayer) //if shell hits tank inside its rectangle
				{
					if ((projectileY >= TheTank[i].GetYPos() && projectileY <= TheTank[i].GetYPos() + TankModel.HEIGHT) && i != currentPlayer)
					{ 
						return true;
					}
				}
			}
			return false;
        }

        public void InflictDamage(float damageX, float damageY, float explosionDamage, float radius)
        {
            for (int i = 0; i < TheTank.Length; i++)
			{
                if (TheTank[i].Exists())
				{
                    float dist;
                    double tempDist;
					int damageDone = 0;
					float tempDamage = 0;
					float tankPositionX;
					float tankPositionY;

					tankPositionX = (TheTank[i].GetX() + (TankModel.WIDTH / 2));
                    tankPositionY = (TheTank[i].GetYPos() + (TankModel.HEIGHT / 2));

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
                    TheTank[i].InflictDamage(damageDone);

                }
            }
        }

        public bool Gravity() 
        {
            bool anyMovement = false;
            newTerrain.Gravity();
			if (newTerrain.Gravity() == true)
            {
                anyMovement = true;
            }
            for (int i = 0; i < TheTank.Length; i++)
			{
                newTerrain.Gravity();
                if (TheTank[i].Gravity() == true)
				{
                    anyMovement = true;
                }
            }
            return anyMovement;
        }

        public bool TurnOver() 
        {
            int howManyExists = 0;

            for (int i = 0; i < TheTank.Length; i++)
			{
                if (TheTank[i].Exists())
                {
                    howManyExists++;
                }
            }

			if (howManyExists >= 2) 
			{
				for (int i = 0; i < howManyExists; i++)
				{
					currentPlayer++;
					if (currentPlayer >= TheTank.Length)
					{
						currentPlayer = 0;
					}
					if (TheTank[currentPlayer].Exists())
					{
						Wind += rnd.Next(-10, 10);
						if (Wind <= -100) { Wind = -100; } else if (Wind >= 100) { Wind = 100; }
						return true;
					}
				}
				//    if (currentPlayer == numPlayers.Length) { currentPlayer = 0; }
				//    if (!TheTank[currentPlayer].Exists()) {
				//        currentPlayer++;
				//    }
				//    Wind += rnd.Next(-10, 10);
				//    if (Wind <= -100) { Wind = -100; } else if (Wind >= 100) { Wind = 100; }
				//    return true;
			}
			else if (howManyExists < 2) //if there is one tank left
            {
                RewardWinner();
                return false;
            }
            return false;
        }

        public void RewardWinner() //double check
        {
            for (int i = 0; i < TheTank.Length; i++)
			{
                if (TheTank[i].Exists())
				{
                    TheOppo[currentPlayer].AddScore(); //correct tank? //option 1
                    // GetPlayerNumber(TheTank[i]).AddScore(); //option 2
                }
            }
        }

        public void NextRound() //double check
        {
            if (!TurnOver())
			{
                if (currentRound <= numRounds)
				{
                    currentRound++;
                }
                currentPlayer++;
                if (currentPlayer > numPlayers.Length - 1)
				{
                    currentPlayer = 0;
                    BeginRound();
				}
				else if (currentRound > numRounds)
				{
					Rankings ranks = new Rankings(numPlayers.Length, TheOppo);
					ranks.Show();
				}
            }
        }

        public int GetWindSpeed()
		{
            Random rnd = new Random();
            Wind = rnd.Next(-100, 101);
            return Wind;
        }
    }
}
