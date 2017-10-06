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

        private int terrainAmount = (WIDTH * HEIGHT / 2); //Amount of terrain, area of terrain fills half the map

        bool[,] map = new bool[HEIGHT, WIDTH];

        public Terrain()
        {
            Random rnd = new Random();

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

            //Display map - PRE GRAVITY
            //Console.WriteLine("PRE GRAVITY:");
            //for (int y = 0; y <= HEIGHT - 1; y++) {
            //    for (int x = 0; x <= WIDTH - 1; x++) {
            //        if (map[y, x] == false) {
            //            Console.Write('.');
            //        } else if (map[y, x] == true) {
            //            Console.Write('#');
            //        }
            //    }
            //    //seperate lines
            //    Console.WriteLine();
            //}

            //Move floating terrain down
            //x = x, y = y + 1
            //if x = x && current y == true && next y == false (next y = y + 1) 
            //current y = false, next y = true, KEEP X coord the same
            for (int i = 0; i < terrainAmount; i++) {
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


            //Display map -POST GRAVITY
            //Console.WriteLine("POST GRAVITY:");
            //for (int y = 0; y <= HEIGHT - 1; y++) {
            //    for (int x = 0; x <= WIDTH - 1; x++) {
            //        if (map[y, x] == false) {
            //            Console.Write('.');
            //        } else if (map[y, x] == true) {
            //            Console.Write('#');
            //        }
            //    }
            //    //seperate lines
            //    Console.WriteLine();
            //}

        }

        public bool IsTileAt(int x, int y)
        {
            if (map[y - 1, x - 1] == true) {
                return true;
            } else {
                return false;
            }
        }

        public bool CheckTankCollision(int x, int y)
        {
            throw new NotImplementedException();
        }

        public int TankYPosition(int x)
        {
            throw new NotImplementedException();
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
