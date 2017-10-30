using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TankBattle {
    public class Terrain {
        public const int WIDTH = 160; 
        public const int HEIGHT = 120; 

        private const double MULTIPLIER = 3.0;
        private const double MULTIPLIER_MINIMUM = 0.5;

        private double randomTerrainAmount, randomTerrainMultiplier;
        private int roundedTerrainAmount;
        private bool[,] map;

        public Terrain()
		{
            Random rnd = new Random();
            map = new bool[WIDTH, HEIGHT];

            randomTerrainMultiplier = (rnd.NextDouble() * MULTIPLIER);

            while (randomTerrainMultiplier < MULTIPLIER_MINIMUM)
			{
                randomTerrainMultiplier = (rnd.NextDouble() * MULTIPLIER);
            }

            randomTerrainAmount = (WIDTH * HEIGHT / randomTerrainMultiplier);
      
            roundedTerrainAmount = Convert.ToInt32(randomTerrainAmount);

            for (int y = 0; y <= HEIGHT - 1; y++) //Create empty map
			{ 
				for (int x = 0; x <= WIDTH - 1; x++)
				{
                    map[x, y] = false;
                }
            }

            for (int i = 0; i < roundedTerrainAmount; i++) //Random positions for terrain
			{ 
                int randyPos = rnd.Next(HEIGHT);
                int randxPos = rnd.Next(WIDTH);

                map[randxPos, randyPos] = true;
            }

            
            for (int i = 0; i < WIDTH; i++) //Fill in pits
			{
                map[i, HEIGHT - 1] = true;
            }
            
            for (int i = 0; i < HEIGHT; i++) //Move floating terrain down
			{ 
                for (int y = 0; y <= HEIGHT - 2; y++)
				{
                    for (int x = 0; x <= WIDTH - 1; x++)
					{
                        if (map[x, y] == true && map[x, y + 1] == false)
						{
                            map[x, y] = false;
                            map[x, y + 1] = true;
                        }
                    }
                }
            }

            
            for (int i = 0; i < HEIGHT; i++) //Smooth out terrain
			{
                for (int y = 0; y <= HEIGHT - 2; y++) //Smooth out to the right
				{
                    for (int x = 0; x <= WIDTH - 2; x++)
					{
                        if (map[x, y] == true && map[x + 1, y + 1] == false)
						{
                            map[x, y] = false;
                            map[x + 1, y + 1] = true;
                        }
                    }
                }
               
                for (int y = 0; y <= HEIGHT - 2; y++) //Smooth out to the left
				{  
                    for (int x = 1; x <= WIDTH - 1; x++) //x starts at 1 since first x value starts at 0 (index cannot be -1)
					{
                        if (map[x, y] == true && map[x - 1, y + 1] == false)
						{
                            map[x, y] = false;
                            map[x - 1, y + 1] = true;
                        }
                    }
                }
            }
        }

        public bool IsTileAt(int x, int y)
		{
            if (x < 0 || x > WIDTH || y < 0 || y > HEIGHT)
			{
				return false;
			}
			else
			{
                if (map[x, y] == true)
				{
					return true;
				}
				else
				{
					return false;
				}
            }
        }

        public bool CheckTankCollision(int x, int y)
		{
            bool collision = false;
            int width = x + TankModel.WIDTH; //tank's width is 4
            int height = y + TankModel.HEIGHT; //tank's height is 3

            for (int xp = x; xp < width; xp++)
			{ 
                for (int yp = y; yp < height; yp++)
				{ 
                    if (xp >= width) //reset xp
					{
						xp = x;
					} 
                    else if (yp >= height) //reset yp
					{
						yp = y;
					}
                    else if (IsTileAt(xp, yp))
					{
                        collision = true;
                    }
                }
            }
            return collision;
        }

        public int TankYPosition(int x)
		{
            int y = 0;

            for (int i = 0; i < HEIGHT; i++)
			{
                if (CheckTankCollision(x, i))
				{
                    y = i - 1;
                    break;
                }
            }
            return y;
        }

        public void DestroyGround(float destroyX, float destroyY, float radius)
		{
            for (int y = 0; y <= HEIGHT - 1; y++) //loop through every coord of the map
			{
                for (int x = 0; x <= WIDTH - 1; x++)
				{
                    double temp;
                    float dist;

                    temp = Math.Sqrt(Math.Pow(x - destroyX, 2) + Math.Pow(y - destroyY, 2));
                    dist = (float)temp;

                    if (dist < radius)
					{
                        map[x, y] = false;
                    }
                }
            }
        }

        public bool Gravity()
		{
            bool moveDown = false;

			for (int y = HEIGHT - 2; y > 0; y--)
			{
				for (int x = 0; x < WIDTH; x++)
				{
					if (IsTileAt(x, y + 1) == false && IsTileAt(x, y) == true )
					{
						map[x, y] = false;
						map[x, y + 1] = true;
						moveDown = true;
					}
				}
			}
			return moveDown;
        }
    }
}
