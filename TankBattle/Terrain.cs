using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TankBattle {
    /// <summary>
    /// 
    /// This class represents the landscape, the arena of on which the tanks battle.
    /// It is randomly generated each round and can be destroyed during the round.
    /// 
    /// Author John Santias and Hoang Nguyen October 2017
    /// 
    /// </summary>
    public class Terrain {
        public const int WIDTH = 160; 
        public const int HEIGHT = 120; 

        private const double MULTIPLIER = 3.0;
        private const double MULTIPLIER_MINIMUM = 0.5;

        private double randomTerrainAmount, randomTerrainMultiplier;
        private int roundedTerrainAmount;
        private bool[,] map;

        /// <summary>
        /// 
        /// This constructor randomly generates the terrain the tanks will battle on.
        /// The map has a width of 160 and a height of 120.
        /// 
        /// Author John Santias and Hoang Nguyen October 2017
        /// 
        /// </summary>
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

        /// <summary>
        /// 
        /// This method returns whether there is any terrain at the given coordinates.
        /// 
        /// Author John Santias and Hoang Nguyen October 2017
        /// 
        /// </summary>
        /// <param name="x"> X coordinate </param>
        /// <param name="y"> Y coordinate </param>
        /// <returns> Whether there is terrain at given coordinates </returns>
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

        /// <summary>
        /// 
        /// This method returns whether there is room for a tank-sized object at
        /// given coordinates.
        /// 
        /// Author John Santias and Hoang Nguyen October 2017
        /// 
        /// </summary>
        /// <param name="x"> X coordinate </param>
        /// <param name="y"> Y coordinate </param>
        /// <returns> Returns true if there is room for tank at given coordinates, otherwise returns false </returns>
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

        /// <summary>
        /// 
        /// This method returns y position of tank at given x position.
        /// 
        /// Author John Santias and Hoang Nguyen October 2017
        /// 
        /// </summary>
        /// <param name="x"> X coordinate </param>
        /// <returns> Y position of tank </returns>
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

        /// <summary>
        /// 
        /// This method destroys all terrain within a circle centred around destroyX and destroyY.
        /// 
        /// Author John Santias and Hoang Nguyen October 2017
        /// 
        /// </summary>
        /// <param name="destroyX"> X coordinate </param>
        /// <param name="destroyY"> Y coordinate </param>
        /// <param name="radius"> Radius of explosion </param>
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

        /// <summary>
        /// 
        /// This method moves any loose terrain down one tile.
        /// 
        /// Author John Santias and Hoang Nguyen October 2017
        /// 
        /// </summary>
        /// <returns> Return true if any terrain was moved, otherwise returns false </returns>
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
