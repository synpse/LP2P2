using System;
using System.Collections.Generic;

namespace Tetris
{
    /// <summary>
    /// Creates Tetronimo Class
    /// </summary>
    class Tetromino
    {
        private Render render = new Render();
        private readonly Square square = new Square();

        public static int[,] I { get; } = new int[1, 4] { { 1, 1, 1, 1 } };
        public static int[,] O { get; } = new int[2, 2] { { 1, 1 }, { 1, 1 } };
        public static int[,] T { get; } = new int[2, 3] { { 0, 1, 0 }, { 1, 1, 1 } };
        public static int[,] S { get; } = new int[2, 3] { { 0, 1, 1 }, { 1, 1, 0 } };
        public static int[,] Z { get; } = new int[2, 3] { { 1, 1, 0 }, { 0, 1, 1 } };
        public static int[,] J { get; } = new int[2, 3] { { 1, 0, 0 }, { 1, 1, 1 } };
        public static int[,] L { get; } = new int[2, 3] { { 0, 0, 1 }, { 1, 1, 1 } };
        public static List<int[,]> Tetrominoes { get; } = new List<int[,]>() { I, O, T, S, Z, J, L };

        public bool IsErect { get; set; }
        public int[,] Shape { get; set; }
        public List<int[]> Location { get; set; }

        public static ConsoleColor CurrentColor { get; set; }

        // Build a new random tetromino
        /// <summary>
        /// Creates Tetronimo Constructor
        /// </summary>
        public Tetromino()
        {
            // New random
            Random rand = new Random();
            int random = rand.Next(0, 7);

            // Default values
            IsErect = false;
            Location = new List<int[]>();

            // Make a random new tetromino
            Shape = Tetrominoes[random];

            // A little debug
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine($"\n\n\nDebug:\nColor {CurrentColor}       \nType {random}");

            // Draw borders
            render.DrawBorder();

            // Clear old tetromino from GUI
            render.ClearOldTetromino();

            // Draw new tetromino on the side GUI
            render.DrawNewTetromino(Shape);
        }
    }
}
