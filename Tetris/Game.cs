using System;
using System.Diagnostics;

namespace Tetris
{
    /// <summary>
    /// Creates Game Class to start everything
    /// </summary>
    class Game
    {
        private int[,] Grid { get; } = new int[23, 10];
        private int[,] DroppedtetrominoeLocationGrid { get; } = new int[23, 10];
        private int DropTime { get; set; }
        private int DropRate { get; set; }
        private bool IsKeyPressed { get; set; }
        private int LinesCleared { get; set; }
        private int Score { get; set; }
        private int Level { get; set; }
        private int Combo { get; set; }

        public static bool IsDropped { get; set; }

        /// <summary>
        /// Creates method Start
        /// </summary>
        public void Start(int difficultyLevel)
        {
            Input input = new Input();
            Render render = new Render();
            Difficulty difficulty = new Difficulty();
            MainMenu mainMenu = new MainMenu();
            GameOver gameOver = new GameOver();
            Stopwatch timer = new Stopwatch();
            Stopwatch dropTimer = new Stopwatch();
            Stopwatch inputTimer = new Stopwatch();
            Piece tetromino;
            Piece nextTetromino;

            IsDropped = false;
            IsKeyPressed = false;
            LinesCleared = 0;
            Score = 0;
            Level = 0;
            Combo = 0;

            render.DrawBorder();

            timer.Start();
            dropTimer.Start();
            // Time passed measured by the instance
            long time = timer.ElapsedMilliseconds;

            // Update score and level
            render.DrawScoreAndLevel(Level, Score, LinesCleared, Combo);

            nextTetromino = new Piece();
            tetromino = nextTetromino;
            tetromino.Spawn(Grid, DroppedtetrominoeLocationGrid);
            nextTetromino = new Piece();

            //Thread thread = new Thread(() => input.Readkey(Grid, DroppedtetrominoeLocationGrid, tetromino, isKeyPressed));
            //thread.Start();

            Update(difficultyLevel, dropTimer, tetromino, nextTetromino, input, render);

            Console.Clear();

            gameOver.Display(Score, difficultyLevel);
        }

        /// <summary>
        /// Creates GameLoop
        /// </summary>
        public void Update(int difficultyLevel, Stopwatch dropTimer, Piece tetromino, Piece nextTetromino, Input input, Render render)
        {
            // Gameloop
            while (true)
            {
                // Save elapsed time as an int
                DropTime = (int)dropTimer.ElapsedMilliseconds;

                input.Readkey(Grid, DroppedtetrominoeLocationGrid, tetromino, IsKeyPressed);

                if (DropTime > DropRate)
                {
                    DropTime = 0;
                    dropTimer.Restart();
                    tetromino.Drop(Grid, DroppedtetrominoeLocationGrid);
                }
                if (IsDropped == true)
                {
                    tetromino = nextTetromino;
                    nextTetromino = new Piece();
                    tetromino.Spawn(Grid, DroppedtetrominoeLocationGrid);

                    IsDropped = false;
                }
                for (int j = 0; j < 10; j++)
                {
                    if (DroppedtetrominoeLocationGrid[0, j] == 1)
                        return;
                }
                CheckLine(difficultyLevel, render);
            }
        }
        
        /// <summary>
        /// Creates CheckLine Method
        /// </summary>
        public void CheckLine(int difficultyLevel, Render render)
        {
            for (int i = 0; i < 23; i++)
            {
                int j;
                for (j = 0; j < 10; j++)
                {
                    if (DroppedtetrominoeLocationGrid[i, j] == 0)
                    {
                        Combo = 0;
                        break;
                    }
                }
                if (j == 10)
                {
                    Combo++;
                    LinesCleared++;

                    if (Combo == 1)
                        Score += 40 * Level;
                    else if (Combo == 2)
                        Score += 100 * Level;
                    else if (Combo == 3)
                        Score += 300 * Level;
                    else if (Combo > 3)
                        Score += 300 * Combo * Level;

                    ClearLine(Combo, i, j, render);

                    // Update score and level
                    render.DrawScoreAndLevel(Level, Score, LinesCleared, Combo);
                }
            }

            if (LinesCleared < 5) Level = 1;
            else if (LinesCleared < 10) Level = 2;
            else if (LinesCleared < 15) Level = 3;
            else if (LinesCleared < 25) Level = 4;
            else if (LinesCleared < 35) Level = 5;
            else if (LinesCleared < 50) Level = 6;
            else if (LinesCleared < 70) Level = 7;
            else if (LinesCleared < 90) Level = 8;
            else if (LinesCleared < 110) Level = 9;
            else if (LinesCleared < 150) Level = 10;

            // Increase the drop rate with level
            DropRate = (400 / difficultyLevel) - 22 * Level;
        }

        /// <summary>
        /// Creates ClearLine method
        /// </summary>
        /// <param name="combo"></param>
        /// <param name="i"></param>
        /// <param name="j"></param>
        public void ClearLine(int combo, int i, int j, Render render)
        {
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
                    {
                        DroppedtetrominoeLocationGrid[k, l] = 1;
                    }

            render.Draw(Grid, DroppedtetrominoeLocationGrid);
        }
    }
}
