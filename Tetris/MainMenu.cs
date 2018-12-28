using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class MainMenu
    {
        private int selectedLine = 0;

        /// <summary>
        /// Method that adds functionality to the menu.
        /// </summary>
        public void Display()
        {
            Difficulty difficulty = new Difficulty();
            Info info = new Info();
            Credits credits = new Credits();
            Highscores highscores = new Highscores();

            List<string> menuLines = new List<string>() {
                "   New Game     ",
                "   High Scores  ",
                "   Game Info    ",
                "   Credits      ",
                "   Quit         "
            };

            bool chosingMenu = true;

            while (chosingMenu)
            {
                Console.Clear();

                string selected = DisplayMenu(menuLines);
                if (selected == "   New Game     ")
                {
                    Console.Clear();
                    difficulty.Display();
                    Console.Clear();
                    chosingMenu = false;
                }
                else if (selected == "   High Scores  ")
                {
                    Console.Clear();
                    highscores.Display();
                    Console.Clear();
                }
                else if (selected == "   Game Info    ")
                {
                    Console.Clear();
                    info.Display();
                    Console.Clear();
                }
                else if (selected == "   Credits      ")
                {
                    Console.Clear();
                    credits.Display();
                    Console.Clear();
                }
                else if (selected == "   Quit         ")
                {
                    Environment.Exit(0);
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
                Console.WriteLine("Start the game");
            }
            if (selectedLine == 1)
            {
                Console.WriteLine("View high scores");
            }
            if (selectedLine == 2)
            {
                Console.WriteLine("View game information");
            }
            if (selectedLine == 3)
            {
                Console.WriteLine("Look at the credits");
            }
            if (selectedLine == 4)
            {
                Console.WriteLine("Quit the game");
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
