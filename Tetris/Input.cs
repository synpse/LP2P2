using System;

namespace Tetris
{
    class Input
    {
        private ConsoleKeyInfo key;

        public void Readkey(bool isKeyPressed, Piece tetromino, int[,] Grid, int[,] DroppedtetrominoeLocationGrid)
        {
            if (Console.KeyAvailable)
            {
                key = Console.ReadKey();
                isKeyPressed = true;
            }
            else
                isKeyPressed = false;

            if (key.Key == ConsoleKey.LeftArrow & !tetromino.IsSomethingLeft(DroppedtetrominoeLocationGrid) & isKeyPressed)
            {
                for (int i = 0; i < 4; i++)
                {
                    tetromino.Location[i][1] -= 1;
                }
                tetromino.PositionUpdate(Grid, DroppedtetrominoeLocationGrid);
            }
            else if (key.Key == ConsoleKey.RightArrow & !tetromino.IsSomethingRight(DroppedtetrominoeLocationGrid) & isKeyPressed)
            {
                for (int i = 0; i < 4; i++)
                {
                    tetromino.Location[i][1] += 1;
                }
                tetromino.PositionUpdate(Grid, DroppedtetrominoeLocationGrid);
            }
            if (key.Key == ConsoleKey.DownArrow & isKeyPressed)
            {
                tetromino.Drop(Grid, DroppedtetrominoeLocationGrid);
            }
            if (key.Key == ConsoleKey.UpArrow & isKeyPressed)
            {
                for (; tetromino.IsSomethingBelow(DroppedtetrominoeLocationGrid) != true;)
                {
                    tetromino.Drop(Grid, DroppedtetrominoeLocationGrid);
                }
            }
            if (key.Key == ConsoleKey.Spacebar & isKeyPressed)
            {
                //rotate
                tetromino.Rotate(DroppedtetrominoeLocationGrid);
                tetromino.PositionUpdate(Grid, DroppedtetrominoeLocationGrid);
            }
        }
    }
}
