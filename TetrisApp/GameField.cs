using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisApp
{
    public class GameField
    {
        public int Width { get; private set; }
        public int Height { get; private set; }
        private int[,] field;

        public GameField(int width, int height)
        {
            Width = width;
            Height = height;
            field = new int[height, width];
        }

        public bool IsPositionValid(Tetrimino tetrimino, int offsetX, int offsetY)
        {
            for (int y = 0; y < tetrimino.Height; y++)
            {
                for (int x = 0; x < tetrimino.Width; x++)
                {
                    if (tetrimino.Shape[y, x] != 0)
                    {
                        int fieldX = offsetX + x;
                        int fieldY = offsetY + y;
                        if (fieldX < 0 || fieldX >= Width || fieldY < 0 || fieldY >= Height || field[fieldY, fieldX] != 0)
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        public void PlaceTetrimino(Tetrimino tetrimino, int offsetX, int offsetY)
        {
            for (int y = 0; y < tetrimino.Height; y++)
            {
                for (int x = 0; x < tetrimino.Width; x++)
                {
                    if (tetrimino.Shape[y, x] != 0)
                    {
                        field[offsetY + y, offsetX + x] = tetrimino.Shape[y, x];
                    }
                }
            }
        }

        public void Draw()
        {
            Console.Clear();
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    Console.Write(field[y, x] == 0 ? '.' : '#');
                }
                Console.WriteLine();
            }
        }
    }


}
