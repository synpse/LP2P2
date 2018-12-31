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
            Piece tetromino, bool isKeyPressed)
        {
            if (Console.KeyAvailable)
            {
                Key = Console.ReadKey();
                isKeyPressed = true;
            }
            else
            {
                isKeyPressed = false;
            }

            if (Key.Key == ConsoleKey.LeftArrow && !tetromino.IsSomethingLeft
                (DroppedtetrominoeLocationGrid) && isKeyPressed)
            {
                for (int i = 0; i < 4; i++)
                {
                    tetromino.Location[i][1] -= 1;
                }
                tetromino.PositionUpdate(Grid, DroppedtetrominoeLocationGrid);
            }
            else if (Key.Key == ConsoleKey.RightArrow && !tetromino.IsSomethingRight
                (DroppedtetrominoeLocationGrid) && isKeyPressed)
            {
                for (int i = 0; i < 4; i++)
                {
                    tetromino.Location[i][1] += 1;
                }
                tetromino.PositionUpdate(Grid, DroppedtetrominoeLocationGrid);
            }
            if (Key.Key == ConsoleKey.DownArrow && isKeyPressed)
            {
                tetromino.Drop(Grid, DroppedtetrominoeLocationGrid);
            }
            if (Key.Key == ConsoleKey.UpArrow && isKeyPressed)
            {
                for (; tetromino.IsSomethingBelow(DroppedtetrominoeLocationGrid) != true;)
                {
                    tetromino.Drop(Grid, DroppedtetrominoeLocationGrid);
                }
            }
            if (Key.Key == ConsoleKey.Spacebar && isKeyPressed)
            {
                //rotate
                tetromino.Rotate(DroppedtetrominoeLocationGrid);
                tetromino.PositionUpdate(Grid, DroppedtetrominoeLocationGrid);
            }
        }
    }
}
