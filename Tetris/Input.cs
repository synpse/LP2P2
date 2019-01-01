using System;

namespace Tetris
{
    /// <summary>
    /// Creates Input Class
    /// </summary>
    class Input
    {
        private ConsoleKeyInfo Key { get; set; }

        /// <summary>
        /// Creates ReadKey Method
        /// </summary>
        /// <param name="isKeyPressed"></param>
        /// <param name="tetromino"></param>
        /// <param name="Grid"></param>
        /// <param name="DroppedtetrominoeLocationGrid"></param>
        public void Readkey(int[,] Grid, int[,] DroppedtetrominoeLocationGrid, 
            Piece piece, bool IsKeyPressed)
        {
            if (Console.KeyAvailable)
            {
                Key = Console.ReadKey();
                IsKeyPressed = true;
            }
            else
            {
                IsKeyPressed = false;
            }

            if (Key.Key == ConsoleKey.LeftArrow && !piece.IsSomethingLeft
                (DroppedtetrominoeLocationGrid) && IsKeyPressed)
            {
                for (int i = 0; i < 4; i++)
                {
                    piece.Location[i][1] -= 1;
                }
            }
            else if (Key.Key == ConsoleKey.RightArrow && !piece.IsSomethingRight
                (DroppedtetrominoeLocationGrid) && IsKeyPressed)
            {
                for (int i = 0; i < 4; i++)
                {
                    piece.Location[i][1] += 1;
                }
            }
            if (Key.Key == ConsoleKey.DownArrow && IsKeyPressed)
            {
                piece.Drop(Grid, DroppedtetrominoeLocationGrid);
            }
            if (Key.Key == ConsoleKey.UpArrow && IsKeyPressed)
            {
                for (; piece.IsSomethingBelow(DroppedtetrominoeLocationGrid) != true;)
                {
                    piece.Drop(Grid, DroppedtetrominoeLocationGrid);
                }
            }
            if (Key.Key == ConsoleKey.Spacebar && IsKeyPressed)
            {
                //rotate
                piece.Rotate(DroppedtetrominoeLocationGrid);
            }
        }
    }
}
