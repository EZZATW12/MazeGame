using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MageGame
{
    public class Maze
    {
        private int height;
        private int width;
        private Player? player;
        private IMazeObject[,] grid;
        private Random random = new Random();
        private int[] valueRandom;
        public Maze(int height, int width)
        {
            this.height = height;
            this.width = width;
            player = new Player();
            player.x = player.y = 1;
            grid = new IMazeObject[height, width];
            valueRandom = new int[height];
            for(int i = 0; i < height; i++)
            {
                int x = random.Next(1, width - 1);
                valueRandom[i] = x;
            }
        }
        public void MovePlayer()
        {
            var MoveType = Console.ReadKey();
            var Key = MoveType.Key;
            switch (Key)
            {
                case ConsoleKey.UpArrow:
                    UpdatePlayer(-1, 0);
                    break;
                case ConsoleKey.DownArrow:
                    UpdatePlayer(1, 0);
                    break;
                case ConsoleKey.LeftArrow:
                    UpdatePlayer(0, -1);
                    break;
                case ConsoleKey.RightArrow:
                    UpdatePlayer(0, 1);
                    break;
            }
            DisplayGrid();
        }
        private void UpdatePlayer(int i, int j)
        {
            int nx = player.x + i;
            int ny = player.y + j;
            if (nx >= 0 && ny >= 0 && nx < height && ny < width && !grid[nx, ny].is_block)
            {
                player.x = nx;
                player.y = ny;
            }
        }
        public void DisplayGrid()
        {
            Console.Clear();
            for (int i = 0; i < height; i++)
            {

                if (i == 0)
                {
                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.WriteLine("");
                    Console.WriteLine("");
                }
               
                for (int j = 0; j < width; j++)
                {
                    if(i==height-2 && j == width - 1)
                    {
                        grid[i, j] = new EmptySpace();
                        Console.Write($"{grid[i, j].icon}");
                    }
                   else if (i == 0 || j == 0 || i == height - 1 || j == width - 1)
                    {

                        grid[i, j] = new Wall();
                        if (j == 0)
                            Console.Write($"                                    {grid[i, j].icon}");
                        else
                            Console.Write($"{grid[i, j].icon}");
                        continue;
                    }
                    else if (i == player.x && j == player.y)
                    {
                        grid[i, j] = new Player();
                        Console.Write($"{grid[i, j].icon}");
                        continue;
                    }
                    else
                    {
                        if ( j % valueRandom[i] == 0)
                        {
                            grid[i, j] = new Wall();
                            Console.Write($"{grid[i, j].icon}");
                            continue;
                        }
                        grid[i, j] = new EmptySpace();
                        Console.Write($"{grid[i, j].icon}");
                    }
                }
                Console.WriteLine("");
            }
        }
        public bool checkWin()
        {
            return player.x==height-2 && player.y==width-1;
        }
    }
}
