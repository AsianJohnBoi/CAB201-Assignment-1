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

        public int GetNumPlayers()
        {
            throw new NotImplementedException();
        }

        public int GetCurrentRound()
        {
            throw new NotImplementedException();
        }

        public int GetTotalRounds()
        {
            throw new NotImplementedException();
        }

        public void SetPlayer(int playerNum, Player player)
        {
            throw new NotImplementedException();
        }

        public Player GetPlayer(int playerNum)
        {
            throw new NotImplementedException();
        }

        public BattleTank GetBattleTank(int playerNum)
        {
            throw new NotImplementedException();
        }

        public static Color PlayerColour(int playerNum)
        {
            throw new NotImplementedException();
        }

        public static int[] GetPlayerLocations(int numPlayers)
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

        public Terrain GetMap()
        {
            throw new NotImplementedException();
        }

        public void DisplayTanks(Graphics graphics, Size displaySize)
        {
            throw new NotImplementedException();
        }

        public BattleTank GetPlayerTank()
        {
            throw new NotImplementedException();
        }

        public void AddAttackEffect(Attack weaponEffect)
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

        public void RemoveWeaponEffect(Attack weaponEffect)
        {
            throw new NotImplementedException();
        }

        public bool CheckCollidedTank(float projectileX, float projectileY)
        {
            throw new NotImplementedException();
        }

        public void DamageArmour(float damageX, float damageY, float explosionDamage, float radius)
        {
            throw new NotImplementedException();
        }

        public bool CalculateGravity()
        {
            throw new NotImplementedException();
        }

        public bool FinishTurn()
        {
            throw new NotImplementedException();
        }

        public void FindWinner()
        {
            throw new NotImplementedException();
        }

        public void NextRound()
        {
            throw new NotImplementedException();
        }
        
        public int Wind()
        {
            throw new NotImplementedException();
        }
    }
}
