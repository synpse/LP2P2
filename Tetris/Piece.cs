using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class Piece : Tetromino
    {
        Render render = new Render();

        public void PositionUpdate(int[,] grid, int[,] droppedtetrominoeLocationGrid)
        {
            for (int i = 0; i < 23; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Game.grid[i, j] = 0;
                }
            }
            for (int i = 0; i < 4; i++)
            {
                Game.grid[Location[i][0], Location[i][1]] = 1;
            }
            render.Draw(grid, droppedtetrominoeLocationGrid);
        }

        public void Spawn(int[,] grid, int[,] droppedtetrominoeLocationGrid)
        {
            for (int i = 0; i < Shape.GetLength(0); i++)
            {
                for (int j = 0; j < Shape.GetLength(1); j++)
                {
                    if (Shape == I)
                    {                        
                        CurrentColor = ConsoleColor.Cyan;
                    }
                    if (Shape == O)
                    {
                        CurrentColor = ConsoleColor.Yellow;
                    }
                    if (Shape == T)
                    {
                        CurrentColor = ConsoleColor.Magenta;
                    }
                    if (Shape == S)
                    {
                        CurrentColor = ConsoleColor.Green;
                    }
                    if (Shape == Z)
                    {
                        CurrentColor = ConsoleColor.Red;
                    }
                    if (Shape == J)
                    {
                        CurrentColor = ConsoleColor.Blue;
                    }
                    if (Shape == L)
                    {
                        CurrentColor = ConsoleColor.DarkYellow;
                    }

                    if (Shape[i, j] == 1)
                    {
                        Location.Add(new int[] { i, (10 - Shape.GetLength(1)) / 2 + j });
                    }
                }
            }
            PositionUpdate(grid, droppedtetrominoeLocationGrid);
        }

        public void Drop(int[,] grid, int[,] droppedtetrominoeLocationGrid)
        {
            if (isSomethingBelow())
            {
                for (int i = 0; i < 4; i++)
                {
                    Game.droppedtetrominoeLocationGrid[Location[i][0], Location[i][1]] = 1;
                }
                Game.isDropped = true;

            }
            else
            {
                for (int numCount = 0; numCount < 4; numCount++)
                {
                    Location[numCount][0] += 1;
                }
                PositionUpdate(grid, droppedtetrominoeLocationGrid);
            }
        }

        public void Rotate()
        {
            List<int[]> templocation = new List<int[]>();
            for (int i = 0; i < Shape.GetLength(0); i++)
            {
                for (int j = 0; j < Shape.GetLength(1); j++)
                {
                    if (Shape[i, j] == 1)
                    {
                        templocation.Add(new int[] { i, (10 - Shape.GetLength(1)) / 2 + j });
                    }
                }
            }

            if (Shape == tetrominoes[0])
            {
                if (IsErect == false)
                {
                    for (int i = 0; i < Location.Count; i++)
                    {
                        templocation[i] = TransformMatrix(Location[i], Location[2], "Clockwise");
                    }
                }
                else
                {
                    for (int i = 0; i < Location.Count; i++)
                    {
                        templocation[i] = TransformMatrix(Location[i], Location[2], "Counterclockwise");
                    }
                }
            }

            else if (Shape == tetrominoes[3])
            {
                for (int i = 0; i < Location.Count; i++)
                {
                    templocation[i] = TransformMatrix(Location[i], Location[3], "Clockwise");
                }
            }

            else if (Shape == tetrominoes[1]) return;
            else
            {
                for (int i = 0; i < Location.Count; i++)
                {
                    templocation[i] = TransformMatrix(Location[i], Location[2], "Clockwise");
                }
            }


            for (int count = 0; isOverlayLeft(templocation) != false | isOverlayRight(templocation) != false | isOverlayBelow(templocation) != false; count++)
            {
                if (isOverlayLeft(templocation) == true)
                {
                    for (int i = 0; i < Location.Count; i++)
                    {
                        templocation[i][1] += 1;
                    }
                }
                if (isOverlayRight(templocation) == true)
                {
                    for (int i = 0; i < Location.Count; i++)
                    {
                        templocation[i][1] -= 1;
                    }
                }
                if (isOverlayBelow(templocation) == true)
                {
                    for (int i = 0; i < Location.Count; i++)
                    {
                        templocation[i][0] -= 1;
                    }
                }
                if (count == 3)
                {
                    return;
                }
            }

            Location = templocation;

        }

        public int[] TransformMatrix(int[] coord, int[] axis, string dir)
        {
            int[] pcoord = { coord[0] - axis[0], coord[1] - axis[1] };
            if (dir == "Counterclockwise")
            {
                pcoord = new int[] { -pcoord[1], pcoord[0] };
            }
            else if (dir == "Clockwise")
            {
                pcoord = new int[] { pcoord[1], -pcoord[0] };
            }

            return new int[] { pcoord[0] + axis[0], pcoord[1] + axis[1] };
        }

        public bool isSomethingBelow()
        {
            for (int i = 0; i < 4; i++)
            {
                if (Location[i][0] + 1 >= 23)
                    return true;
                if (Location[i][0] + 1 < 23)
                {
                    if (Game.droppedtetrominoeLocationGrid[Location[i][0] + 1, Location[i][1]] == 1)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public bool? isOverlayBelow(List<int[]> location)
        {
            List<int> ycoords = new List<int>();
            for (int i = 0; i < 4; i++)
            {
                ycoords.Add(location[i][0]);
                if (location[i][0] >= 23)
                    return true;
                if (location[i][0] < 0)
                    return null;
                if (location[i][1] < 0)
                {
                    return null;
                }
                if (location[i][1] > 9)
                {
                    return null;
                }
            }
            for (int i = 0; i < 4; i++)
            {
                if (ycoords.Max() - ycoords.Min() == 3)
                {
                    if (ycoords.Max() == location[i][0] | ycoords.Max() - 1 == location[i][0])
                    {
                        if (Game.droppedtetrominoeLocationGrid[location[i][0], location[i][1]] == 1)
                        {
                            return true;
                        }
                    }

                }
                else
                {
                    if (ycoords.Max() == location[i][0])
                    {
                        if (Game.droppedtetrominoeLocationGrid[location[i][0], location[i][1]] == 1)
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }


        public bool isSomethingLeft()
        {
            for (int i = 0; i < 4; i++)
            {
                if (Location[i][1] == 0)
                {
                    return true;
                }
                else if (Game.droppedtetrominoeLocationGrid[Location[i][0], Location[i][1] - 1] == 1)
                {
                    return true;
                }
            }
            return false;
        }
        public bool? isOverlayLeft(List<int[]> location)
        {
            List<int> xcoords = new List<int>();
            for (int i = 0; i < 4; i++)
            {
                xcoords.Add(location[i][1]);
                if (location[i][1] < 0)
                {
                    return true;
                }
                if (location[i][1] > 9)
                {
                    return false;
                }
                if (location[i][0] >= 23)
                    return null;
                if (location[i][0] < 0)
                    return null;
            }
            for (int i = 0; i < 4; i++)
            {
                if (xcoords.Max() - xcoords.Min() == 3)
                {
                    if (xcoords.Min() == location[i][1] | xcoords.Min() + 1 == location[i][1])
                    {
                        if (Game.droppedtetrominoeLocationGrid[location[i][0], location[i][1]] == 1)
                        {
                            return true;
                        }
                    }

                }
                else
                {
                    if (xcoords.Min() == location[i][1])
                    {
                        if (Game.droppedtetrominoeLocationGrid[location[i][0], location[i][1]] == 1)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        public bool isSomethingRight()
        {
            for (int i = 0; i < 4; i++)
            {
                if (Location[i][1] == 9)
                {
                    return true;
                }
                else if (Game.droppedtetrominoeLocationGrid[Location[i][0], Location[i][1] + 1] == 1)
                {
                    return true;
                }
            }
            return false;
        }
        public bool? isOverlayRight(List<int[]> location)
        {
            List<int> xcoords = new List<int>();
            for (int i = 0; i < 4; i++)
            {
                xcoords.Add(location[i][1]);
                if (location[i][1] > 9)
                {
                    return true;
                }
                if (location[i][1] < 0)
                {
                    return false;
                }
                if (location[i][0] >= 23)
                    return null;
                if (location[i][0] < 0)
                    return null;
            }
            for (int i = 0; i < 4; i++)
            {
                if (xcoords.Max() - xcoords.Min() == 3)
                {
                    if (xcoords.Max() == location[i][1] | xcoords.Max() - 1 == location[i][1])
                    {
                        if (Game.droppedtetrominoeLocationGrid[location[i][0], location[i][1]] == 1)
                        {
                            return true;
                        }
                    }
                }
                else
                {
                    if (xcoords.Max() == location[i][1])
                    {
                        if (Game.droppedtetrominoeLocationGrid[location[i][0], location[i][1]] == 1)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
    }
}