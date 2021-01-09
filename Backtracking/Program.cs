using System;

namespace Backtracking
{
    class Program
    {
        public static int N;
        public void Solution(int[,] sol)
        {
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                   Console.Write(" " + sol[i,j] + " ");
                Console.WriteLine();
            }
        }
        public bool IsSafe(int[,] maze, int x, int y)
        {
            if(x < N && y < N)
            {
                if(x >= 0 && y >= 0 && maze[x , y].Equals(1))
                {
                    return true;
                }
            }
            return false;
        }

        public bool SolveMaze(int[,] maze)
        {
            int[,] sol = new int[N,N];

            if (SolveMazeUtil(maze, 0, 0, sol) == false)
            {
                Console.WriteLine("no path exist.!");
                return false;
            }

            Solution(sol);
            return true;
        }
        public bool SolveMazeUtil(int[,] maze, int x, int y, int[,] solution)
        {
            if (x == N - 1 && y == N - 1 && maze[x,y] == 1)
            {
                solution[x,y] = 1;
                return true;
            }

            if (IsSafe(maze, x, y) == true)
            {
                solution[x,y] = 1;
                if (SolveMazeUtil(maze, x + 1, y, solution))
                {
                    return true;
                }
                else if (SolveMazeUtil(maze, x, y + 1, solution))
                {
                    return true;
                }
                solution[x,y] = 0;
                return false;
            }
            return false;
        }

        public static void Main(string[] args)
        {
            Program program = new Program();
            int[,] maze = new int[,] {
                { 1, 0, 0, 0},
                { 1, 1, 1, 1},
                { 1, 0, 0, 1},
                { 0, 1, 1, 1}    
            };
            https://stackoverflow.com/questions/43442768/searching-a-two-dimensional-array-using-length-property
            N = maze.GetLength(1);
            program.SolveMaze(maze);
        }
    }
}
