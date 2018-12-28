using System;
using System.Text;

namespace Tetris
{
    /// <summary>
    /// Classe aonde irá decorrer todo o projecto
    /// </summary>
    class Program
    {
        /// <summary>
        /// Método que irá "chamar" as classes necessárias através de variáveis
        /// de instância para efectuar o ciclo de jogo
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            MainMenu mainMenu = new MainMenu();

            Console.OutputEncoding = Encoding.UTF8;
            Console.CursorVisible = false;

            mainMenu.Display();
        }
    }
}

