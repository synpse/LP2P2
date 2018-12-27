using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    public class Tetromino
    {
        public static int[,] I = new int[1, 4] { { 1, 1, 1, 1 } };
        public static int[,] O = new int[2, 2] { { 1, 1 }, { 1, 1 } };
        public static int[,] T = new int[2, 3] { { 0, 1, 0 }, { 1, 1, 1 } };
        public static int[,] S = new int[2, 3] { { 0, 1, 1 }, { 1, 1, 0 } };
        public static int[,] Z = new int[2, 3] { { 1, 1, 0 }, { 0, 1, 1 } };
        public static int[,] J = new int[2, 3] { { 1, 0, 0 }, { 1, 1, 1 } };
        public static int[,] L = new int[2, 3] { { 0, 0, 1 }, { 1, 1, 1 } };
        public static List<int[,]> tetrominoes = new List<int[,]>() { I, O, T, S, Z, J, L };

        public bool IsErect { get; set; }
        public int[,] Shape { get; set; }
        public List<int[]> Location { get; set; }

        public static ConsoleColor CurrentColor { get; set; }

        Render render = new Render();
        Square square = new Square();

        public Tetromino()
        {
            Random rand = new Random();
            int random = rand.Next(0, 7);
            IsErect = false;
            Location = new List<int[]>();

            // Make a random new tetromino
            Shape = tetrominoes[random];

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine($"\n\n\nDebug:\nColor {CurrentColor}\nType {random}");
                       
            // Draw Grid
            for (int i = 23; i < 33; ++i)
            {
                for (int j = 3; j < 10; j++)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(i, j);
                    Console.Write(" ");
                }

            }

            // Draw borders
            render.DrawBorder();

            // Draw new tetromino on the side GUI
            for (int i = 0; i < Shape.GetLength(0); i++)
            {
                for (int j = 0; j < Shape.GetLength(1); j++)
                {
                    if (Shape[i, j] == 1)
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
                        Console.SetCursorPosition(((10 - Shape.GetLength(1)) / 2 + j) * 2 + 20, i + 5);
                        Console.ForegroundColor = CurrentColor;
                        Console.Write(square.Sqr);
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                }
            }
        }
    }
}
