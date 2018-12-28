using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class Difficulty
    {
        private int selectedLine = 0;
        public int difficultyLevel;

        /// <summary>
        /// Method that adds functionality to the menu.
        /// </summary>
        public void Display()
        {
            Game game = new Game();

            //Credits credits = new Credits();

            //HighScores highScores = new HighScores();

            List<string> menuLines = new List<string>() {
                "   Easy         ",
                "   Medium       ",
                "   Hard         ",
                "   Expert       "
            };

            bool chosingMenu = true;

            while (chosingMenu)
            {
                Console.Clear();

                string selected = DisplayMenu(menuLines);
                if (selected == "   Easy         ")
                {
                    Console.Clear();
                    difficultyLevel = 1;
                    game.Start(difficultyLevel);
                    Console.Clear();
                    chosingMenu = false;
                }
                else if (selected == "   Medium       ")
                {
                    Console.Clear();
                    difficultyLevel = 2;
                    game.Start(difficultyLevel);
                    Console.Clear();
                    chosingMenu = false;
                }
                else if (selected == "   Hard         ")
                {
                    Console.Clear();
                    difficultyLevel = 3;
                    game.Start(difficultyLevel);
                    Console.Clear();
                    chosingMenu = false;
                }
                else if (selected == "   Expert       ")
                {
                    Console.Clear();
                    difficultyLevel = 4;
                    game.Start(difficultyLevel);
                    Console.Clear();
                    chosingMenu = false;
                }
            }
        }

        /// <summary>
        /// Method that draws the menu.
        /// </summary>
        /// <param name="lines">Lines of the menu.</param>
        /// <returns>This method does not return anything.</returns>
        private string DisplayMenu(List<string> lines)
        {
            for (int i = 0; i < lines.Count; i++)
            {
                if (i == selectedLine)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;

                    Console.WriteLine();
                    Console.SetCursorPosition(1, 1 + 3 * i);
                    Console.WriteLine(lines[i]);
                    Console.WriteLine();
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    Console.ForegroundColor = ConsoleColor.White;

                    Console.WriteLine();
                    Console.SetCursorPosition(1, 1 + 3 * i);
                    Console.WriteLine(lines[i]);
                    Console.WriteLine();
                }
                Console.ResetColor();
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(2, 23);
            if (selectedLine == 0)
            {
                Console.WriteLine("Play the game on easy");
            }
            if (selectedLine == 1)
            {
                Console.WriteLine("Play the game on medium");
            }
            if (selectedLine == 2)
            {
                Console.WriteLine("Play the game on hard");
            }
            if (selectedLine == 3)
            {
                Console.WriteLine("Play the game on expert");
            }
            Console.ResetColor();
            Console.WriteLine();

            Console.SetCursorPosition(0, 23);

            ConsoleKeyInfo input = Console.ReadKey();

            if (input.Key == ConsoleKey.DownArrow)
            {
                if (selectedLine == lines.Count - 1)
                {
                }
                else
                {
                    selectedLine++;
                }
            }
            else if (input.Key == ConsoleKey.UpArrow)
            {
                if (selectedLine <= 0)
                {
                }
                else
                {
                    selectedLine--;
                }
            }
            else if (input.Key == ConsoleKey.Enter || input.Key == ConsoleKey.Spacebar)
            {
                return lines[selectedLine];
            }
            else
            {
                return null;
            }
            return null;

        }
    }
}
