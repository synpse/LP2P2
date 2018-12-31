using System;

namespace Tetris
{
    class GameOver
    {
        private HighscoresManager hsm = new HighscoresManager();
        private Difficulty difficulty = new Difficulty();
        private MainMenu mainMenu = new MainMenu();

        public void Display(int score, int difficultyLevel)
        {
            bool saving = true;
            while(saving)
            {
                Console.Clear();
                Console.SetCursorPosition(55, 2);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(" [Game Over]");
                Console.ResetColor();
                Console.SetCursorPosition(36, 4);
                Console.Write($"Your score was {score}. Do you want to save it? (Y/N)");
                ConsoleKeyInfo input = Console.ReadKey();

                if (input.Key == ConsoleKey.Y)
                {
                    Console.SetCursorPosition(48, 22);
                    Console.WriteLine("Press ENTER when done...");
                    Console.SetCursorPosition(48, 6);
                    Console.Write("Insert your name here: ");
                    string name = Console.ReadLine();
                    // Add score and name
                    hsm.AddScore(name, score, difficultyLevel.ToString());
                    // Save to file
                    hsm.Save();

                    Console.Clear();
                    Console.SetCursorPosition(55, 2);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(" [Game Over]");
                    Console.ResetColor();
                    Console.SetCursorPosition(36, 4);
                    Console.Write($"Your score was saved! Do you want to retry? (Y/N)");
                    ConsoleKeyInfo input2 = Console.ReadKey();

                    if (input2.Key == ConsoleKey.Y)
                    {
                        difficulty.Display();
                        saving = false;
                    }
                    else if (input2.Key == ConsoleKey.N)
                    {
                        mainMenu.Display();
                        saving = false;
                    }
                }
                else if (input.Key == ConsoleKey.N)
                {
                    Console.Clear();
                    Console.SetCursorPosition(55, 2);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine(" [Game Over]");
                    Console.ResetColor();
                    Console.SetCursorPosition(48, 4);
                    Console.Write($"Do you want to retry? (Y/N)");
                    ConsoleKeyInfo input2 = Console.ReadKey();

                    if (input2.Key == ConsoleKey.Y)
                    {
                        difficulty.Display();
                        saving = false;
                    }
                    else if (input2.Key == ConsoleKey.N)
                    {
                        mainMenu.Display();
                        saving = false;
                    }
                }
            }
        }
    }
}
