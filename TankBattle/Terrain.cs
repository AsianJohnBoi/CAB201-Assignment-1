using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TankBattle {
    public class Terrain {
        public const int WIDTH = 160; //160
        public const int HEIGHT = 120; //120
        private bool[,] map;

        private int terrainAmount = (WIDTH * HEIGHT / 2); //Amount of terrain, area of terrain fills half the map

        public Terrain() {
            Random rnd = new Random();
            map = new bool[WIDTH, HEIGHT];

            //Create empty map
            for (int y = 0; y <= HEIGHT - 1; y++) {
                for (int x = 0; x <= WIDTH - 1; x++) {
                    map[x, y] = false;
                }
            }

            //Random positions for terrain
            for (int i = 0; i < terrainAmount; i++) {
                int randyPos = rnd.Next(HEIGHT);
                int randxPos = rnd.Next(WIDTH);

                map[randxPos, randyPos] = true;
            }

            //Fill in pits
            for (int i = 0; i < WIDTH; i++) {
                map[i, HEIGHT - 1] = true;
            }

            //Move floating terrain down
            for (int i = 0; i < HEIGHT; i++) { //need to double check loop amount, doesn't need to loop that many times
                for (int y = 0; y <= HEIGHT - 2; y++) {
                    for (int x = 0; x <= WIDTH - 1; x++) {
                        if (map[x, y] == true && map[x, y + 1] == false) {
                            map[x, y] = false;
                            map[x, y + 1] = true;
                        }
                    }
                }
            }

            //Smooth out terrain
            for (int i = 0; i < HEIGHT; i++) {

                //Smooth out to the right
                for (int y = 0; y <= HEIGHT - 2; y++) {
                    for (int x = 0; x <= WIDTH - 2; x++) {
                        if (map[x, y] == true && map[x + 1, y + 1] == false) {
                            map[x, y] = false;
                            map[x + 1, y + 1] = true;
                        }
                    }
                }

                //Smooth out to the left
                for (int y = 0; y <= HEIGHT - 2; y++) {  
                    for (int x = 1; x <= WIDTH - 1; x++) { //x starts at 1 since first x value starts at 0 (index cannot be -1)
                        if (map[x, y] == true && map[x - 1, y + 1] == false) {
                            map[x, y] = false;
                            map[x - 1, y + 1] = true;
                        }
                    }
                }
            }

            //for (int y = 0; y <= HEIGHT - 1; y++) {
            //    for (int x = 0; x <= WIDTH - 1; x++) {
            //        if (map[x, y] == false) {
            //            Console.Write('.');
            //        } else if (map[x, y] == true) {
            //            Console.Write('#');
            //        }
            //    }
            //    //seperate lines
            //    Console.WriteLine();
            //}
        }

        public bool IsTileAt(int x, int y) {
            if (x < 0 || x > WIDTH || y < 0 || y > HEIGHT) { return false; } else {
                if (map[x, y] == true) { return true; } else { return false; }
            }
        }

        public bool CheckTankCollision(int x, int y) {
            bool collision = false;
            int width = x + TankModel.WIDTH; //4
            int height = y + TankModel.HEIGHT; //3

            for (int xp = x; xp < width; xp++){ 
                for (int yp = y; yp < height; yp++){ 
                    if (xp >= width){ xp = x; } //reset xp
                    else if (yp >= height){ yp = y; } //reset yp
                    else if (IsTileAt(xp, yp) == true){
                        collision = true;
                    }
                }
            }
            return collision;
        }

        public int TankYPosition(int x) {
            //int y = HEIGHT - 2;
            //if (x < 0 && x > WIDTH - TankModel.WIDTH){ //checks if x position is within range
            //    for (int yp = HEIGHT - 2; yp > 0; yp--){
            //        if (CheckTankCollision(x, yp) == true){
            //            y--;
            //        }
            //    }
            //}
            //return y;

            int y = 0;

            for (int i = 0; i < HEIGHT; i++) {
                if (CheckTankCollision(x, i) == true) {
                    y = i - 1;
                    break;
                }
            }

            return y;
        }

        public void DestroyGround(float destroyX, float destroyY, float radius) {
            //loop through every coord of the map
            for (int y = 0; y <= HEIGHT - 1; y++) {
                for (int x = 0; x <= WIDTH - 1; x++) {

                    double temp;
                    float dist;

                    temp = Math.Sqrt(Math.Pow(x - destroyX, 2) + Math.Pow(y - destroyY, 2));
                    dist = (float)temp;

                    if (dist < radius) {
                        map[x, y] = false;
                    }

                }
            }
        }

        public bool Gravity() {

            bool moveDown = false;

			for (int y = HEIGHT - 2; y > 0; y--){
				for (int x = 0; x < WIDTH; x++){
					if (IsTileAt(x, y + 1) == false && IsTileAt(x, y) == true ){
						map[x, y] = false;
						map[x, y + 1] = true;
						moveDown = true;
					}
				}
			}
				//if (map[xrow, y] == false){
				//	y++;
				//	moved = false;
				//}
				// if (IsTileAt(xrow, y) == true && IsTileAt(xrow, y + 1) == false){

				//else if (map[xrow, y] == true){
					
				 //}
				//}
				//else if (y >= HEIGHT){
				//	y = 0;
				//	xrow++;
				//}
				//else if (xrow >= WIDTH){
				//	moved = false;
				//	break;
				//}

			return moveDown;

        }
    }
}
