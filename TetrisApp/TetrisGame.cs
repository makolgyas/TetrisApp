using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisApp
{
    public class TetrisGame
    {
        private GameField field;
        private Tetrimino currentTetrimino;
        private int currentX;
        private int currentY;

        public TetrisGame(int width, int height)
        {
            field = new GameField(width, height);
            currentTetrimino = GetRandomTetrimino();
            currentX = width / 2;
            currentY = 0;
        }

        public void MoveLeft()
        {
            if (field.IsPositionValid(currentTetrimino, currentX - 1, currentY))
            {
                currentX--;
            }
        }

        public void MoveRight()
        {
            if (field.IsPositionValid(currentTetrimino, currentX + 1, currentY))
            {
                currentX++;
            }
        }

        public void MoveDown()
        {
            if (field.IsPositionValid(currentTetrimino, currentX, currentY + 1))
            {
                currentY++;
            }
            else
            {
                field.PlaceTetrimino(currentTetrimino, currentX, currentY);
                currentTetrimino = GetRandomTetrimino();
                currentX = field.Width / 2;
                currentY = 0;
            }
        }

        public void Rotate()
        {
            currentTetrimino.Rotate();
            if (!field.IsPositionValid(currentTetrimino, currentX, currentY))
            {
                // Revert rotation if invalid
                currentTetrimino.Rotate();
                currentTetrimino.Rotate();
                currentTetrimino.Rotate();
            }
        }

        public void Update()
        {
            MoveDown();
            if (!field.IsPositionValid(currentTetrimino, currentX, currentY))
            {
                Console.Clear();
                Console.WriteLine("Game Over");
                Console.WriteLine("Press 'R' to restart");
                while (Console.ReadKey(true).Key != ConsoleKey.R) ;
                // Restart game
                field = new GameField(field.Width, field.Height);
                currentTetrimino = GetRandomTetrimino();
                currentX = field.Width / 2;
                currentY = 0;
            }
            else
            {
                field.Draw();
            }
        }

        private Tetrimino GetRandomTetrimino()
        {
            // Define Tetrimino shapes
            int[][,] shapes = new int[][,]
            {
            new int[,] { { 1, 1, 1, 1 } },
            new int[,] { { 1, 1 }, { 1, 1 } },
            new int[,] { { 0, 1, 0 }, { 1, 1, 1 } },
            new int[,] { { 1, 1, 0 }, { 0, 1, 1 } },
            new int[,] { { 0, 1, 1 }, { 1, 1, 0 } }
            };

            Random rand = new Random();
            return new Tetrimino(shapes[rand.Next(shapes.Length)]);
        }
    }

}
