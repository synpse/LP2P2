﻿using System;

namespace Tetris
{
    /// <summary>
    /// Creates the Credits Class
    /// </summary>
    class Credits
    {
        /// <summary>
        /// Creates the method Display where it
        /// shows the credits of the game
        /// </summary>
        public void Display()
        {
            Console.Clear();
            Console.SetCursorPosition(56, 2);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("[Credits]");
            Console.ResetColor();
            Console.SetCursorPosition(33, 4);
            Console.WriteLine("<< Universidade Lusófona de Humanidades e Tecnologias >> ");
            Console.SetCursorPosition(35, 6);
            Console.WriteLine("This project was made by Diogo Maia and Tiago Alves.");
            Console.SetCursorPosition(48, 22);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Press any Key to continue...");
            Console.ReadKey();
        }
    }
}
