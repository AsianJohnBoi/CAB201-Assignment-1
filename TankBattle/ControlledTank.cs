using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace TankBattle {
    /// <summary>
    /// 
    /// This class represents a tank on the battlefield, as 
    /// distince from Tank Model which represents a particular 
    /// model of tank.
    /// 
    /// Author John Santias and Hoang Nguyen October 2017
    /// 
    /// </summary>
    public class ControlledTank {
        private Opponent player;
        private int tankX;
        private int tankY;
        private Gameplay game;
        private TankModel tankModel;
        private int currentDur;
        private int power;
        private int angle;
        private int tankWeapon;
        private Bitmap colour;

        /// <summary>
        /// 
        /// This constructor initializes a new instance of the ControlledTank class. 
        /// It also stores the tankModel by usubg the Opponents GetTank() method, and 
        /// GetArmour() for the current durability of the TankModel. In addition, it also
        /// stores the angle, power, current weapons and colour of the tank which is a bitmap.
        /// 
        /// Author John Santias and Hoang Nguyen October 2017
        /// 
        /// </summary>
        /// <param name="player"> A reference of Opponent stored as player </param>
        /// <param name="tankX"> The x coordinate of the tank </param>
        /// <param name="tankY"> The y coordinate of the tank </param>
        /// <param name="game"> A reference of Gameplay stored as game </param>
		public ControlledTank(Opponent player, int tankX, int tankY, Gameplay game) {
            this.player = player;
            this.tankX = tankX;
            this.tankY = tankY;
            this.game = game;
            tankModel = player.GetTank();
            currentDur = tankModel.GetArmour();
            angle = 0;
            power = 25;
            tankWeapon = 0;
            colour = tankModel.CreateBitmap(player.GetColour(), angle);
        }

        /// <summary>
        /// 
        /// Returns the Opponent associated with this ControlledTank.
        /// 
        /// Author John Santias and Hoang Nguyen October 2017
        /// 
        /// </summary>
        /// <returns> player </returns>
        public Opponent GetPlayerNumber() {
            return player;
        }

        /// <summary>
        /// 
        /// Returns the TankModel associated with this ControlledTank.
        /// 
        /// Author John Santias and Hoang Nguyen October 2017
        /// 
        /// </summary>
        /// <returns> player's TankModel </returns>
        public TankModel GetTank() {
            return player.GetTank();
        }

        /// <summary>
        /// 
        /// Returns the ControlledTank's current aiming angle.
        /// 
        /// Author John Santias and Hoang Nguyen October 2017
        /// 
        /// </summary>
        /// <returns> The angle of tank </returns>
        public float GetAim() {
            return angle;
        }

        /// <summary>
        /// 
        /// This method sets the ControlledTank's current aiming angle.
        /// 
        /// Author John Santias and Hoang Nguyen October 2017
        /// 
        /// </summary>
        /// <param name="angle"> Sets the angle of the Controlled Tank </param>
        public void SetAimingAngle(float angle) {
            if (angle >= -90 && angle <= 180) { this.angle = (int)angle; }
            colour = tankModel.CreateBitmap(player.GetColour(), angle);
        }

        /// <summary>
        /// 
        /// This returns the ControlledTank's current turret velocity.
        /// Where 5 is the minimum and 100 is the maximum.
        /// 
        /// Author John Santias and Hoang Nguyen October 2017
        /// 
        /// </summary>
        /// <returns> The power currently set of tank </returns>
        public int GetCurrentPower() {
            return power;
        }

        /// <summary>
        /// 
        /// This method sets the ControlledTank's current turret velocity.
        /// 
        /// Author John Santias and Hoang Nguyen October 2017
        /// 
        /// </summary>
        /// <param name="power"> The amount of power set </param>
        public void SetPower(int power) {
            this.power = (power < 5) ? 5 : (power > 100) ? 100 : power;
        }

        /// <summary>
        /// 
        /// This method returns the index of the current weapon equipped by the
        /// ControlledTank.
        /// 
        /// Author John Santias and Hoang Nguyen October 2017
        /// 
        /// </summary>
        /// <returns> The index of the weapon </returns>
        public int GetWeaponIndex() {
            return tankWeapon;
        }

        /// <summary>
        /// 
        /// This method sets the ControlledTank's current weapon.
        /// 
        /// Author John Santias and Hoang Nguyen October 2017
        /// 
        /// </summary>
        /// <param name="newWeapon"> The weapon number </param>
        public void SetWeaponIndex(int newWeapon) {
            this.tankWeapon = newWeapon;
        }

        /// <summary>
        /// 
        /// This method draws the ControlledTank to graphic, scaled 
        /// to the provided display size. The durability of the tank is
        /// also shown as a percentage.
        /// 
        /// Author John Santias and Hoang Nguyen October 2017
        /// 
        /// </summary>
        /// <param name="graphics"> The bitmap of the tank </param>
        /// <param name="displaySize"> Size of display </param>
        public void Draw(Graphics graphics, Size displaySize) {
            int x = tankX;
            int y = tankY;
            int drawX1 = displaySize.Width * x / Terrain.WIDTH;
            int drawY1 = displaySize.Height * y / Terrain.HEIGHT;
            int drawX2 = displaySize.Width * (x + TankModel.WIDTH) / Terrain.WIDTH;
            int drawY2 = displaySize.Height * (y + TankModel.HEIGHT) / Terrain.HEIGHT;
            graphics.DrawImage(colour, new Rectangle(drawX1, drawY1, drawX2 - drawX1, drawY2 - drawY1));

            int drawY3 = displaySize.Height * (y - TankModel.HEIGHT) / Terrain.HEIGHT;
            Font font = new Font("Arial", 8);
            Brush brush = new SolidBrush(Color.White);

            int pct = currentDur * 100 / tankModel.GetArmour();
            if (pct < 100) {
                graphics.DrawString(pct + "%", font, brush, new Point(drawX1, drawY3));
            }
        }

        /// <summary>
        /// 
        /// Returns the current horizontal position of the tank.
        /// 
        /// Author John Santias and Hoang Nguyen October 2017
        /// 
        /// </summary>
        /// <returns> The x coordinate of tank </returns>
        public int GetX() {
            return tankX;
        }

        /// <summary>
        /// 
        /// Returns the vertical position of the tank.
        /// 
        /// Author John Santias and Hoang Nguyen October 2017
        /// 
        /// </summary>
        /// <returns> The y coordinate of tank </returns>
        public int GetYPos() {
            return tankY;
        }

        /// <summary>
        /// 
        /// This method causes the ControlledTank to fire its current weapon.
        /// 
        /// Author John Santias and Hoang Nguyen October 2017
        /// 
        /// </summary>
        public void Attack() {
            GetTank().FireWeapon(tankWeapon, this, game);
        }

        /// <summary>
        /// 
        /// This method inflicts damageAmoount of damage to the tank. Reducing 
        /// the tank's durability by the given amount.
        /// 
        /// Author John Santias and Hoang Nguyen October 2017
        /// 
        /// </summary>
        /// <param name="damageAmount"> The amount of damage taken </param>
        public void InflictDamage(int damageAmount) {
            currentDur -= damageAmount;
        }

        /// <summary>
        /// 
        /// This method returns if the ControlledTank's durability. If the durability
        /// is greater than 0, otherwise it will return false. If the ControlledTank is
        /// less than or equal to 0, it is considered destroyed and will not recieve turns
        /// or be drawn to the screen.
        /// 
        /// Author John Santias and Hoang Nguyen October 2017
        /// 
        /// </summary>
        /// <returns> The durability of the tank </returns>
        public bool Exists() {
            if (currentDur > 0) {
                return true;
            } else {
                return false;
            }
        }

        /// <summary>
        /// 
        /// This method calls the ControlledTank to fall down one tile if possible.
        /// If the tank is moved due to the result of this method, it will return true,
        /// otherwise it will be false
        /// 
        /// Author John Santias and Hoang Nguyen October 2017 
        /// 
        /// </summary>
        /// <returns> Returns true if tank is moved, otherwise returns false </returns>
        public bool Gravity() {
            if (!Exists()) {
                return false;
            }
            Terrain t = game.GetLevel();
            int x = GetX();
            int y = GetYPos();
            if (t.CheckTankCollision(x, y + 1)) {
                return false;
            } else {
                tankY++;
                currentDur--;
                if (tankY == Terrain.HEIGHT - TankModel.HEIGHT) {
                    currentDur = 0;
                    return true;
                }
            }
            return true;
        }
    }
}
