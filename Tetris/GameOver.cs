using System;

namespace Tetris
{
    /// <summary>
    /// Creates the Gameover Class
    /// </summary>
    class GameOver
    {
        /// <summary>
        /// Creates the display of the GameOver where it shows
        /// the difficulty of the game and the score the player made
        /// </summary>
        /// <param name="score"></param>
        /// <param name="difficultyLevel"></param>
        public void Display(int score, int difficultyLevel)
        {
            HighscoresManager hsm = new HighscoresManager();

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
                    Retry();
                    saving = false;
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
                    Retry();
                    saving = false;
                }
            }
        }

        /// <summary>
        /// Creates a retry method 
        /// </summary>
        public void Retry()
        {
            Difficulty difficulty = new Difficulty();
            MainMenu mainMenu = new MainMenu();

            bool retrying = true;
            while(retrying)
            {
                ConsoleKeyInfo input = Console.ReadKey();

                if (input.Key == ConsoleKey.Y)
                {
                    difficulty.Display();
                    retrying = false;
                }
                else if (input.Key == ConsoleKey.N)
                {
                    mainMenu.Display();
                    retrying = false;
                }
            }
        }
    }
}
