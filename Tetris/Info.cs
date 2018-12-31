using System;

namespace Tetris
{
    class Info
    {
        public void Display()
        {
            Console.Clear();
            Console.SetCursorPosition(58, 2);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("[Info]");
            Console.ResetColor();
            Console.SetCursorPosition(46, 4);
            Console.WriteLine("This project is a Tetris clone.");
            Console.SetCursorPosition(8, 6);
            Console.WriteLine("The original idea for this game belongs to Alexey Pajitnov of the Academy of Science of the Soviet Union.");
            Console.SetCursorPosition(58, 8);
            Console.WriteLine("*blyat*");
            Console.SetCursorPosition(54, 10);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("[Game Controls]");
            Console.ResetColor();
            Console.SetCursorPosition(43, 12);
            Console.WriteLine("LEFT ARROW to move tetromino to left;");
            Console.SetCursorPosition(42, 13);
            Console.WriteLine("RIGHT ARROW to move tetromino to right;");
            Console.SetCursorPosition(47, 14);
            Console.WriteLine("SPACEBAR to rotate tetromino;");
            Console.SetCursorPosition(45, 15);
            Console.WriteLine("DOWN ARROW to soft-drop tetromino;");
            Console.SetCursorPosition(46, 16);
            Console.WriteLine("UP ARROW to hard-drop tetromino.");
            Console.SetCursorPosition(38, 20);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Warning: This game contains flashing lights!");
            Console.SetCursorPosition(48, 22);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Press any Key to continue...");
            Console.ReadKey();
        }
    }
}
