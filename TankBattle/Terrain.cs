using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TankBattle
{
    public class Terrain
    {
        public const int WIDTH = 160; //160
        public const int HEIGHT = 120; //120
        private bool[,] map; 

        private int terrainAmount = (WIDTH * HEIGHT / 2); //Amount of terrain, area of terrain fills half the map

        public Terrain()
        {
            Random rnd = new Random();
            map = new bool[HEIGHT, WIDTH];

            //Create empty map
            for (int y = 0; y <= HEIGHT - 1; y++) {
                for (int x = 0; x <= WIDTH - 1; x++) {
                    map[y, x] = false;
                }
            }

            //Random positions for terrain
            for (int i = 0; i < terrainAmount; i++) {
                int randxPos = rnd.Next(WIDTH);
                int randyPos = rnd.Next(HEIGHT);

                map[randyPos, randxPos] = true;
            }

            //Fill in pits
            for (int i = 0; i < WIDTH; i++) {
                map[HEIGHT - 1, i] = true;
            }

            //Move floating terrain down
            //x = x, y = y + 1
            //if x = x && current y == true && next y == false (next y = y + 1) 
            //current y = false, next y = true, KEEP X coord the same
            for (int i = 0; i < terrainAmount; i++) { //need to double check loop amount, doesn't need to loop that many times
                for (int y = 0; y <= HEIGHT - 2; y++) {
                    for (int x = 0; x <= WIDTH - 1; x++) {
                        if (map[y, x] == true && map[y + 1, x] == false) {
                            map[y, x] = false;
                            map[y + 1, x] = true;
                        }
                    }
                }
            }

            //Smooth out terrain
            for (int i= 0; i < WIDTH; i++) {

                //Smooth out to the right
                for (int y = 0; y <= HEIGHT - 2; y++) {
                    for (int x = 0; x <= WIDTH - 2; x++) {
                        if (map[y, x] == true && map[y + 1, x + 1] == false) {
                            map[y, x] = false;
                            map[y + 1, x + 1] = true;
                        }
                    }
                }

                //Smooth out to the left
                for (int y = 0; y <= HEIGHT - 2; y++) {
                    for (int x = 1; x <= WIDTH - 1; x++) { //x starts at 1 since first x value starts at 0 (index cannot be -1)
                        if (map[y, x] == true && map[y + 1, x - 1] == false) {
                            map[y, x] = false;
                            map[y + 1, x - 1] = true;
                        }
                    }
                }
            }
        }

        public bool IsTileAt(int x, int y)
        {
            if (x < 0 || x > WIDTH || y < 0 || y > HEIGHT) { return false; }
            else
            {
                if (map[x, y] == true) { return true; }
                else { return false; }
            }
        }

        public bool CheckTankCollision(int x, int y)
        {
            if (map[x + WIDTH, y+ HEIGHT] || map[x, y + 3] == true){ return true; }
            else { return false; }
        }

        public int TankYPosition(int x)
        {
            int y = 0;
            if (x > WIDTH - TankModel.WIDTH) { return 0; }
            else
            {
                for (int i = 0; i < HEIGHT;)
                {
                    if (map[x, i] != true){ i++; }
                    else {
                        y = i;
                        break;
                    }
                }
            }
            return y;
        }

        public void DestroyGround(float destroyX, float destroyY, float radius)
        {
            throw new NotImplementedException();
        }

        public bool Gravity()
        {
            throw new NotImplementedException();
        }
    }
}
