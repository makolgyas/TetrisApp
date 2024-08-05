using System;
using TetrisApp;

using System;

class Program
{
    static void Main(string[] Args)
    {
        TetrisGame game = new TetrisGame(10, 20);

        while (true)
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.LeftArrow:
                        game.MoveLeft();
                        break;
                    case ConsoleKey.RightArrow:
                        game.MoveRight();
                        break;
                    case ConsoleKey.DownArrow:
                        game.MoveDown();
                        break;
                    case ConsoleKey.Spacebar:
                        game.Rotate();
                        break;
                }
            }

            game.Update();
            System.Threading.Thread.Sleep(500); // Update game state every 500 ms
        }
    }
}

