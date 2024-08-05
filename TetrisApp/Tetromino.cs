using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisApp
{
    public class Tetrimino
    {
        public int[,] Shape { get; private set; }
        public int Width => Shape.GetLength(1);
        public int Height => Shape.GetLength(0);

        public Tetrimino(int[,] shape)
        {
            Shape = shape;
        }

        public void Rotate()
        {
            int newHeight = Width;
            int newWidth = Height;
            int[,] rotatedShape = new int[newHeight, newWidth];

            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    rotatedShape[x, Height - 1 - y] = Shape[y, x];
                }
            }

            Shape = rotatedShape;
        }
    }

}
