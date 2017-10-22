using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TankBattle
{
    public class Shell : WeaponEffect
    {   
        private float x, y, gravity, xVelocity, yVelocity;
        Blast explosion;
        Opponent player;

        public Shell(float x, float y, float angle, float power, float gravity, Blast explosion, Opponent player)
        {
            this.x = x;
            this.y = y;
            this.gravity = gravity;
            this.explosion = explosion;
            this.player = player;
            float angleRadians = (90 - angle) * (float)Math.PI / 180;
            float magnitude = power / 50;
            xVelocity = (float)Math.Cos(angleRadians) * magnitude;
            yVelocity = (float)Math.Sin(angleRadians) * -magnitude;
        }

        public override void Process()
        {
            x += x;
            y += y;
            xVelocity += xVelocity;
            yVelocity += yVelocity;
            x += x / i.GetWindSpeed() / 1000.0f;
            if (x < 0 || x > Terrain.WIDTH) { i.EndEffect(this); }
            else if (y < 0 || y > Terrain.HEIGHT) { i.EndEffect(this); }
            else if (i.CheckHitTank(x, y))
            {
                player.ProjectileHitPos(x, y);
                explosion.Explode(x, y);
                i.AddWeaponEffect(explosion);
                i.EndEffect(this);
            }
            y += gravity;
        }

        public override void Draw(Graphics graphics, Size size) //double check this method
        {
            float x = (float)this.x * size.Width / Terrain.WIDTH;
            float y = (float)this.y * size.Height / Terrain.HEIGHT;
            float s = size.Width / Terrain.WIDTH;

            RectangleF r = new RectangleF(x - s / 2.0f, y - s / 2.0f, s, s);
            Brush b = new SolidBrush(Color.WhiteSmoke);

            graphics.FillEllipse(b, r);
        }
    }
}
