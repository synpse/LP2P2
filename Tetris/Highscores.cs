using System;

namespace Tetris
{
    class Highscores
    {
        private HighscoresManager hsm = new HighscoresManager();

        public void Display()
        {
            Console.Clear();
            Console.SetCursorPosition(55, 2);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("[High Scores]");
            Console.ResetColor();

            int row = 4;

            ///Pecorre o ficheiro .txt e imprimi o nome e o respectivo score.
            foreach (Tuple<string, float, string> highscore in hsm.GetScores())
            {
                row++;
                Console.SetCursorPosition(20, row);
                Console.WriteLine($"Name: {highscore.Item1,-40}" + $"Difficulty: {highscore.Item3, - 10}" + $"Score: {highscore.Item2}");
            }

            Console.SetCursorPosition(48, 22);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Press any Key to continue...");

            Console.ReadKey();
        }
    }
}
