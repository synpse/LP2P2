using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class GameOver
    {
        HighscoresManager hsm = new HighscoresManager();
        Difficulty difficulty = new Difficulty();
        MainMenu mainMenu = new MainMenu();

        public void Display(int score)
        {
            Console.Clear();
            Console.SetCursorPosition(55, 2);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" [Game Over]");
            Console.ResetColor();
            Console.SetCursorPosition(36, 4);
            Console.Write($"Your score was {score}. Do you want to save it? (Y/N): ");
            string input = Console.ReadLine().ToLower();

            if (input == "y")
            {
                Console.SetCursorPosition(48, 6);
                Console.Write("Insert your name here: ");
                string name = Console.ReadLine();
                // Add score and name
                hsm.AddScore(name, score);
                // Save to file
                hsm.Save();

                Console.Clear();
                Console.SetCursorPosition(55, 2);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(" [Game Over]");
                Console.ResetColor();
                Console.SetCursorPosition(36, 4);
                Console.Write($"Your score was saved! Do you want to retry? (Y/N): ");
                string input2 = Console.ReadLine().ToLower();

                if (input2 == "y")
                {
                    difficulty.Display();
                }
                else
                {
                    mainMenu.Display();
                }
            }
            else
            {
                Console.Clear();
                Console.SetCursorPosition(55, 2);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(" [Game Over]");
                Console.ResetColor();
                Console.SetCursorPosition(48, 4);
                Console.Write($"Do you want to retry? (Y/N): ");
                string input2 = Console.ReadLine().ToLower();

                if (input2 == "y")
                {
                    difficulty.Display();
                }
                else
                {
                    mainMenu.Display();
                }
            }
        }
    }
}
