using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class Credits
    {
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
