using System;
using System.Drawing;

namespace Case1WFP
{
    public class TetrisPiece
    {
        public static Random rand = new Random();
        public int[,] Shape { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public Color Color { get; private set; }

        public TetrisPiece()
        {

            int type = rand.Next(7);
            switch (type)
            {
                case 0: // I
                    Shape = new int[,]
                    {
                          { 1, 1, 1, 1 }
                    };
                    Color = Color.Cyan;
                    break;
                case 1: // O
                    Shape = new int[,]
                    {
                          { 1, 1 }, { 1, 1 }
                    };
                    Color = Color.Yellow;
                    break;
                case 2:
                    Shape = new int[,]
                    {
                        { 0, 1, 0 }, { 1, 1, 1 }
                    };
                    Color = Color.Red;
                    break;
                case 3: // L
                    Shape = new int[,]
                    {
                        { 0, 0, 1 }, { 1, 1, 1 }
                    };
                    Color = Color.Green;
                    break;
                case 4: // J
                    Shape = new int[,]
                    {
                        { 1, 0, 0, 0 }, { 0, 1, 1, 1 }
                    };
                    Color = Color.Blue;
                    break;
                case 5: // S
                    Shape = new int[,]
                    {
                        { 1, 1, 0 }, { 0, 1, 1 }
                    };
                    Color = Color.Magenta;
                    break;
                case 6: // Z
                    Shape = new int[,]
                    {
                        { 0, 1, 1 }, { 1, 0, 0 }
                    };
                    Color = Color.Yellow;
                    break;

            }
            X = 4; Y = 0;
        }
        public void Rotate()
        {
            int width = Shape.GetLength(0);
            int height = Shape.GetLength(1);
            int[,] newShape = new int[height, width];
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                { newShape[y, width - 1 - x] = Shape[x, y]; }
            }
            Shape = newShape;
        }
        public void RotateBack()
        {
            int width = Shape.GetLength(0);
            int height = Shape.GetLength(1);
            int[,] newShape = new int[height, width];
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < width; y++)
                {
                    newShape[height - 1 - y, x] = Shape[x, y];
                }
                Shape = newShape;
            }
        }
    }
}