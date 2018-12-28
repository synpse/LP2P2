using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    /// <summary>
    /// Creates Render Class
    /// </summary>
    class Render
    {
        private Square square = new Square();

        /// <summary>
        /// Creates Draw Method
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="droppedtetrominoeLocationGrid"></param>
        public void Draw(int[,] grid, int[,] droppedtetrominoeLocationGrid)
        {
            for (int i = 0; i < 23; ++i)
            {
                for (int j = 0; j < 10; j++)
                {
                    Console.SetCursorPosition(1 + 2 * j, i);
                    if (grid[i, j] == 1 | droppedtetrominoeLocationGrid[i, j] == 1)
                    {
                        Console.SetCursorPosition(1 + 2 * j, i);
                        Console.ForegroundColor = Tetromino.CurrentColor;
                        Console.Write(square.Sqr);
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write("  ");
                    }
                }
            }
        }

        /// <summary>
        /// Creates DrawBorder Method
        /// </summary>
        public void DrawBorder()
        {
            for (int lengthCount = 0; lengthCount <= 22; ++lengthCount)
            {
                Console.SetCursorPosition(0, lengthCount);
                Console.Write("█");
                Console.SetCursorPosition(21, lengthCount);
                Console.Write("█");
            }
            Console.SetCursorPosition(0, 23);
            for (int widthCount = 0; widthCount <= 10; widthCount++)
            {
                Console.Write("▀▀");
            }
        }

        /// <summary>
        /// Creates ClearOldTetronimo Method
        /// </summary>
        public void ClearOldTetromino()
        {
            // Draw New tetromino on GUI
            for (int i = 23; i < 33; ++i)
            {
                for (int j = 3; j < 10; j++)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(i, j);
                    Console.Write(" ");
                }
            }
        }

        /// <summary>
        /// Creates DrawNewTetronimo Method
        /// </summary>
        /// <param name="Shape"></param>
        public void DrawNewTetromino(int[,] Shape)
        {
            for (int i = 0; i < Shape.GetLength(0); i++)
            {
                for (int j = 0; j < Shape.GetLength(1); j++)
                {
                    if (Shape[i, j] == 1)
                    {
                        if (Shape == Tetromino.I)
                        {
                            Tetromino.CurrentColor = ConsoleColor.Cyan;
                        }
                        if (Shape == Tetromino.O)
                        {
                            Tetromino.CurrentColor = ConsoleColor.Yellow;
                        }
                        if (Shape == Tetromino.T)
                        {
                            Tetromino.CurrentColor = ConsoleColor.Magenta;
                        }
                        if (Shape == Tetromino.S)
                        {
                            Tetromino.CurrentColor = ConsoleColor.Green;
                        }
                        if (Shape == Tetromino.Z)
                        {
                            Tetromino.CurrentColor = ConsoleColor.Red;
                        }
                        if (Shape == Tetromino.J)
                        {
                            Tetromino.CurrentColor = ConsoleColor.Blue;
                        }
                        if (Shape == Tetromino.L)
                        {
                            Tetromino.CurrentColor = ConsoleColor.DarkYellow;
                        }
                        Console.SetCursorPosition(((10 - Shape.GetLength(1)) / 2 + j) * 2 + 20, i + 5);
                        Console.ForegroundColor = Tetromino.CurrentColor;
                        Console.Write(square.Sqr);
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                }
            }
        }

        /// <summary>
        /// Creates DrawScoreAndLevel Method
        /// </summary>
        /// <param name="level"></param>
        /// <param name="score"></param>
        /// <param name="linesCleared"></param>
        public void DrawScoreAndLevel(int level, int score, int linesCleared, int combo)
        {
            Console.SetCursorPosition(25, 0);
            Console.WriteLine("Level: " + level);
            Console.SetCursorPosition(25, 1);
            Console.WriteLine("Score: " + score);
            Console.SetCursorPosition(25, 2);
            Console.WriteLine("LinesCleared: " + linesCleared);
            Console.SetCursorPosition(45, 2);
            Console.WriteLine("Combo: " + combo);
        }
    }
}
