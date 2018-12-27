using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Diagnostics;
using System.Media;
using System.Resources;
using System.IO;
using System.Reflection;

namespace Tetris
{
    class Input
    {
        public ConsoleKeyInfo key;

        public void Readkey(bool isKeyPressed, Piece tet)
        {
            if (Console.KeyAvailable)
            {
                key = Console.ReadKey();
                isKeyPressed = true;
            }
            else
                isKeyPressed = false;

            if (key.Key == ConsoleKey.LeftArrow & !tet.isSomethingLeft() & isKeyPressed)
            {
                for (int i = 0; i < 4; i++)
                {
                    tet.Location[i][1] -= 1;
                }
                tet.PositionUpdate(Game.grid, Game.droppedtetrominoeLocationGrid);
            }
            else if (key.Key == ConsoleKey.RightArrow & !tet.isSomethingRight() & isKeyPressed)
            {
                for (int i = 0; i < 4; i++)
                {
                    tet.Location[i][1] += 1;
                }
                tet.PositionUpdate(Game.grid, Game.droppedtetrominoeLocationGrid);
            }
            if (key.Key == ConsoleKey.DownArrow & isKeyPressed)
            {
                tet.Drop(Game.grid, Game.droppedtetrominoeLocationGrid);
            }
            if (key.Key == ConsoleKey.UpArrow & isKeyPressed)
            {
                for (; tet.isSomethingBelow() != true;)
                {
                    tet.Drop(Game.grid, Game.droppedtetrominoeLocationGrid);
                }
            }
            if (key.Key == ConsoleKey.Spacebar & isKeyPressed)
            {
                //rotate
                tet.Rotate();
                tet.PositionUpdate(Game.grid, Game.droppedtetrominoeLocationGrid);
            }
        }
    }
}
