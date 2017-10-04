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
        public Gameplay(int numPlayers, int numRounds)
        {
            throw new NotImplementedException();
        }

        public int PlayerCount()
        {
            throw new NotImplementedException();
        }

        public int GetRound()
        {
            throw new NotImplementedException();
        }

        public int GetTotalRounds()
        {
            throw new NotImplementedException();
        }

        public void SetPlayer(int playerNum, Opponent player)
        {
            throw new NotImplementedException();
        }

        public Opponent GetPlayerNumber(int playerNum)
        {
            throw new NotImplementedException();
        }

        public ControlledTank PlayerTank(int playerNum)
        {
            throw new NotImplementedException();
        }

        public static Color GetTankColour(int playerNum)
        {
            throw new NotImplementedException();
        }

        public static int[] CalculatePlayerPositions(int numPlayers)
        {
            throw new NotImplementedException();
        }

        public static void Shuffle(int[] array)
        {
            throw new NotImplementedException();
        }

        public void NewGame()
        {
            throw new NotImplementedException();
        }

        public void BeginRound()
        {
            throw new NotImplementedException();
        }

        public Terrain GetLevel()
        {
            throw new NotImplementedException();
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
