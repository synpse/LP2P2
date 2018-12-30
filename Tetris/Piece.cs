using System;
using System.Collections.Generic;
using System.Linq;

namespace Tetris
{
    /// <summary>
    /// Creates Piece Class that is inherited from Tetronimo 
    /// </summary>
    class Piece : Tetromino
    {
        private Render render = new Render();

        /// <summary>
        /// Creates PositionUpdate Metod
        /// </summary>
        /// <param name="Grid"></param>
        /// <param name="DroppedtetrominoeLocationGrid"></param>
        public void PositionUpdate(int[,] Grid, int[,] DroppedtetrominoeLocationGrid)
        {
            for (int i = 0; i < 23; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Grid[i, j] = 0;
                }
            }
            for (int i = 0; i < 4; i++)
            {
                Grid[Location[i][0], Location[i][1]] = 1;
            }
            render.Draw(Grid, DroppedtetrominoeLocationGrid);
        }

        /// <summary>
        /// Creates Spawn Method
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="droppedtetrominoeLocationGrid"></param>
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

        /// <summary>
        /// Creates Drop Method
        /// </summary>
        /// <param name="Grid"></param>
        /// <param name="DroppedtetrominoeLocationGrid"></param>
        public void Drop(int[,] Grid, int[,] DroppedtetrominoeLocationGrid)
        {
            if (IsSomethingBelow(DroppedtetrominoeLocationGrid))
            {
                for (int i = 0; i < 4; i++)
                {
                    DroppedtetrominoeLocationGrid[Location[i][0], Location[i][1]] = 1;
                }
                Game.IsDropped = true;
            }
            else
            {
                for (int numCount = 0; numCount < 4; numCount++)
                {
                    Location[numCount][0] += 1;
                }
                PositionUpdate(Grid, DroppedtetrominoeLocationGrid);
            }
        }

        /// <summary>
        /// Creates Rotate Method
        /// </summary>
        /// <param name="DroppedtetrominoeLocationGrid"></param>
        public void Rotate(int[,] DroppedtetrominoeLocationGrid)
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

            if (Shape == Tetrominoes[0])
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

            else if (Shape == Tetrominoes[3])
            {
                for (int i = 0; i < Location.Count; i++)
                {
                    templocation[i] = TransformMatrix(Location[i], Location[3], "Clockwise");
                }
            }

            else if (Shape == Tetrominoes[1]) return;
            else
            {
                for (int i = 0; i < Location.Count; i++)
                {
                    templocation[i] = TransformMatrix(Location[i], Location[2], "Clockwise");
                }
            }


            for (int count = 0; IsOverlayLeft(templocation, DroppedtetrominoeLocationGrid) != false 
                | IsOverlayRight(templocation, DroppedtetrominoeLocationGrid) != false 
                | IsOverlayBelow(templocation, DroppedtetrominoeLocationGrid) != false; count++)
            {
                if (IsOverlayLeft(templocation, DroppedtetrominoeLocationGrid) == true)
                {
                    for (int i = 0; i < Location.Count; i++)
                    {
                        templocation[i][1] += 1;
                    }
                }
                if (IsOverlayRight(templocation, DroppedtetrominoeLocationGrid) == true)
                {
                    for (int i = 0; i < Location.Count; i++)
                    {
                        templocation[i][1] -= 1;
                    }
                }
                if (IsOverlayBelow(templocation, DroppedtetrominoeLocationGrid) == true)
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

        /// <summary>
        /// Creates TransformMatrix Method
        /// </summary>
        /// <param name="coord"></param>
        /// <param name="axis"></param>
        /// <param name="dir"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Creates IsSomethingBelow Method
        /// </summary>
        /// <param name="DroppedtetrominoeLocationGrid"></param>
        /// <returns></returns>
        public bool IsSomethingBelow(int[,] DroppedtetrominoeLocationGrid)
        {
            for (int i = 0; i < 4; i++)
            {
                if (Location[i][0] + 1 >= 23)
                    return true;
                if (Location[i][0] + 1 < 23)
                {
                    if (DroppedtetrominoeLocationGrid[Location[i][0] + 1, Location[i][1]] == 1)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Creates IsOverlayBellow Method
        /// </summary>
        /// <param name="location"></param>
        /// <param name="DroppedtetrominoeLocationGrid"></param>
        /// <returns></returns>
        public bool ? IsOverlayBelow(List<int[]> location, int[,] DroppedtetrominoeLocationGrid) //Nullable<bool>
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
                        if (DroppedtetrominoeLocationGrid[location[i][0], location[i][1]] == 1)
                        {
                            return true;
                        }
                    }

                }
                else
                {
                    if (ycoords.Max() == location[i][0])
                    {
                        if (DroppedtetrominoeLocationGrid[location[i][0], location[i][1]] == 1)
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Creates Method IsSomethingLeft
        /// </summary>
        /// <param name="DroppedtetrominoeLocationGrid"></param>
        /// <returns></returns>
        public bool IsSomethingLeft(int[,] DroppedtetrominoeLocationGrid)
        {
            try
            {
                for (int i = 0; i < 4; i++)
                {
                    //Console.WriteLine(i);
                    if (Location[i][1] == 0)
                    {
                        return true;
                    }
                    else if (DroppedtetrominoeLocationGrid[Location[i][0], Location[i][1] - 1] == 1)
                    {
                        return true;
                    }
                    if (DroppedtetrominoeLocationGrid[Location[i][0], Location[i][1] - 1] == 1)
                    {
                        return true;
                    }
                }
                return false;
            }
            catch
            {
                
            }

            return false;


        }

        /// <summary>
        /// Creates IsOverlayLeft Method
        /// </summary>
        /// <param name="location"></param>
        /// <param name="DroppedtetrominoeLocationGrid"></param>
        /// <returns></returns>
        public bool ? IsOverlayLeft(List<int[]> location, int[,] DroppedtetrominoeLocationGrid) //Nullable<bool>
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
                        if (DroppedtetrominoeLocationGrid[location[i][0], location[i][1]] == 1)
                        {
                            return true;
                        }
                    }

                }
                else
                {
                    if (xcoords.Min() == location[i][1])
                    {
                        if (DroppedtetrominoeLocationGrid[location[i][0], location[i][1]] == 1)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Creates IsSomethingRight Method
        /// </summary>
        /// <param name="DroppedtetrominoeLocationGrid"></param>
        /// <returns></returns>
        public bool IsSomethingRight(int[,] DroppedtetrominoeLocationGrid)
        {
            try
            {
                for (int i = 0; i < 4; i++)
                {
                    if (Location[i][1] == 9)
                    {
                        return true;
                    }
                    else if (DroppedtetrominoeLocationGrid[Location[i][0], Location[i][1] + 1] == 1)
                    {
                        return true;
                    }
                }
                return false;
            }
            catch
            {

            }

            return false;

        }

        /// <summary>
        /// Creates Is OverlayRight Method
        /// </summary>
        /// <param name="location"></param>
        /// <param name="DroppedtetrominoeLocationGrid"></param>
        /// <returns></returns>
        public bool ? IsOverlayRight(List<int[]> location, int[,] DroppedtetrominoeLocationGrid) //Nullable<bool>
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
                        if (DroppedtetrominoeLocationGrid[location[i][0], location[i][1]] == 1)
                        {
                            return true;
                        }
                    }
                }
                else
                {
                    if (xcoords.Max() == location[i][1])
                    {
                        if (DroppedtetrominoeLocationGrid[location[i][0], location[i][1]] == 1)
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