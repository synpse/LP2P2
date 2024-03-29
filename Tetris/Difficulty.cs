﻿using System;
using System.Collections.Generic;

namespace Tetris
{
    class Difficulty
    {
        private int SelectedLine { get; set; }
        public int DifficultyLevel { get; set; }

        /// <summary>
        /// Method that adds functionality to the menu.
        /// </summary>
        public void Display()
        {
            Game game = new Game();
            MainMenu mainMenu = new MainMenu();

            SelectedLine = 0;

            List<string> menuLines = new List<string>() {
                "   Easy         ",
                "   Medium       ",
                "   Hard         ",
                "   Expert       ",
                "   Back         "
            };

            bool chosingMenu = true;

            //Creates a Menu for the player
            //Where he chooses the difficulty of the game
            while (chosingMenu)
            {
                Console.Clear();

                string selected = DisplayMenu(menuLines);
                if (selected == "   Easy         ")
                {
                    Console.Clear();
                    DifficultyLevel = 1;
                    game.Start(DifficultyLevel);
                    Console.Clear();
                    chosingMenu = false;
                }
                else if (selected == "   Medium       ")
                {
                    Console.Clear();
                    DifficultyLevel = 2;
                    game.Start(DifficultyLevel);
                    Console.Clear();
                    chosingMenu = false;
                }
                else if (selected == "   Hard         ")
                {
                    Console.Clear();
                    DifficultyLevel = 3;
                    game.Start(DifficultyLevel);
                    Console.Clear();
                    chosingMenu = false;
                }
                else if (selected == "   Expert       ")
                {
                    Console.Clear();
                    DifficultyLevel = 4;
                    game.Start(DifficultyLevel);
                    Console.Clear();
                    chosingMenu = false;
                }
                else if (selected == "   Back         ")
                {
                    Console.Clear();
                    mainMenu.Display();
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
                if (i == SelectedLine)
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
            if (SelectedLine == 0)
            {
                Console.WriteLine("Play the game on easy");
            }
            if (SelectedLine == 1)
            {
                Console.WriteLine("Play the game on medium");
            }
            if (SelectedLine == 2)
            {
                Console.WriteLine("Play the game on hard");
            }
            if (SelectedLine == 3)
            {
                Console.WriteLine("Play the game on expert");
            }
            Console.ResetColor();
            Console.WriteLine();

            Console.SetCursorPosition(0, 23);

            ConsoleKeyInfo input = Console.ReadKey();

            if (input.Key == ConsoleKey.DownArrow)
            {
                SelectedLine++;
                if (SelectedLine > 4)
                {
                    SelectedLine = 0;
                }
            }
            else if (input.Key == ConsoleKey.UpArrow)
            {
                SelectedLine--;
                if (SelectedLine < 0)
                {
                    SelectedLine = 4;
                }
            }
            else if (input.Key == ConsoleKey.Enter || input.Key == ConsoleKey.Spacebar)
            {
                return lines[SelectedLine];
            }
            else
            {
                return null;
            }
            return null;

        }
    }
}
