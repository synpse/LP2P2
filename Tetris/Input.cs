using System;

namespace Tetris
{
    /// <summary>
    /// Creates Input Class
    /// </summary>
    class Input
    {
        private ConsoleKeyInfo key;

        /// <summary>
        /// Creates ReadKey Method
        /// </summary>
        /// <param name="isKeyPressed"></param>
        /// <param name="tetromino"></param>
        /// <param name="Grid"></param>
        /// <param name="DroppedtetrominoeLocationGrid"></param>
        public void Readkey()
        {
            if (Console.KeyAvailable)
            {
                key = Console.ReadKey();
                Game.isKeyPressed = true;
            }
            else
                Game.isKeyPressed = false;

            if (key.Key == ConsoleKey.LeftArrow & !Game.tetromino.IsSomethingLeft(Game.DroppedtetrominoeLocationGrid) & Game.isKeyPressed)
            {
                for (int i = 0; i < 4; i++)
                {
                    Game.tetromino.Location[i][1] -= 1;
                }
                Game.tetromino.PositionUpdate(Game.Grid, Game.DroppedtetrominoeLocationGrid);
            }
            else if (key.Key == ConsoleKey.RightArrow & !Game.tetromino.IsSomethingRight(Game.DroppedtetrominoeLocationGrid) & Game.isKeyPressed)
            {
                for (int i = 0; i < 4; i++)
                {
                    Game.tetromino.Location[i][1] += 1;
                }
                Game.tetromino.PositionUpdate(Game.Grid, Game.DroppedtetrominoeLocationGrid);
            }
            if (key.Key == ConsoleKey.DownArrow & Game.isKeyPressed)
            {
                Game.tetromino.Drop(Game.Grid, Game.DroppedtetrominoeLocationGrid);
            }
            if (key.Key == ConsoleKey.UpArrow & Game.isKeyPressed)
            {
                for (; Game.tetromino.IsSomethingBelow(Game.DroppedtetrominoeLocationGrid) != true;)
                {
                    Game.tetromino.Drop(Game.Grid, Game.DroppedtetrominoeLocationGrid);
                }
            }
            if (key.Key == ConsoleKey.Spacebar & Game.isKeyPressed)
            {
                //rotate
                Game.tetromino.Rotate(Game.DroppedtetrominoeLocationGrid);
                Game.tetromino.PositionUpdate(Game.Grid, Game.DroppedtetrominoeLocationGrid);
            }
        }
    }
}
