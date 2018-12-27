using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Diagnostics;
using System.Media;
using System.Resources;
using System.IO;
using System.Reflection;

namespace Tetris
{
    class Game
    {
        public static int[,] grid = new int[23, 10];
        public static int[,] droppedtetrominoeLocationGrid = new int[23, 10];
        private Stopwatch timer = new Stopwatch();
        private Stopwatch dropTimer = new Stopwatch();
        private Stopwatch inputTimer = new Stopwatch();
        public int dropTime, dropRate;
        public static bool isDropped = false;
        public Piece tet;
        public Piece nexttet;
        //public ConsoleKeyInfo key;
        public bool isKeyPressed = false;
        public int linesCleared = 0, score = 0, level = 1;
        Input input = new Input();
        Render render = new Render();

        public void Start()
        {
            //SoundPlayer sp = new SoundPlayer();
            //sp.SoundLocation = Environment.CurrentDirectory + "\\01_-_Tetris_Tengen_-_NES_-_Introduction.wav";
            //sp.PlayLooping();

            render.DrawBorder();
            Console.SetCursorPosition(4, 5);
            Console.WriteLine("Press any key");
            Console.ReadKey(true);

            //sp.Stop();
            //sp.SoundLocation = Environment.CurrentDirectory + "\\music.wav";
            //sp.PlayLooping();

            timer.Start();
            dropTimer.Start();
            long time = timer.ElapsedMilliseconds;

            Console.SetCursorPosition(25, 0);
            Console.WriteLine("Level " + level);
            Console.SetCursorPosition(25, 1);
            Console.WriteLine("Score " + score);
            Console.SetCursorPosition(25, 2);
            Console.WriteLine("LinesCleared " + linesCleared);

            nexttet = new Piece();
            tet = nexttet;
            tet.Spawn(grid, droppedtetrominoeLocationGrid);
            nexttet = new Piece();

            Update();

            //sp.Stop();
            //sp.SoundLocation = Environment.CurrentDirectory + "\\08_-_Tetris_Tengen_-_NES_-_Game_Over.wav";
            //sp.Play();
            Console.SetCursorPosition(0, 0);
            Console.Clear();

            do
            {
                Console.WriteLine("Game Over \n Replay? (Y/N)");
                string input = Console.ReadLine().ToLower();

                if (input == "y")
                {
                    return;
                }
                else if (input == "n")
                {
                    System.Environment.Exit(1);
                }
                Console.Clear();
            } while (true);
            

        }

        public void Update()
        {
            // Gameloop
            while (true)
            {
                dropTime = (int)dropTimer.ElapsedMilliseconds;
                if (dropTime > dropRate)
                {
                    dropTime = 0;
                    dropTimer.Restart();
                    tet.Drop(grid, droppedtetrominoeLocationGrid);
                }
                if (isDropped == true)
                {
                    tet = nexttet;
                    nexttet = new Piece();
                    tet.Spawn(grid, droppedtetrominoeLocationGrid);

                    isDropped = false;
                }
                int j;
                for (j = 0; j < 10; j++)
                {
                    if (droppedtetrominoeLocationGrid[0, j] == 1)
                        return;
                }

                //input.Readkey(isKeyPressed, tet, key);
                input.Readkey(isKeyPressed, tet);
                CheckLine();
            }
        }

        public void CheckLine()
        {
            int combo = 0;
            for (int i = 0; i < 23; i++)
            {
                int j;
                for (j = 0; j < 10; j++)
                {
                    if (droppedtetrominoeLocationGrid[i, j] == 0)
                        break;
                }
                if (j == 10)
                {
                    ClearLine(combo, i, j);
                }
            }
            if (combo == 1)
                score += 40 * level;
            else if (combo == 2)
                score += 100 * level;
            else if (combo == 3)
                score += 300 * level;
            else if (combo > 3)
                score += 300 * combo * level;

            if (linesCleared < 5) level = 1;
            else if (linesCleared < 10) level = 2;
            else if (linesCleared < 15) level = 3;
            else if (linesCleared < 25) level = 4;
            else if (linesCleared < 35) level = 5;
            else if (linesCleared < 50) level = 6;
            else if (linesCleared < 70) level = 7;
            else if (linesCleared < 90) level = 8;
            else if (linesCleared < 110) level = 9;
            else if (linesCleared < 150) level = 10;


            if (combo > 0)
            {
                Console.SetCursorPosition(25, 0);
                Console.WriteLine("Level " + level);
                Console.SetCursorPosition(25, 1);
                Console.WriteLine("Score " + score);
                Console.SetCursorPosition(25, 2);
                Console.WriteLine("LinesCleared " + linesCleared);
            }

            dropRate = 300 - 22 * level;

        }

        public void ClearLine(int combo, int i, int j)
        {
            linesCleared++;
            combo++;
            for (j = 0; j < 10; j++)
            {
                droppedtetrominoeLocationGrid[i, j] = 0;
            }
            int[,] newdroppedtetrominoeLocationGrid = new int[23, 10];
            for (int k = 1; k < i; k++)
            {
                for (int l = 0; l < 10; l++)
                {
                    newdroppedtetrominoeLocationGrid[k + 1, l] = droppedtetrominoeLocationGrid[k, l];
                }
            }
            for (int k = 1; k < i; k++)
            {
                for (int l = 0; l < 10; l++)
                {
                    droppedtetrominoeLocationGrid[k, l] = 0;
                }
            }
            for (int k = 0; k < 23; k++)
                for (int l = 0; l < 10; l++)
                    if (newdroppedtetrominoeLocationGrid[k, l] == 1)
                        droppedtetrominoeLocationGrid[k, l] = 1;
            render.Draw(grid, droppedtetrominoeLocationGrid);
        }
    }
}
