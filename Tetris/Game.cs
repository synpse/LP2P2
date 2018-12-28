using System;
using System.Diagnostics;
using System.Threading;

namespace Tetris
{
    /// <summary>
    /// Creates Game Class to start everything
    /// </summary>
    class Game
    {
        public int[,] Grid { get; } = new int[23, 10];
        public int[,] DroppedtetrominoeLocationGrid { get; } = new int[23, 10];
        private Stopwatch timer = new Stopwatch();
        private Stopwatch dropTimer = new Stopwatch();
        private readonly Stopwatch inputTimer = new Stopwatch();
        public int dropTime, dropRate;
        public static bool isDropped = false;
        public Piece tetromino;
        public Piece nextTetromino;
        public bool isKeyPressed = false;
        public int linesCleared = 0, score = 0, level = 1;
        Input input = new Input();
        Render render = new Render();
        
        /// <summary>
        /// Creates method Start
        /// </summary>
        public void Start(int difficulty)
        {
            
            render.DrawBorder();
            Console.SetCursorPosition(4, 5);
            Console.WriteLine("Press any key");
            Console.ReadKey(true);

            timer.Start();
            dropTimer.Start();
            long time = timer.ElapsedMilliseconds;

            Console.SetCursorPosition(25, 0);
            Console.WriteLine("Level " + level);
            Console.SetCursorPosition(25, 1);
            Console.WriteLine("Score " + score);
            Console.SetCursorPosition(25, 2);
            Console.WriteLine("LinesCleared " + linesCleared);

            nextTetromino = new Piece();
            tetromino = nextTetromino;
            tetromino.Spawn(Grid, DroppedtetrominoeLocationGrid);
            nextTetromino = new Piece();
            
            Update(difficulty);

            Console.SetCursorPosition(0, 0);
            Console.Clear();

            do
            {
                Console.WriteLine("Game Over \n Replay? (Y/N)");
                string input = Console.ReadLine().ToLower();

                if (input == "y")
                {
                    return;
                }
                else if (input == "n")
                {
                    Environment.Exit(1);
                }
                Console.Clear();
            } while (true);  
            
        }

        /// <summary>
        /// Creates GameLoop
        /// </summary>
        public void Update(int difficulty)
        {
            // Gameloop
            while (true)
            {
                dropTime = (int)dropTimer.ElapsedMilliseconds;
                if (dropTime > dropRate)
                {
                    dropTime = 0;
                    dropTimer.Restart();
                    tetromino.Drop(Grid, DroppedtetrominoeLocationGrid);
                }
                if (isDropped == true)
                {
                    tetromino = nextTetromino;
                    nextTetromino = new Piece();
                    tetromino.Spawn(Grid, DroppedtetrominoeLocationGrid);

                    isDropped = false;
                }               
                for (int j = 0; j < 10; j++)
                {
                    if (DroppedtetrominoeLocationGrid[0, j] == 1)
                        return;
                }
                
                //Thread inputThread = new Thread(() => input.Readkey(isKeyPressed, tetromino, Grid, DroppedtetrominoeLocationGrid));

                //inputThread.Start();

                // Without threads
                input.Readkey(isKeyPressed, tetromino, Grid, DroppedtetrominoeLocationGrid);
                CheckLine(difficulty);
            }
        }
        
        /// <summary>
        /// Creates CheckLine Method
        /// </summary>
        public void CheckLine(int difficulty)
        {
            int combo = 0;
            for (int i = 0; i < 23; i++)
            {
                int j;
                for (j = 0; j < 10; j++)
                {
                    if (DroppedtetrominoeLocationGrid[i, j] == 0)
                        break;
                }
                if (j == 10)
                {
                    ClearLine(combo, i, j);
                }
            }
            if (combo == 1)
                score += 40 * level;
            else if (combo == 2)
                score += 100 * level;
            else if (combo == 3)
                score += 300 * level;
            else if (combo > 3)
                score += 300 * combo * level;

            if (linesCleared < 5) level = 1;
            else if (linesCleared < 10) level = 2;
            else if (linesCleared < 15) level = 3;
            else if (linesCleared < 25) level = 4;
            else if (linesCleared < 35) level = 5;
            else if (linesCleared < 50) level = 6;
            else if (linesCleared < 70) level = 7;
            else if (linesCleared < 90) level = 8;
            else if (linesCleared < 110) level = 9;
            else if (linesCleared < 150) level = 10;

            // Increase the drop rate with level
            dropRate = (300 / difficulty) - 22 * level;
        }

        /// <summary>
        /// Creates ClearLine method
        /// </summary>
        /// <param name="combo"></param>
        /// <param name="i"></param>
        /// <param name="j"></param>
        public void ClearLine(int combo, int i, int j)
        {
            linesCleared++;
            combo++;

            // Update score and level
            render.DrawScoreAndLevel(level, score, linesCleared);

            for (j = 0; j < 10; j++)
            {
                DroppedtetrominoeLocationGrid[i, j] = 0;
            }
            int[,] newdroppedtetrominoeLocationGrid = new int[23, 10];
            for (int k = 1; k < i; k++)
            {
                for (int l = 0; l < 10; l++)
                {
                    newdroppedtetrominoeLocationGrid[k + 1, l] = DroppedtetrominoeLocationGrid[k, l];
                }
            }
            for (int k = 1; k < i; k++)
            {
                for (int l = 0; l < 10; l++)
                {
                    DroppedtetrominoeLocationGrid[k, l] = 0;
                }
            }
            for (int k = 0; k < 23; k++)
                for (int l = 0; l < 10; l++)
                    if (newdroppedtetrominoeLocationGrid[k, l] == 1)
                        DroppedtetrominoeLocationGrid[k, l] = 1;
            render.Draw(Grid, DroppedtetrominoeLocationGrid);
        }
    }
}
